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
    /// Логика взаимодействия для AddEditEmpoyees.xaml
    /// </summary>
    public partial class AddEditEmpoyees : Page
    {
       private bool EditEmp = false;

       private Employee editEmployee;


        public AddEditEmpoyees()
        {
            InitializeComponent();

            cmbRole.ItemsSource = AppData.context.Role.ToList();
            cmbRole.DisplayMemberPath = "NameRole";
            cmbRole.SelectedIndex = 0;
        }

        public AddEditEmpoyees(Employee employee)
        {
            InitializeComponent();
            editEmployee = employee;
            tbTitle.Text = "Изменить сотрудника";

            tbxLastName.Text = employee.LastName;
            tbxName.Text= employee.FirstName;
            tbxlogin.Text = employee.Login ;
            pswPass.Password = employee.Password;
            tbxPhone.Text = employee.Phone;
            tbxMail.Text =employee.Email;
            

            cmbRole.ItemsSource = AppData.context.Role.ToList();
            cmbRole.DisplayMemberPath = "NameRole";
            cmbRole.SelectedIndex = employee.IdRole - 1;

            EditEmp = true;
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(tbxLastName.Text))
            {
                MessageBox.Show("Поле Фамилия не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbxLastName.Text.Contains("1") | tbxLastName.Text.Contains("2") | tbxLastName.Text.Contains("3") | tbxLastName.Text.Contains("4") | tbxLastName.Text.Contains("5") 
               | tbxLastName.Text.Contains("6") | tbxLastName.Text.Contains("7") | tbxLastName.Text.Contains("8") | tbxLastName.Text.Contains("9") | tbxLastName.Text.Contains("0"))
            {
                MessageBox.Show("Поле Фамилия не должно содержать цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return ;
            }

            if (string.IsNullOrWhiteSpace(tbxName.Text))
            {
                MessageBox.Show("Поле имя не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbxName.Text.Contains("1") | tbxLastName.Text.Contains("2") | tbxLastName.Text.Contains("3") | tbxLastName.Text.Contains("4") | tbxLastName.Text.Contains("5")
                | tbxLastName.Text.Contains("6") | tbxLastName.Text.Contains("7") | tbxLastName.Text.Contains("8") | tbxLastName.Text.Contains("9") | tbxLastName.Text.Contains("0"))
            {
                MessageBox.Show("Поле имя не должно содержать цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbxlogin.Text))
            {
                MessageBox.Show("Поле Login не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(pswPass.Password))
            {
                MessageBox.Show("Поле Пароль не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var a1 = tbxMail.Text.Split('@');
            if (a1.Length == 2)
            {
                var a2 = a1[1].Split('.');
                if (a2.Length == 2)
                {

                }
                else
                {
                    MessageBox.Show("Неверный формат Email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Неверный формат Email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (EditEmp)
            {
                editEmployee.LastName = tbxLastName.Text;
                editEmployee.FirstName = tbxName.Text;
                editEmployee.Login = tbxlogin.Text;
                editEmployee.Password = pswPass.Password;
                editEmployee.Phone = tbxPhone.Text;
                editEmployee.Email = tbxMail.Text;


                    cmbRole.ItemsSource = AppData.context.Role.ToList();
                    cmbRole.DisplayMemberPath = "NameRole";
                    cmbRole.SelectedIndex = editEmployee.IdRole + 1;
                    AppData.context.SaveChanges();
                
                
                MessageBox.Show("Сотрудник изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Class1.frame.Navigate(new WorkersPage());
            }
            else
            {
                    Employee employee = new Employee();

                    employee.LastName = tbxLastName.Text;
                    employee.FirstName = tbxName.Text;
                    employee.Login = tbxlogin.Text;
                    employee.Password = pswPass.Password;
                    employee.Phone = tbxPhone.Text;
                    employee.Email = tbxMail.Text;
                    employee.IdRole = cmbRole.SelectedIndex + 1;

                    AppData.context.Employee.Add(employee);
                    AppData.context.SaveChanges();
                
                MessageBox.Show("Сотрудник добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Class1.frame.Navigate(new WorkersPage());
            }  
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Class1.frame.GoBack();
        }
    }

}
    

