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

namespace TestProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorisationPage.xaml
    /// </summary>
    public partial class AutorisationPage : Page
    {
        MainWindow MainWindow;
        public AutorisationPage(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Container.Navigate(new ProductsPage());
        }

        private void btnInn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(login.Text) || !string.IsNullOrEmpty(password.Password))
            {
                User user = new User();
                user = DBContext.GetContex().User.Where(p => p.Password == password.Password && p.Login == login.Text).FirstOrDefault();
                if(user != null) 
                {
                    MainWindow.Container.Navigate(new Menu(user, MainWindow));
                }
                else 
                {
                    MessageBox.Show("Введены неверные данные!");
                }
            }
            else 
            {
                MessageBox.Show("Не все поля заполненны данными!");
            }
        }
    }
}
