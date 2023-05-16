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
using System.Windows.Shapes;
using TestProject.Pages;

namespace TestProject
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        ProductPageForEdit ProductPageForEdit;
        public Products Products { get; set; }
        public List<Manufacturer> manufacturers { get; set; }

        public AddProduct(Products products, ProductPageForEdit pageForEdit)
        {
            InitializeComponent();
            ProductPageForEdit = pageForEdit;
            ProductPageForEdit.IsOpened = true;
            Products = products;
            manufacturers = DBContext.GetContex().Manufacturer.ToList();
            comboManufact.ItemsSource = manufacturers;

            if (products != null) 
            {
                DataContext = products;
            }
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (titleProd.Text != null && descProd.Text != null && countProd.Text != null && priceProd.Text != null && numProd.Text != null && comboManufact.SelectedItem != null && unitProd.Text != null && Products == null)
                {
                    Products products = new Products()
                    {
                        Title = titleProd.Text,
                        Description = descProd.Text,
                        Count = Convert.ToInt32(countProd.Text),
                        Price = Convert.ToDecimal(priceProd.Text),
                        NumProduct = Convert.ToInt32(numProd.Text),
                        UnitOfMeasurement = unitProd.Text,
                        Manufacturer = (Manufacturer)comboManufact.SelectedItem
                    };

                    DBContext.GetContex().Products.Add(products);
                    DBContext.GetContex().SaveChanges();
                    MessageBox.Show("Продукт успешно добавлен!");
                    this.Close();
                }
                else if (titleProd.Text != null && descProd.Text != null && countProd.Text != null && priceProd.Text != null && numProd.Text != null && comboManufact.SelectedItem != null && unitProd.Text != null && Products != null) 
                {
                    Products.Manufacturer = (Manufacturer)comboManufact.SelectedItem;
                    DBContext.GetContex().SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!");
                }
                else
                {
                    MessageBox.Show("Не все данные были заполнены!");
                }
                ProductPageForEdit.UpdateProduct();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Данные имеют не верный формат! Проверьте верны ли знаки и символы которые вы ввели! " + ex.ToString());
            }
           
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ProductPageForEdit.IsOpened = false;
        }
    }
}
