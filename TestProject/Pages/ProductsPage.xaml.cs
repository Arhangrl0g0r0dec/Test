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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public List<Products> products { get; set; }
        public List<Manufacturer> manufacturers { get; set; }
        public ProductsPage()
        {
            InitializeComponent();
            
            products = DBContext.GetContex().Products.ToList();
            listBoxProd.ItemsSource = products;
            manufacturers = DBContext.GetContex().Manufacturer.ToList();
            manufacturers.Insert(0, new Manufacturer
            {
                Id = 1,
                Name = "Все производители",
                Phone = ""
            });
            comboManufact.ItemsSource = manufacturers;
        }

        public void UpdateProduct() 
        {
            products.Clear();
            products = DBContext.GetContex().Products.ToList();
            if(comboManufact.SelectedIndex == 0) 
            {
                products = DBContext.GetContex().Products.Where(p => p.Manufacturer == p.Manufacturer).ToList();
            }
            else if(comboManufact.SelectedItem != null && comboManufact.SelectedIndex != 0)
            {
                products = products.Where(p => p.Manufacturer == (Manufacturer)comboManufact.SelectedItem).ToList();
            }

            if (!string.IsNullOrEmpty(txtSearch.Text)) 
            {
                products = products.Where(p => p.Title.ToLower().Contains(txtSearch.Text.ToLower()) || p.NumProduct.ToString().ToLower().Contains(txtSearch.Text.ToLower()) || p.Manufacturer.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            if(sortCombo.SelectedIndex == 0) 
            {
                products = products.Where(p => p.Price == p.Price).ToList();
            }
            else if (sortCombo.SelectedIndex == 1) 
            {
                products = products.OrderBy(p => p.Price).ToList();
            }
            else if (sortCombo.SelectedIndex == 2)
            {
                products = products.OrderByDescending(p => p.Price).ToList();
            }

            listBoxProd.ItemsSource = products;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void comboManufact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void sortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }
    }
}
