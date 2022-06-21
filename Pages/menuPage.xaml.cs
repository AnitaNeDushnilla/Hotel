using HotelISP9_13.HelperClasses;
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

namespace HotelISP9_13.Pages
{
    /// <summary>
    /// Логика взаимодействия для menuPage.xaml
    /// </summary>
    public partial class menuPage : Page
    {
        public menuPage()
        {
            InitializeComponent(); 
        }

        private void btnHotel_Click(object sender, RoutedEventArgs e)
        {
            Class1.frame.Navigate(new HotelPage());
        }

        private void btnWorker_Click(object sender, RoutedEventArgs e)
        {
            Class1.frame.Navigate(new WorkersPage());
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            Class1.frame.Navigate(new ClientPage());
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Class1.frame.Content = null;
        }
    }
}
