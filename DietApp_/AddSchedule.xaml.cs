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
    public partial class AddSchedule : PhoneApplicationPage
    {
        public static int dayIdx = 0;
        public static Boolean x = true;

        List<Action> l;
        public AddSchedule()
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

            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Action> ActionQuery = from Action in Db.Actions select Action;
                 l = ActionQuery.ToList();
                var list = ActionQuery.Select(s => new { s.Name }).ToList();
                List<String> names = new List<string>();
                foreach (var s in list)
                {
                    String ss = s.ToString().Replace("{ Name = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }
                listBox1.ItemsSource = names;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddAction.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                Schedule s = new Schedule { DayWeek = dayIdx, Duration = Convert.ToInt32(duration.Text), Time = time.Text, Action = l[listBox1.SelectedIndex] };
                Db.Schedules.InsertOnSubmit(s);
                Db.SubmitChanges();
            }
            NavigationService.Navigate(new Uri("/Schedule.xaml", UriKind.Relative));
        }

        private void day_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!x) { NavigationService.Navigate(new Uri("/DayList2.xaml", UriKind.Relative)); }
            else
                x = false;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Schedule.xaml", UriKind.Relative)); 
        }
    }
}