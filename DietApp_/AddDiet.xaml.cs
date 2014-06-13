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
    public partial class AddDiet : PhoneApplicationPage
    {
        public static Diet d;
        public static Boolean a = true;
        public static int dietId = 0;

        public AddDiet()
        {
            InitializeComponent();
             InitializeComponent();
             if (a)
             {
                 d = new Diet();
                 using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                 {
                     d.Name = "";
                     d.DietProducts = new System.Data.Linq.EntitySet<DietProduct>();
                     Db.Diets.InsertOnSubmit(d);
                     Db.SubmitChanges();
                     dietId = (from Diet in Db.Diets select Diet).Count();
                 }
                 a = false;
             }
             else
             {
                 name.Text = d.Name;
                 textBox1.Text = d.Duration + "";
                 using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                 {
                     IQueryable<Diet> q = from Diet in Db.Diets where Diet.DietID == dietId select Diet;
                     d = q.FirstOrDefault();

                     var list1 = d.DietProducts.ToList();
                     List<String> ll = new List<string>();
                     foreach (var s in list1)
                     {
                         ll.Add(s.Product.Name);
                     }
                     lb1.ItemsSource = ll;
                 }
             }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DietList.xaml", UriKind.Relative));
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Diet> q = from Diet in Db.Diets where Diet.DietID == dietId select Diet;
                d = q.FirstOrDefault();
                d.Name = name.Text;
                Db.SubmitChanges();
            }
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Diet> q = from Diet in Db.Diets where Diet.DietID == dietId select Diet;
                d = q.FirstOrDefault();
                d.Duration = Convert.ToInt32(textBox1.Text);
                Db.SubmitChanges();
            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Diet> q = from Diet in Db.Diets where Diet.DietID == dietId select Diet;
                d = q.FirstOrDefault();
                d.Name = name.Text;
                d.Duration = Convert.ToInt32(textBox1.Text);
                Db.SubmitChanges();
                NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
            }
        }       

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddProductToDiet.xaml", UriKind.Relative));
        }
    }
}