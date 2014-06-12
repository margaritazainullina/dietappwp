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
    public partial class ProductList : PhoneApplicationPage
    {
        public ProductList()
        {
            InitializeComponent();
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Person> PersonQuery = from Person in Db.Persons select Person;
                Person p = PersonQuery.FirstOrDefault();

                //фильтрация
                IQueryable<Product> ProductQuery = from Product in Db.Products where Product.IDType<= 3-p.Preference select Product;
                List<Product> l = ProductQuery.ToList();

                var list = ProductQuery.Select(s => new { s.Name }).ToList();
                List<String> names = new List<string>();
                foreach (var s in list)
                {
                    String ss = s.ToString().Replace("{ Name = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }
                listBox1.ItemsSource = names;

                var list1 = ProductQuery.Select(s => new { s.Protein }).ToList();
                names = new List<string>();
                foreach (var s in list1)
                {
                    String ss = s.ToString().Replace("{ Protein = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }
                listBox2.ItemsSource = names;

                var list2 = ProductQuery.Select(s => new { s.Fat }).ToList();
                names = new List<string>();
                foreach (var s in list2)
                {
                    String ss = s.ToString().Replace("{ Fat = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }
                listBox3.ItemsSource = names;

                var list3 = ProductQuery.Select(s => new { s.Carbohydrates }).ToList();
                names = new List<string>();
                foreach (var s in list3)
                {
                    String ss = s.ToString().Replace("{ Carbohydrates = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }
                listBox4.ItemsSource = names;

                var list4 = ProductQuery.Select(s => new { s.Calories }).ToList();
                names = new List<string>();
                foreach (var s in list4)
                {
                    String ss = s.ToString().Replace("{ Calories = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }
                listBox5.ItemsSource = names;

                var list5 = ProductQuery.Select(s => new { s.Acidity }).ToList();
                names = new List<string>();
                foreach (var s in list5)
                {
                    String ss = s.ToString().Replace("{ Acidity = ", "");
                    ss = ss.Replace("}", "");
                    names.Add(ss);
                }
                listBox6.ItemsSource = names;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddProduct.xaml", UriKind.Relative));
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string text = "";

            CheckBox chkStatus = (CheckBox)sender;

            if (chkStatus.IsChecked == true)
            {
                text = chkStatus.CommandParameter.ToString();
            }
        }
    }
}