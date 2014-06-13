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
using DietApp_;

namespace DietApp
{
    public partial class Page1 : PhoneApplicationPage
    {
        public static int dayIdx = 0;
        public static Boolean x = true;
        List<Schedule> l;
        public Page1()
        {
            InitializeComponent();
            init();
        }
        public void init()
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

                IQueryable<Person> q = from Person in Db.Persons where Person.Name != "" select Person;
                Person person = q.FirstOrDefault();

                IQueryable<Schedule> ScheduleQuery = from Schedule in Db.Schedules where Schedule.DayWeek == dayIdx select Schedule;
                l = ScheduleQuery.ToList();
                var list = ScheduleQuery.Select(s => new { s.Time, s.Action, s.Duration }).ToList();
                List<String> times = new List<string>();
                List<String> actions = new List<string>();
                List<String> calories = new List<String>();
                foreach (var s in list)
                {
                    String ss = s.Time.ToString().Replace("{ Time = ", "");
                    ss = ss.Replace("}", "");
                    times.Add(ss);
                    ss = s.Action.Name.Replace("{ Action = ", "");
                    ss = ss.Replace("}", "");
                    actions.Add(ss);
                    double d = Math.Round((s.Action.Energy * person.Weight * s.Duration) / 60, 1);
                    calories.Add(d + "");
                }
                listBox1.ItemsSource = times;
                listBox2.ItemsSource = actions;
                listBox3.ItemsSource = calories;
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddSchedule.xaml", UriKind.Relative));
        }

        private void day_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!x) { NavigationService.Navigate(new Uri("/DayList1.xaml", UriKind.Relative)); }
            else
                x = false;
        }

        private void Назад_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Удалить?", "", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                Schedule s = null;
                if (listBox1.SelectedIndex >= 0)
                    s = l[listBox1.SelectedIndex];
                else if (listBox3.SelectedIndex >= 0)
                    s = l[listBox2.SelectedIndex];
                else if (listBox3.SelectedIndex >= 0)
                    s = l[listBox3.SelectedIndex];
                using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                {
                    if (s != null)
                    {
                        var s1 = from Schedule in Db.Schedules
                                 where Schedule.ScheduleID == s.ScheduleID
                                 select Schedule;
                        Db.Schedules.DeleteOnSubmit(s1.FirstOrDefault());
                        Db.SubmitChanges();
                    }
                }
                init();
            }
        }
    }
}