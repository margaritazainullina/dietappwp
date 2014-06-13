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
    public partial class AddDish : PhoneApplicationPage
    {
        public static Dish d;
        public static Boolean a = true;
        public static int dishId = 0;
        public static String name1;
        public static int portion1;

        public AddDish()
        {
            InitializeComponent();
            if (a)
            {
                d = new Dish() { Name = "", Portion = 0 };
                d.DishProducts = new System.Data.Linq.EntitySet<DishProduct>();
                a = false;
                name1 = "";
                portion1 = 0;
            }
            else
            {
                name.Text = name1;
                textBox1.Text = portion1 + "";
                using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                {

                    var list1 = d.DishProducts.ToList();
                    var list2 = d.DishProducts.Select(s => new { s.Quantity, s.Product.MeasureID }).ToList();
                    List<String> ll = new List<string>();
                    foreach (var s in list2)
                    {
                        String ss = "";
                        if (s.MeasureID == 0)
                            ss = s.Quantity + " г.";
                        if (s.MeasureID == 1)
                            ss = s.Quantity + " шт.";
                        if (s.MeasureID == 2)
                            ss = s.Quantity + " мл.";
                        ll.Add(ss);
                    }
                    var list3 = d.DishProducts.Select(s => new { s.Product.Name }).ToList();
                    List<String> list4 = new List<string>();
                    foreach (var s in list3)
                    {
                        String ss = s.ToString().Replace("{ Name = ", "");
                        ss = ss.Replace("}", "");
                        list4.Add(ss);
                    }
                    d.DishProducts.ToList();
                    lb2.ItemsSource = ll;
                    lb1.ItemsSource = list4;

                    int calory = 0;
                    List<DishProduct> dps = d.DishProducts.ToList();
                    foreach (DishProduct dp in dps)
                    {
                        Product p = dp.Product;
                        calory += p.Calories * dp.Quantity;
                    }
                    if (d.Portion != 0)
                        calory /= d.Portion;
                    textBlock3.Text = calory + "";
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddProductToDish.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                Dish d1 = new Dish(name1, d.Type, portion1, d.Measure);
                Db.Dishes.InsertOnSubmit(d1);
                Db.SubmitChanges();
                foreach (DishProduct dpr in d.DishProducts)
                {
                    dpr.DId = d1.DishID;
                    Db.DishProducts.InsertOnSubmit(dpr);
                    d1.DishProducts.Add(dpr);
                    Db.SubmitChanges();
                }

                NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
            }
        }


        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            name1 = name.Text;
        }


        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                portion1 = Convert.ToInt32(textBox1.Text);
            }
            catch { d.Portion = 0; }

            int calory = 0;
            List<DishProduct> dps = d.DishProducts.ToList();
            foreach (DishProduct dp in dps)
            {
                Product p = dp.Product;
                calory += p.Calories * dp.Quantity;
            }
            if (portion1 != 0)
                calory /= portion1;
            textBlock3.Text = calory + "";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
        }


    }
}