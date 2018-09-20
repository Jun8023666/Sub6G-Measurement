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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindow configWindow = new ConfigWindow();
            bool?b = configWindow.ShowDialog();
            if (b == true)
            { MessageBox.Show("确定了！"); }
            else if (b == false)
            { MessageBox.Show("取消了！"); }



        }
    }

  

      



    
      



    }

  

   





   

  
 
 






