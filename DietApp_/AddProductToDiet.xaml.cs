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
using DietApp;

namespace DietApp_
{
    public partial class AddProductToDiet : PhoneApplicationPage
    {
        List<Product> l; 
        int SelectedIndex = 0;
        public AddProductToDiet()
        {
            InitializeComponent();
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Product> ProductQuery = from Product in Db.Products select Product;
                l = ProductQuery.ToList();
                var list = ProductQuery.Select(s => new { s.Name }).ToList();
                List<String> ll = new List<string>();
                foreach (var s in list)
                {
                    String ss = s.ToString().Replace("{ Name = ", "");
                    ss = ss.Replace("}", "");
                    ll.Add(ss);
                }
                listBox4.ItemsSource = ll;
            }
        }

        private void listBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedIndex = listBox4.SelectedIndex;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                DietProduct dp = new DietProduct() { DId = AddDiet.d.DietID, Product = l[SelectedIndex] };
                Db.DietProducts.InsertOnSubmit(dp);
                AddDiet.d.DietProducts.Add(dp);
                Db.SubmitChanges();
                NavigationService.Navigate(new Uri("/AddDiet.xaml", UriKind.Relative));
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddDiet.xaml", UriKind.Relative)); 
        }
    }
}