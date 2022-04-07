using AjaxTools.WebServer;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AjaxTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSendData_Click(object sender, RoutedEventArgs e)
        {
            string _url = txtUrlAddress.Text;
            string _method = _arrSendMethod[combSendMethod.SelectedIndex];
            string _sendInformation = txtSendData.Text;

            if(0 == _url.Length)
            {
                txtReceiveData.Text = "请输入 URL 地址！";
                return;
            }

            AjaxServer ajax = new AjaxServer(_url, _method, _sendInformation);
            ajax.ContentType = _contentType;

            if (!ajax.Send())
            {
                txtReceiveData.Text = "执行失败！原因：" + ajax.Error;
            }
            else
            {
                txtReceiveData.Text = ajax.Value;
            }
        }


        private void RadSelectCT_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radSelectCT = sender as RadioButton;

            if (true == radSelectCT.IsChecked)
            {
                _contentType = radSelectCT.Content.ToString();
            }
        }

        private string _contentType = "";
        private string[] _arrSendMethod = new string[] { "GET", "POST", "PUT", "DELETE" };
    }
}
