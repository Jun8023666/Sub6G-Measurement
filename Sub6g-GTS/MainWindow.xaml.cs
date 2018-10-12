using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sub6g_GTS
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ////在串口打开时将控件已保存信息导入
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += Window_Closing;
            UEInfo_Cbox.Text=INI.ReadIni("section1", "key1");
            ConfigDLOB_Cbox.Text= INI.ReadIni("section1", "key2");
            ConfigULOB_Cbox.Text= INI.ReadIni("section1", "key3");
            ConfigDLCBW_Cbox.Text = INI.ReadIni("section1", "key4");
            ConfigULCBW_Cbox.Text = INI.ReadIni("section1", "key5");
            ConfigDLCha_txt.Text = INI.ReadIni("section1", "key6");
            ConfigULCha_txt.Text = INI.ReadIni("section1", "key7");
            ConfigDLFre_txt.Text = INI.ReadIni("section1", "key8");
            ConfigULFre_txt.Text = INI.ReadIni("section1", "key9");
            ConfigDLRSEPRF_txt.Text = INI.ReadIni("section1", "key10");
            ConfigDLFCBWP_txt.Text = INI.ReadIni("section1", "key11");
            ConfigULOLP_txt.Text = INI.ReadIni("section1", "key12");
            ConfigULCLP_txt.Text = INI.ReadIni("section1", "key13");

            BindingShow();
            WaveFile_Dir.SelectionChanged += WaveFile_Dir_SelectionChanged;

            Dir_Pause.Visibility = Visibility.Hidden;
            LightOn_ima.Visibility = Visibility.Hidden;
            LightOff_ima.Visibility = Visibility.Hidden;
        }
        //在串口关闭时将控件输入信息保存
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)

        {
            SaveData.savedata_g.UEInfo_cboxs = UEInfo_Cbox.Text;
            INI.WriteIni("section1","key1", SaveData.savedata_g.UEInfo_cboxs);
            INI.WriteIni("section1", "key2", ConfigDLOB_Cbox.Text);
            INI.WriteIni("section1", "key3", ConfigULOB_Cbox.Text);
            INI.WriteIni("section1", "key4", ConfigDLCBW_Cbox.Text);
            INI.WriteIni("section1", "key5", ConfigULCBW_Cbox.Text);
            INI.WriteIni("section1", "key6", ConfigDLCha_txt.Text);
            INI.WriteIni("section1", "key7", ConfigULCha_txt.Text);
            INI.WriteIni("section1", "key8", ConfigDLFre_txt.Text);
            INI.WriteIni("section1", "key9", ConfigULFre_txt.Text);
            INI.WriteIni("section1", "key10",ConfigDLRSEPRF_txt.Text);
            INI.WriteIni("section1", "key11", ConfigDLFCBWP_txt.Text);
            INI.WriteIni("section1", "key12", ConfigULOLP_txt.Text);
            INI.WriteIni("section1", "key13", ConfigULCLP_txt.Text);

        }
        //Interface Config按键
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindow configWindow = new ConfigWindow();
            bool?b = configWindow.ShowDialog();
            if (b == true)
            { MessageBox.Show("Configuration Success...！"); }
            else if (b == false)
            { MessageBox.Show("Configuration Cancered...！"); }

        }

        private void WaveFile_Dir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindingShow();
        }

        //BindingShow()
        //Used for change between Local file and Instrument Files
        private void BindingShow()
        {
            if (WaveFile_Dir.SelectedIndex == 0)
            {
                DirOpen.Visibility = Visibility.Visible;
                DirSend.Visibility = Visibility.Visible;
                Dir_text.Visibility = Visibility.Visible;
                Dir_Com.Visibility = Visibility.Hidden;
                DirRefresh.Visibility = Visibility.Hidden;
            }
            else
            {
                DirOpen.Visibility = Visibility.Hidden;
                DirSend.Visibility = Visibility.Hidden;
                Dir_text.Visibility = Visibility.Hidden;
                Dir_Com.Visibility = Visibility.Visible;
                DirRefresh.Visibility = Visibility.Visible;
            }
        }
        //open file按键按下，text接收路径
        private void DirOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string path = ofd.FileName;
            Dir_text.Text = path;


        }
        //start 按键按下，Pause显示
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dir_Pause.Visibility = Visibility.Visible;
            Dir_Start.Visibility = Visibility.Hidden;
            LightOn_ima.Visibility = Visibility.Visible;
            LightOff_ima.Visibility = Visibility.Hidden;
        }

        private void Dir_Pause_Click(object sender, RoutedEventArgs e)
        {
            Dir_Pause.Visibility = Visibility.Hidden;
            Dir_Start.Visibility = Visibility.Visible;
            LightOn_ima.Visibility = Visibility.Hidden;
            LightOff_ima.Visibility = Visibility.Visible;
        }
    }

  

      



    
      



    }

  

   





   

  
 
 






