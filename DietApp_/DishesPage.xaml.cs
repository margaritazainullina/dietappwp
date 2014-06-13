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
        List<Dish> l;
        public Dishes()
        {
            InitializeComponent();
            init();
        }
        public void init()
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Dish> DishesQuery = from Dish in Db.Dishes select Dish;
                l = DishesQuery.ToList();
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
                    if (dish.Portion!=0) calory /= dish.Portion;
                    calories.Add(calory);
                }

                listBox1.ItemsSource = names;
                listBox2.ItemsSource = portions;
                listBox3.ItemsSource = calories;
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddDish.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Удалить?", "", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                Dish s = null;

                if (listBox2.SelectedIndex >= 0)
                    s = l[listBox2.SelectedIndex];
                else if (listBox3.SelectedIndex >= 0)
                    s = l[listBox3.SelectedIndex];
                else if (listBox1.SelectedIndex >= 0)
                    s = l[listBox1.SelectedIndex];
                using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                {
                    if (s != null)
                    {
                        var s3 = from DishProduct in Db.DishProducts
                                 where DishProduct.DId == s.DishID
                                 select DishProduct;

                        List<DishProduct> dp = s3.ToList();
                        Db.DishProducts.DeleteAllOnSubmit(dp);
                        Db.SubmitChanges();

                        var s4 = from Ration in Db.Rations
                                 where Ration.Dish.DishID == s.DishID
                                 select Ration;

                        List<Ration> rp = s4.ToList();
                        Db.Rations.DeleteAllOnSubmit(rp);
                        Db.SubmitChanges();

                        var s1 = from Dish in Db.Dishes
                                 where Dish.DishID == s.DishID
                                 select Dish;
                        Db.Dishes.DeleteOnSubmit(s1.FirstOrDefault());
                        Db.SubmitChanges();
                    }
                }
                init();
            }
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}