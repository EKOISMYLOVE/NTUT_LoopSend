using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace LoopSend
{
    public partial class Form1 : Form
    {
        public string[] deviceList = { };
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long x);
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long x);


        public Form1()
        {

            InitializeComponent();

            var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort");

            foreach (ManagementObject port in searcher.Get())
            {
                // ex: COM7
                string name = port.GetPropertyValue("DeviceID").ToString();

                Array.Resize(ref deviceList, deviceList.Length + 1);
                deviceList[deviceList.Length - 1] = name;

                // ex: Arduino Uno (COM7)
                string description = port.GetPropertyValue("Caption").ToString();

                //MessageBox.Show(theSerialNumberObjectQuery["SerialNumber"].ToString());

                // do what ever you want...  
                selectBoard.Items.Add(description);
                
            }
            try
            {
                selectBoard.SelectedIndex = 0;
            }
            catch (Exception)
            {
                selectBoard.SelectedIndex = -1;
                throw;
            }
            
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            SendLog.AppendText("[*] 選擇Port為 " + deviceList[selectBoard.SelectedIndex].ToString()+ " 的開發版開始傳輸" + "\r\n");
            //SendLog.AppendText("[*] 選擇Port為 " + "COM9" + " 的開發版開始傳輸" + "\r\n");
            //SendLog.AppendText(deviceList[selectBoard.SelectedIndex].ToString());

            ConnectSerialDevice CSD = new ConnectSerialDevice(deviceList[selectBoard.SelectedIndex].ToString(), this);
            CSD._receiveLog = ReceiveLog;
            

            SendLog.AppendText("[*] 間隔時間為 : " + intervalTime.Text + "\r\n");
            SendLog.AppendText("[*] 傳輸時間為 : " + sendTime.Text  + "\r\n");

            int count = 1;
            //建立連線
            CSD.Console_Connect();

            if (disableLog.Checked)
            {
                for (int i = 0; i < Int32.Parse(sendTime.Text); i++)
                {
                    string data = "gatt get-data " + sendData.Text + "\r\n";
                    CSD.SendData(sendData.Text);
                    //SendLog.AppendText("[*] 送出第" + count.ToString() + "筆資料:" + sendData.Text + "\r\n");
                    Thread.Sleep(Int32.Parse(intervalTime.Text));
                }
            }
            else
            {
                long freq = 0;
                long start_Value = 0;
                long stop_Value = 0;
                //QueryPerformanceFrequency(ref freq);
                //QueryPerformanceCounter(ref start_Value);
                
                for (int i = 0; i < Int32.Parse(sendTime.Text); i++)
                {
                    //string data = "bt init";
                    string data = "gatt get-data " + sendData.Text + "\r\n";
                    //sendData.Text = "gatt get-data " + sendData.Text;


                    QueryPerformanceFrequency(ref freq);
                    QueryPerformanceCounter(ref start_Value);

                    CSD.SendData(data);
                    
                    CSD.SendData(data);
                    CSD.SendData(data);
                    CSD.SendData(data);
                    CSD.SendData(data);
                    CSD.SendData(data);
                    CSD.SendData(data);
                    CSD.SendData(data);
                    /*
                    CSD.SendData(data);
                    
                    CSD.SendData(data);
                    */

                    QueryPerformanceCounter(ref stop_Value);
                    var time = (stop_Value - start_Value) / (double)freq * 1000;
                    SendLog.AppendText("[*] 花費時間 : " + time.ToString());



                    SendLog.AppendText("[*] 送出第" + count.ToString() + "筆資料:" + data + "\r\n");
                    Thread.Sleep(Int32.Parse(intervalTime.Text));
                    count++;


                    

                }
                //QueryPerformanceCounter(ref stop_Value);
                //var time = (stop_Value - start_Value) / (double)freq * 1000;
                //SendLog.AppendText("[*] 花費時間 : " + time.ToString());
            }

            
            SendLog.AppendText("[*] 執行gatt metrics result " + "\r\n");
            CSD.SendData("gatt metrics result" + "\r\n");
            Thread.Sleep(1000);
            CSD.SendData("gatt metrics result" + "\r\n");
            SendLog.AppendText("[*] 傳輸完畢。" + "\r\n");
            CSD.CloseComport();

        }

        private void SendLog_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class ConnectSerialDevice
    {
        Form Form1;
        private SerialPort My_SerialPort;
        private bool Console_receiving = false;
        private Thread t;

        public RichTextBox _sendLog;
        public RichTextBox _receiveLog;
        delegate void Display(RichTextBox rtb, string buffer);

        private string COM;
        private Int32 baud = 115200;
        private string buf = "";
        public string temp = "";
        public string address = "--------------------";//抓到要連線的address
        public bool role = false;//master為true

        public ConnectSerialDevice(string COM_Port_Number, Form myForm)
        {
            COM = COM_Port_Number;
            Form1 = myForm;
        }


        //public void Console_Connect(string COM, Int32 baud)
        public void Console_Connect()
        {
            try
            {
                My_SerialPort = new SerialPort();

                if (My_SerialPort.IsOpen)
                {
                    My_SerialPort.Close();
                }

                //設定 Serial Port 參數
                My_SerialPort.PortName = COM;
                My_SerialPort.BaudRate = baud;
                My_SerialPort.DataBits = 8;
                My_SerialPort.StopBits = StopBits.One;

                if (!My_SerialPort.IsOpen)
                {
                    //開啟 Serial Port
                    My_SerialPort.Open();

                    Console_receiving = true;

                    //開啟執行續做接收動作
                    t = new Thread(DoReceive);
                    t.IsBackground = true;
                    t.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DoReceive()
        {
            Byte[] buffer = new Byte[1024];

            try
            {
                while (Console_receiving)
                {
                    if (My_SerialPort.BytesToRead > 0)
                    {
                        Int32 length = My_SerialPort.Read(buffer, 0, buffer.Length);

                        //string buf = Encoding.ASCII.GetString(buffer);
                        this.buf = Encoding.ASCII.GetString(buffer);


                        Array.Resize(ref buffer, length);
                        Display d = new Display(ConsoleShow);
                        Form1.Invoke(d, new Object[] { _receiveLog, buf });
                        Array.Resize(ref buffer, 1024);

                    }
                    Thread.Sleep(20);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("[!]" + ex.Message);
            }
        }

        public void ConsoleShow(RichTextBox rtb, string buffer)
        {
            /*
            string target = "slave1";//要判斷的名稱

            if (role)
            {
                address = MasterGetMACAddress(target, buffer);
                if (address.Length == 26)
                {
                    rtb.AppendText("\r\n[*]取得 " + target + "的 MAC address : " + address + "\r\n");

                    SendData(Encoding.ASCII.GetBytes("bt connect " + address + "\n"));
                    address = "";
                }
            }
            */
            rtb.AppendText(buffer);
            /*
            bool b = buffer.Contains(target);//判斷是否有找到目標字串
            if (b)
            {
                int index = buffer.IndexOf(target);//index為找到字串的起始位置
                if (index > 52)//避免抓到bt name xxxxx的case
                {
                    address = buffer.Substring(index - 52, 26);//我人工判讀要抓的字串位置以及長度
                    if(role)//如果為master要執行
                        SendData(Encoding.ASCII.GetBytes("bt connect " + address + "\r"));
                }
            }
            */

            //rtb.AppendText(buffer);
            //rtb.ScrollToCaret();
            //rtb.AppendText("[*]取得 " + target + " MAC address : " + address + "\r\n");
        }

        public string MasterGetMACAddress(string slaveName, string buffer)
        {
            string target = slaveName;//要判斷的名稱
            string scanResult = buffer;
            string slaveAddress = "";

            bool b = scanResult.Contains(target);//判斷是否有找到目標字串
            if (b)
            {
                int index = scanResult.IndexOf(target);//index為找到字串的起始位置
                if (index > 52)//避免抓到bt name xxxxx的case
                {
                    slaveAddress = scanResult.Substring(index - 52, 26);//我人工判讀要抓的字串位置以及長度                        
                }
            }
            return slaveAddress;
        }

        public void SendData(Object sendBuffer)
        {

            if (sendBuffer != null)
            {
                //Byte[] buffer = sendBuffer as Byte[];
                Byte[] buffer = Encoding.ASCII.GetBytes(sendBuffer.ToString());

                try
                {
                    My_SerialPort.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    CloseComport();
                    //MessageBox.Show(ex.Message);
                }
            }
        }
        public void CloseComport()
        {
            try
            {
                My_SerialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string getBuffer()
        {

            return this.temp;
        }


    }
}
