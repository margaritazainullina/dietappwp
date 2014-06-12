using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace DietApp
{
    public partial class AddProduct : PhoneApplicationPage
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                Product p = new Product(name.Text, listBox1.SelectedIndex, Convert.ToDouble(protein.Text), Convert.ToDouble(fat.Text),
                    Convert.ToDouble(carbohydrates.Text), Convert.ToInt32(calories.Text), Convert.ToInt32(cost.Text), Convert.ToDouble(acidity.Text), listBox2.SelectedIndex);

                NavigationService.Navigate(new Uri("/ProductList.xaml", UriKind.Relative));
                Db.Products.InsertOnSubmit(p);
                Db.SubmitChanges();
            }
        }

    }
}