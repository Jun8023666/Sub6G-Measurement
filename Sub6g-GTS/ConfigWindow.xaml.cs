using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO.Ports;




namespace Sub6g_GTS
{
    /// <summary>
    /// ConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
            ///导入保存的IP和端口信息
            NETLocalPort_txt.Text = INI.ReadIni("section2", "key14");
            NETRemotePort_txt.Text = INI.ReadIni("section2", "key15");
            NETRemoteIP_txt.Text = INI.ReadIni("section2", "key16");
            
            WIFIKey_txt.Text = INI.ReadIni("section3", "key18");
            WIFISSID_Cbox.Text = INI.ReadIni("section3", "key19");
            //记住WIFI板块之前添加的SSID
            string i = INI.ReadIni("section4", "i");
            for (int j = 0; j < int.Parse(i); j++)
            {
                WIFISSID_Cbox.Items.Add(INI.ReadIni("section4", j.ToString()));
            }
            ///给USB_Cbox添加串口
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {//获取有多少个COM口  
                USBPort_Cbox.Items.Add(s);
            }


            ////给NET_Cbox添加IP地址
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    string AddressIP = _IPAddress.ToString();
                    NETLocalIP_Cbox.Items.Add(AddressIP);
                    
                }
            }

        }
        private void Config_OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            ///保存输入的IP和端口信息
           INI.WriteIni("section2", "key14", NETLocalPort_txt.Text);
           INI.WriteIni("section2", "key15", NETRemotePort_txt.Text);
           INI.WriteIni("section2", "key16", NETRemoteIP_txt.Text);          
           INI.WriteIni("section3", "key18", WIFIKey_txt.Text);
           
            try
            {
                for (int i = 0; i <= WIFISSID_Cbox.Items.Count; i++)
                {
                    INI.WriteIni("section4", i.ToString(), WIFISSID_Cbox.Items[i].ToString());
                }
                
            }
            catch { INI.WriteIni("section4", "i", WIFISSID_Cbox.Items.Count.ToString()); }

        }

        private void Config_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        //Connect按钮
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int recv;
            byte[] data = new byte[1024];

            IPAddress LocateIP = IPAddress.Parse(NETLocalIP_Cbox.Text);
            IPEndPoint LocatePoint = new IPEndPoint(LocateIP, Convert.ToInt32(NETLocalPort_txt.Text));
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            newsock.Bind(LocatePoint);

            IPAddress RemoteIP = IPAddress.Parse(NETRemoteIP_txt.Text);
            IPEndPoint RemotePoint = new IPEndPoint(RemoteIP, Convert.ToInt32(NETRemotePort_txt.Text));
            EndPoint Remote = (EndPoint)(RemotePoint);

            string welcome = "12345678";
            data = Encoding.ASCII.GetBytes(welcome);

            newsock.SendTo(data, data.Length, SocketFlags.None, Remote);
            newsock.ReceiveTimeout = 100;

            data = new byte[1024];
            //设置标志位看是否成功接收
            int flag = 0;
            //发送接收信息
            try { 
                    recv = newsock.ReceiveFrom(data, ref Remote);
                 }
            catch 
            {
                flag = 1;
            }
            if (flag==0)
            {
                MessageBox.Show("Connect Success...！");
            }
            else
            { 
                MessageBox.Show("Connect Fail...！");
            }
             newsock.Close();
            }

        private void WIFIAdd_Click(object sender, RoutedEventArgs e)
        {
            string WIFISSID = WIFISSID_txt.Text;
            WIFISSID_Cbox.Items.Add(WIFISSID);
        }

        private void WIFIDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WIFISSID_Cbox.Items.RemoveAt(WIFISSID_Cbox.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("Delete error！");
            }
        }

        private void USBConnect_btn_Click(object sender, RoutedEventArgs e)
        {
            SerialPort sp1 = new SerialPort();
            try
            {
                //设置串口号  
                string serialName = USBPort_Cbox.SelectedItem.ToString();
                sp1.PortName = serialName;
            }
            catch
            {
                MessageBox.Show("未检测到串口!");
            }
            sp1.BaudRate = 115200;
            sp1.DataBits = 8;
            sp1.StopBits = StopBits.One;
            sp1.Parity = Parity.None;
            try
            {
                sp1.Open();     //打开串口  
            }
            catch
            {
                MessageBox.Show("串口打开失败");
            }
            if (sp1.IsOpen)
            { 
            sp1.WriteLine("1111");
            sp1.ReadTimeout = 100;    //写入数据  
            int Flag = 0;
            try
            {
                string Rcv = sp1.ReadLine();                
            }
            catch
            {
                Flag = 1;
            }
            if (Flag == 0)
            {
                MessageBox.Show("Connect Success...！");
                
            }
            else
            {
                MessageBox.Show("Connect Failed...！");
            }
            sp1.Close();
            }
        }


    }
}
