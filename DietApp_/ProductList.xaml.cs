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
        List<Product> l;
        public ProductList()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Person> PersonQuery = from Person in Db.Persons where Person.Name != "" select Person;
                Person p = PersonQuery.FirstOrDefault();

                //фильтрация
                IQueryable<Product> ProductQuery = from Product in Db.Products where Product.IDType <= 3 - p.Preference select Product;
                l = ProductQuery.ToList();

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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Product s = null;
            MessageBoxResult m = MessageBox.Show("Удалить?", "", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                if (listBox1.SelectedIndex >= 0)
                    s = l[listBox1.SelectedIndex];
                else if (listBox3.SelectedIndex >= 0)
                    s = l[listBox2.SelectedIndex];
                else if (listBox3.SelectedIndex >= 0)
                    s = l[listBox3.SelectedIndex];
                else if (listBox4.SelectedIndex >= 0)
                    s = l[listBox4.SelectedIndex];
                else if (listBox5.SelectedIndex >= 0)
                    s = l[listBox5.SelectedIndex];
                else if (listBox6.SelectedIndex >= 0)
                    s = l[listBox6.SelectedIndex];
                using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                {
                    if (s != null)
                    {
                        var s2 = from DietProduct in Db.DietProducts
                                 where DietProduct.PId == s.ProductID
                                 select DietProduct;

                        List<DietProduct> lp = s2.ToList();
                        Db.DietProducts.DeleteAllOnSubmit(lp);
                        Db.SubmitChanges();

                        var s3 = from DishProduct in Db.DishProducts
                                 where DishProduct.PId == s.ProductID
                                 select DishProduct;

                        List<DishProduct> dp = s3.ToList();
                        Db.DishProducts.DeleteAllOnSubmit(dp);
                        Db.SubmitChanges();

                        var s1 = from Product in Db.Products
                                 where Product.ProductID == s.ProductID
                                 select Product;
                        Db.Products.DeleteOnSubmit(s1.FirstOrDefault());
                        Db.SubmitChanges();
                    }
                }
                init();
            }
        }
    }
}