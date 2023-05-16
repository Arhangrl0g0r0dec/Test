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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        MainWindow MainWindow;
        User User;
        public Menu(User user, MainWindow mainWindow)
        {
            InitializeComponent();
            User = user;
            role.Text = User.Role.Title;
            name.Text = user.Name;
            surname.Text = user.Surname;
            patronimic.Text = user.Patronimic;
            MainWindow = mainWindow;
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            if (User.RoleId == 3) 
            {
                MainWindow.Container.Navigate(new ProductPageForEdit(MainWindow, User));
            }
            else 
            {
                MainWindow.Container.Navigate(new ProductsPage());
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Container.Navigate(new AutorisationPage(MainWindow));
        }
    }
}
