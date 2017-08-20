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

namespace WpfApp6.View
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        #region Private Variables
        private readonly PersonsViewModel pwm;
        #endregion

        public Page2()
        {
            InitializeComponent();
            pwm = new PersonsViewModel();
            DataContext = pwm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            t1.Clear();t2.Clear();t3.Clear();t5.Clear();t4.SelectedValue=-1; t6.Clear();
        }
    }
}
