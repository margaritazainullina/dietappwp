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
            int i = listBox4.SelectedIndex;
            if (i >= 0)
            {
                if (l.ElementAt(i).MeasureID == 0)
                    measureTB.Text = "г.";
                if (l.ElementAt(i).MeasureID == 1)
                    measureTB.Text = "шт."; 
                if (l.ElementAt(i).MeasureID == 2)
                    measureTB.Text = "мл.";
            }
        }
    }
}