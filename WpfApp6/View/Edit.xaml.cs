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
using WpfApp6.ViewModel;
using WpfApp6.View;

namespace WpfApp6.View
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        #region Private Variables
        private readonly PersonsViewModel pwm;
        #endregion

        public Page3()
        {
            InitializeComponent();
            pwm = new PersonsViewModel();
            DataContext = pwm;
        }
    }
}
