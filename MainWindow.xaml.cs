using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace kaoshi
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Email _mail;
        public MainWindow()
        {
            InitializeComponent();
            _mail = new Email();
            this.DataContext = _mail;
        }

   

        private void ShowFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,//该值确定是否可以选择多个文件
                Title = "请选择文件夹",
                Filter = "所有文件(*.*)|*.*",
                
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _mail.PictureFileName = dialog.FileName;
            }
        }

        private void GetZhengWen(object sender, RoutedEventArgs e)
        {
            /*
            Opentext fm = new Opentext();
            fm.Show();
            */

            
            string filePath="";
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,//该值确定是否可以选择多个文件
                Title = "请选择文件夹",
                Filter = "所有文件(*.*)|*.*"
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = dialog.FileName;
            }
            else
            {
                System.Windows.MessageBox.Show("文件不存在");
            }
            //文件路径
            
 
            if (File.Exists(filePath))
                {
                    string contents = File.ReadAllText(filePath);
                    _mail.Zhengwen = contents;
            }
            
     
        }

        private void CheckAll(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"[a-zA-Z0-9]+@[a-zA-z]+\.com$");
            MatchCollection matchs = regex.Matches(_mail.Dress);
            if (!regex.IsMatch(_mail.Dress)) {
                System.Windows.MessageBox.Show("邮件名错误！");
            }
            else if(_mail.Zhengwen==string.Empty)
            {
                System.Windows.MessageBox.Show("未输入正文");
            }
            else if (_mail.PictureFileName==string.Empty)
            {
                System.Windows.MessageBox.Show("未插入图片");
            }
            else {
                System.Windows.MessageBox.Show("已完成");
            }
        }
    }
}
