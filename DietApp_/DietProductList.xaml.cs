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
    public partial class DietProductList : PhoneApplicationPage
    {
        List<DietProduct> list;
        public DietProductList()
        {
            InitializeComponent();
            init();        
        }

        public void init() {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Diet> q = from Diet in Db.Diets where Diet.Name == DietList.d select Diet;

                Diet d = q.FirstOrDefault();
                PageTitle.Text = d.Name;
                
                List<Product> list1;

                List<String> names = new List<string>();
                List<String> protein = new List<string>();
                List<String> fat = new List<string>();
                List<String> carbohydrate = new List<string>();
                List<String> calories = new List<string>();
                List<String> acidity = new List<string>();

                if (d.Name == "Без диеты")
                {
                    IQueryable<Product> ProductQuery = from Product in Db.Products select Product;
                    list1 = ProductQuery.ToList();
                    foreach (var s in list1)
                    {
                        names.Add(s.Name);
                        protein.Add(s.Protein + "");
                        fat.Add(s.Fat + "");
                        carbohydrate.Add(s.Carbohydrates + "");
                        calories.Add(s.Calories + "");
                        acidity.Add(s.Acidity + "");
                    }
                }
                else
                {
                    list = d.DietProducts.ToList();
                    foreach (var s in list)
                    {
                        names.Add(s.Product.Name);
                        protein.Add(s.Product.Protein + "");
                        fat.Add(s.Product.Fat + "");
                        carbohydrate.Add(s.Product.Carbohydrates + "");
                        calories.Add(s.Product.Calories + "");
                        acidity.Add(s.Product.Acidity + "");
                    }
                }


                listBox1.ItemsSource = names;
                listBox2.ItemsSource = protein;
                listBox3.ItemsSource = fat;
                listBox4.ItemsSource = carbohydrate;
                listBox5.ItemsSource = calories;
                listBox6.ItemsSource = acidity;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DietList.xaml", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Удалить?", "", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                DietProduct s = null;
                if (listBox1.SelectedIndex >= 0)
                    s = list[listBox1.SelectedIndex];
                else if (listBox2.SelectedIndex >= 0)
                    s = list[listBox2.SelectedIndex];
                else if (listBox3.SelectedIndex >= 0)
                    s = list[listBox3.SelectedIndex];
                else if (listBox3.SelectedIndex >= 0)
                    s = list[listBox3.SelectedIndex];
                else if (listBox4.SelectedIndex >= 0)
                    s = list[listBox4.SelectedIndex];
                else if (listBox5.SelectedIndex >= 0)
                    s = list[listBox5.SelectedIndex];
                using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                {
                    if (s != null)
                    {
                        var s1 = from DietProduct in Db.DietProducts
                                 where DietProduct.DPID == s.DPID
                                 select DietProduct;
                        Db.DietProducts.DeleteOnSubmit(s1.FirstOrDefault());
                        Db.SubmitChanges();
                    }
                }
                init();
            }
        }
    }
}