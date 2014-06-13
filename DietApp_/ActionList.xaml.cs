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
    public partial class ActionList : PhoneApplicationPage
    {
        List<Action> l;
        public ActionList()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Action> ActionQuery = from Action in Db.Actions select Action;
                l = ActionQuery.ToList();

                var list = ActionQuery.Select(s => new { s.Name, s.Energy }).ToList();
                List<String> names = new List<string>();
                List<String> energy = new List<string>();
                foreach (var s in list)
                {
                    String ss = s.Name.ToString().Replace("{ Name = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                    ss = s.Energy.ToString().Replace("{ Energy = ", "");
                    ss = ss.Replace("}", "");
                    energy.Add(ss);
                }
                listBox1.ItemsSource = names;
                listBox2.ItemsSource = energy;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddAction.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Schedule.xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Удалить?", "", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                Action a = null;
                if (listBox1.SelectedIndex >= 0)
                    a= l[listBox1.SelectedIndex];
                if (listBox2.SelectedIndex >= 0)
                    a=l[listBox1.SelectedIndex];

                using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                {
                    if (a != null)
                    {
                        var s1 = from Action in Db.Actions
                                 where Action.ActionID == a.ActionID
                                 select Action;
                        Db.Actions.DeleteOnSubmit(s1.FirstOrDefault());
                        Db.SubmitChanges();
                    }
                }
                init();
            }
        }
    }
}