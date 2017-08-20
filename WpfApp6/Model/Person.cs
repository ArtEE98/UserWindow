using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp6.Model;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using WpfApp6.ViewModel;

namespace WpfApp6.Model
{
    class Person : INotifyPropertyChanged
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("id"); }
        }
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged("login"); }
        }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }
        private string lastName;
        public string LastName
        {
            get
            {
                if (lastName == null)
                    lastName = "";
                return lastName;
            }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }
        
        private string pass;
        public string Pass
        {
            get { return pass; }
            set { pass = value; OnPropertyChanged("pass"); }
        }
        private string age;
        public string Age
        {
            get
            {
                if (age == null)
                    age = "";
                return age;
            }
            set { age = value; OnPropertyChanged("age"); }
        }
        private string sex;
        public string Sex
        {
            get
            {
                if (sex == null)
                    sex="";
                return sex;
            }
            set { sex = value; OnPropertyChanged("Sex"); }
        }
        public static Uri Standart_URL = new Uri("pack://application:,,,/WpfApp6;component/Res/standart.jpg");// Create standar Image Element
        private BitmapImage image;
        public BitmapImage Image
        {
            get
            {
                if (image == null)
                    image = new BitmapImage(Standart_URL);
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }
        
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string param)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("param"));
        }
    }
    
}
