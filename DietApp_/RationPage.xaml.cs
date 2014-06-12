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
    public partial class Page2 : PhoneApplicationPage
    {
        public static int dayIdx = 0;
        public static Boolean x = true;
        public Page2()
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                x = true;
                InitializeComponent();

                if (dayIdx == 0) day.Text = "Понедельник";
                if (dayIdx == 1) day.Text = "Вторник";
                if (dayIdx == 2) day.Text = "Среда";
                if (dayIdx == 3) day.Text = "Четверг";
                if (dayIdx == 4) day.Text = "Пятница";
                if (dayIdx == 5) day.Text = "Суббота";
                if (dayIdx == 6) day.Text = "Воскресенье";

                IQueryable<Ration> RationQuery = from Ration in Db.Rations where Ration.DayWeek == dayIdx select Ration;
                List<Ration> r = RationQuery.ToList();

                var list1 = RationQuery.Select(s => new { s.Time }).ToList();
                List<String> times = new List<string>();
                foreach (var s in list1)
                {
                    String ss = s.ToString().Replace("{ Time = ", "");
                    ss = ss.Replace("}", "");
                    times.Add(ss);
                }
                listBox1.ItemsSource = times;

                var list2 = RationQuery.Select(s => new { s.Dish.Name }).ToList();
                List<String> names = new List<string>();
                foreach (var s in list2)
                {
                    String ss = s.ToString().Replace("{ Name = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }
                listBox2.ItemsSource = names;

                var list3 = RationQuery.Select(s => new { s.WeightDish, s.Dish }).ToList();
                List<String> portions = new List<string>();
                List<String> calories = new List<string>();
                int totalCalories = 0;
                foreach (var s in list3)
                {
                    String ss = s.WeightDish.ToString().Replace("{ WeightDish = ", "");
                    ss = ss.Replace("}", "");
                    portions.Add(ss);
                    int calory = 0;
                    List<DishProduct> dps = s.Dish.DishProducts.ToList();
                    foreach (DishProduct dp in dps)
                    {
                        Product p = dp.Product;
                        calory += p.Calories * dp.Quantity;
                    }
                    calory /= s.WeightDish;
                    calories.Add(calory + "");
                    totalCalories += calory;
                }
                listBox3.ItemsSource = portions;
                listBox4.ItemsSource = calories;
                total.Text = totalCalories + "";

                IQueryable<Person> PersonQuery = from Person in Db.Persons select Person;
                Person person = PersonQuery.FirstOrDefault();
                double targetCalories = 0;
                if (person.Sex == "M")
                {
                    if (person.Age < 17) targetCalories = 16.6 * person.Weight + 119 + 572;
                    else if (person.Age < 30) targetCalories = 15.4 * person.Weight - 0.27 * person.Height + 717;
                    else if (person.Age < 60) targetCalories = 11.3 * person.Weight + 0.16 * person.Height + 901;
                    else targetCalories = 8.8 * person.Weight + 11.28 * person.Height - 1071;
                }
                else
                {
                    if (person.Age < 17) targetCalories = 7.4 * person.Weight + 4.82 * person.Height + 217;
                    else if (person.Age < 30) targetCalories = 13.3 * person.Weight + 3.34 * person.Height + 35;
                    else if (person.Age < 60) targetCalories = 8.7 * person.Weight - 0.25 * person.Height + 865;
                    else targetCalories = 9.2 * person.Weight + 6.37 * person.Height - 302;
                }
                textBlock4.Text = Math.Round(targetCalories, 1) + "";
                if (targetCalories * 1.1 < totalCalories) textBlock5.Text = "Употребляйте меньше калорий";
                if (targetCalories > totalCalories * 1.1) textBlock5.Text = "Употребляйте больше калорий";
            }
        }

        private void day_SelectionChanged(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DaysList.xaml", UriKind.Relative));
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddActivity.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RationOptimisation.xaml", UriKind.Relative));
        }

        private void day_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
            if (!x) { NavigationService.Navigate(new Uri("/DayList.xaml", UriKind.Relative)); }
            else
                x = false;
        }
    }
}