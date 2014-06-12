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
    public partial class AddProductToDish : PhoneApplicationPage
    {
        List<Product> l;
       
        int SelectedIndex = 0;
        public AddProductToDish()
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
            if (SelectedIndex >= 0)
            {
                if (l.ElementAt(SelectedIndex).MeasureID == 0)
                    measureTB.Text = " г.";
                if (l.ElementAt(SelectedIndex).MeasureID == 1)
                    measureTB.Text = " шт.";
                if (l.ElementAt(SelectedIndex).MeasureID == 2)
                    measureTB.Text = " мл.";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                DishProduct dp = new DishProduct() { DId = AddDish.d.DishID, Product = l[SelectedIndex], Quantity = Convert.ToInt32(textBox1.Text) };
                Db.DishProducts.InsertOnSubmit(dp);
                AddDish.d.DishProducts.Add(dp);
                Db.SubmitChanges();
                NavigationService.Navigate(new Uri("/AddDish.xaml", UriKind.Relative));
            }
        }
    }
}