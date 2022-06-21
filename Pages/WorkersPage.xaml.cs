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
using HotelISP9_13.HelperClasses;
using HotelISP9_13.EF;

namespace HotelISP9_13.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        List<Employee> employees = new List<Employee>();
        List<string> sort = new List<string>()
        {
            "По умолчанию",
            "По фамилии",
            "По имени",
            "По должности",
            "По логину"
        };
        public WorkersPage()
        {
            InitializeComponent();

            

            cmbSort.ItemsSource = sort;
            cmbSort.SelectedIndex = 0;
            GetList();

        }
        public void GetList()
        {
            employees = AppData.context.Employee.ToList();

            //Поиск
            employees = employees.
                Where(i => i.LastName.ToLower().Contains(tbxSearch.Text.ToLower())
                || i.FirstName.ToLower().Contains(tbxSearch.Text.ToLower())).ToList();

            int selectedItemSort = cmbSort.SelectedIndex;
            //Сортировка
            switch (selectedItemSort)
            {
                case 0:
                    employees = employees.OrderBy(i => i.IdEmployee).ToList();
                     break;
                case 1: 
                    employees = employees.OrderBy(i => i.LastName).ToList();
                    break;
                case 2:
                    employees = employees.OrderBy(i => i.FirstName).ToList();
                    break;
                case 3:
                    employees.OrderBy(i => i.IdRole).ToList();
                    break;
                case 4:
                    employees= employees.OrderBy(i => i.Login).ToList();
                    break;


                default:
                    employees = employees.OrderBy(i => i.IdEmployee).ToList();
                    break;
            }


            lvWorkers.ItemsSource = employees;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Class1.frame.Navigate(new AddEditEmpoyees());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem();
        }
        private void DeleteItem()
        {
            if (lvWorkers.SelectedItem is Employee)
            {
                var empDel = lvWorkers.SelectedItem as Employee;
                AppData.context.Employee.Remove(empDel);
                AppData.context.SaveChanges();
                GetList();
            }
            else
            {
                MessageBox.Show("Поле не выбрано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var res = MessageBox.Show("Удалить сотрудника?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res != MessageBoxResult.Yes)
            {
                return;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var empEdit = lvWorkers.SelectedItem as Employee;
            Class1.frame.Navigate(new AddEditEmpoyees(empEdit));
        }

        private void lvWorkers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteItem();
            }
        }

        private void lvWorkers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var empEdit = lvWorkers.SelectedItem as Employee;
            Class1.frame.Navigate(new AddEditEmpoyees(empEdit));
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetList();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetList();
        }
    }
}
