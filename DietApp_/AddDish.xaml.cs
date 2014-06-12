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
       
        public AddDish()
        {
            InitializeComponent();
            if (a)
            {
                d = new Dish();
                using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                {
                    d.Name = "";
                    d.DishProducts = new System.Data.Linq.EntitySet<DishProduct>();
                    Db.Dishes.InsertOnSubmit(d);
                    Db.SubmitChanges();
                    dishId = (from Dish in Db.Dishes select Dish).Count();
                }
                a = false;
            }
            else
            {
                name.Text = d.Name;
                textBox1.Text = d.Portion + "";
                using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                {
                    IQueryable<Dish> q = from Dish in Db.Dishes where Dish.DishID == dishId select Dish;
                    d = q.FirstOrDefault();

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
                    var list3 = d.DishProducts.Select(s => new { s.Product.Name}).ToList();
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
                    calory /= d.Portion;
                    textBlock3.Text = calory+"";
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
                IQueryable<Dish> q = from Dish in Db.Dishes where Dish.DishID == dishId select Dish;
                d = q.FirstOrDefault();
                d.Name = name.Text; 
                d.Portion = Convert.ToInt32(textBox1.Text);
                Db.SubmitChanges();
                NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
            }
        }

       
        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Dish> q = from Dish in Db.Dishes where Dish.DishID == dishId select Dish;
                d = q.FirstOrDefault();
                d.Name = name.Text;
                Db.SubmitChanges();
            }
        }

     
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Dish> q = from Dish in Db.Dishes where Dish.DishID == dishId select Dish;
                d = q.FirstOrDefault();
                d.Portion = Convert.ToInt32(textBox1.Text);
                Db.SubmitChanges();
            }
        }

      
    }
}