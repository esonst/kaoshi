using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace kaoshi
{
    class Email : INotifyPropertyChanged
    {
        private string dre = "";
        private string data = "";
        private string image_dre = "";
        public event PropertyChangedEventHandler PropertyChanged;
        public string Dress
        {
            get { return dre; }
            set
            {
                dre = value;
            }
        }
        public string Zhengwen
        {
            get { return data; }
            set
            {
                if (data == value) return;
                data = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Zhengwen"));
            }
        }
        public string PictureFileName
        {
            get { return image_dre; }
            set
            {
                if (image_dre == value) return;
                image_dre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PictureFileName"));
            }
        }

    }
}
