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
    public partial class DietList : PhoneApplicationPage
    {
        List<Diet> l;
        public static String d;
        public DietList()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Diet> q = from Diet in Db.Diets select Diet;
                l = q.ToList();

                var list = q.Select(s => new { s.Name }).ToList();
                List<String> names = new List<string>();
                foreach (var s in list)
                {
                    String ss = s.ToString().Replace("{ Name = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }
                ListboxDiet.ItemsSource = names;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainPage.d = l[ListboxDiet.SelectedIndex];
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DietProductList.xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddDiet.xaml", UriKind.Relative));
        }

        private void ListboxDiet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            d = l[ListboxDiet.SelectedIndex].Name;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Удалить?", "", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                Diet s = null;
                if (ListboxDiet.SelectedIndex >= 0)
                    s = l[ListboxDiet.SelectedIndex];
                
                using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                {
                    if (s != null)
                    {
                        var s1 = from Diet in Db.Diets
                                 where Diet.DietID == s.DietID
                                 select Diet;
                        Db.Diets.DeleteOnSubmit(s1.FirstOrDefault());
                        Db.SubmitChanges();
                    }
                }
                init();
            }
        }
    }
}