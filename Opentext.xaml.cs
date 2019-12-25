using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kaoshi
{
    /// <summary>
    /// Opentext.xaml 的交互逻辑
    /// </summary>
    public partial class Opentext : Window, INotifyPropertyChanged
    {
        
        public Opentext()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public string FileName { get => _FileName; set { if (_FileName == value) return; _FileName = value; OnPropertyChanged(nameof(FileName)); } }
        private string _FileName;

        public Encoding CurrentEncoding { get => _CurrentEncoding; set { if (_CurrentEncoding == value) return; _CurrentEncoding = value; OnPropertyChanged(nameof(CurrentEncoding)); } }
        private Encoding _CurrentEncoding;

        public Encoding[] Encodings => _Encodings;
        private readonly static Encoding[] _Encodings = new Encoding[] { Encoding.ASCII, Encoding.BigEndianUnicode, Encoding.Default, Encoding.Unicode, Encoding.UTF32, Encoding.UTF7, Encoding.UTF8 };

        public string Preview { get => _Preview; set { if (_Preview == value) return; _Preview = value; OnPropertyChanged(nameof(Preview)); } }

        public string Zhengwen { get; private set; }

        private string _Preview;

        private void OnPropertyChanged(string aPropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;

        private void ShowFile(object sender, RoutedEventArgs e)
        {
            string filePath = "";
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
                Zhengwen = contents;
            }
        }
    }
}
