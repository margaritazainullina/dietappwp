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
using System.Data.Linq;
using DietApp_;

namespace DietApp
{
    public partial class Dishes : PhoneApplicationPage
    {
        public Dishes()
        {
            InitializeComponent();
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Dish> DishesQuery = from Dish in Db.Dishes select Dish;
                List<Dish> l = DishesQuery.ToList();
                var list = DishesQuery.Select(s => new { s.Name }).ToList();
                List<String> names = new List<string>();
                foreach (var s in list)
                {
                    String ss = s.ToString().Replace("{ Name = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }

                List<String> portions = new List<String>();

                List<Dish> dishesList = DishesQuery.ToList();
                foreach (Dish dish in dishesList)
                {
                    if (dish.Measure == 0)
                        portions.Add(dish.Portion + " г.");
                    else portions.Add(dish.Portion + " мл.");
                }

                List<int> calories = new List<int>();

                foreach (Dish dish in dishesList)
                {
                    int calory = 0;
                    List<DishProduct> dps = dish.DishProducts.ToList();
                    foreach (DishProduct dp in dps)
                    {
                        Product p = dp.Product;
                        calory += p.Calories * dp.Quantity;
                    }
                    calory /= dish.Portion;
                    calories.Add(calory);
                }

                listBox2.ItemsSource = names;
                listBox3.ItemsSource = portions;
                listBox4.ItemsSource = calories;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddDish.xaml", UriKind.Relative));
        }
    }
}