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
    public partial class AddRation : PhoneApplicationPage
    {
        List<Dish> l = new List<Dish>();
        public AddRation()
        {
            InitializeComponent();
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Dish> RationQuery = from Dish in Db.Dishes select Dish;
                l = RationQuery.ToList();
                var list = RationQuery.Select(s => new { s.Name }).ToList();
                List<String> names = new List<string>();
                foreach (var s in list)
                {
                    String ss = s.ToString().Replace("{ Name = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }
                listBox2.ItemsSource = names;
            }
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RationPage.xaml", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Dish> RationQuery = from Dish in Db.Dishes where Dish.DishID == l[listBox2.SelectedIndex].DishID select Dish;
                Dish d = RationQuery.FirstOrDefault();
                Ration r = new Ration { DayWeek = listBox1.SelectedIndex, Dish = d, Time = textBox1.Text, WeightDish = Convert.ToInt32(textBox2.Text) };
                Db.Rations.InsertOnSubmit(r);
                Db.SubmitChanges();
                NavigationService.Navigate(new Uri("/RationPage.xaml", UriKind.Relative));
            }
        }
    }
}