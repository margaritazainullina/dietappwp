﻿using System;
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
    public partial class MainPage : PhoneApplicationPage
    {
        public static string strConnectionString = @"isostore:/DB.sdf";
        private string gender;

        public static Person p;

        Boolean a = false;
        Boolean b = false;

        public static String diet_ = "Без диеты";
        public static String preference_ = "Ем все";
        // Constructor
        public MainPage()
        {

            InitializeComponent();
            using (MyDataContext Db = new MyDataContext(strConnectionString))
            {
                Db.DeleteDatabase();
                if (Db.DatabaseExists() == false)
                {
                    Db.CreateDatabase();
                    //inserting in ideal parameters table

                    List<IdealParameter> ii = new List<IdealParameter>();
                    ii.Add(new IdealParameter(152.5, 155, 47.8, 49.2, "F", 0));
                    ii.Add(new IdealParameter(155, 157, 49.2, 50.8, "F", 0));
                    ii.Add(new IdealParameter(157, 160, 50.8, 52.1, "F", 0));
                    ii.Add(new IdealParameter(160, 162, 52.1, 53.8, "F", 0));
                    ii.Add(new IdealParameter(162, 165, 53.8, 55.3, "F", 0));
                    ii.Add(new IdealParameter(165, 167, 55.3, 56.6, "F", 0));
                    ii.Add(new IdealParameter(167, 170, 56.6, 57.8, "F", 0));
                    ii.Add(new IdealParameter(170, 172, 57.8, 59, "F", 0));
                    ii.Add(new IdealParameter(172, 175, 59, 60.3, "F", 0));
                    ii.Add(new IdealParameter(175, 177, 60.3, 61.5, "F", 0));
                    ii.Add(new IdealParameter(177, 180, 61.5, 62.7, "F", 0));

                    ii.Add(new IdealParameter(152.5, 155, 54, 55.2, "F", 1));
                    ii.Add(new IdealParameter(155, 157, 55.2, 57, "F", 1));
                    ii.Add(new IdealParameter(157, 160, 57, 58.5, "F", 1));
                    ii.Add(new IdealParameter(160, 162, 58.5, 60.1, "F", 1));
                    ii.Add(new IdealParameter(162, 165, 60.1, 61.8, "F", 1));
                    ii.Add(new IdealParameter(165, 167, 61.8, 63, "F", 1));
                    ii.Add(new IdealParameter(167, 170, 63, 64, "F", 1));
                    ii.Add(new IdealParameter(170, 172, 64, 65.2, "F", 1));
                    ii.Add(new IdealParameter(172, 175, 65.2, 66.5, "F", 1));
                    ii.Add(new IdealParameter(175, 177, 61.5, 67.7, "F", 1));
                    ii.Add(new IdealParameter(177, 180, 62.7, 68.9, "F", 1));

                    ii.Add(new IdealParameter(152.5, 155, 59, 61.6, "F", 2));
                    ii.Add(new IdealParameter(155, 157, 61.6, 63.1, "F", 2));
                    ii.Add(new IdealParameter(157, 160, 63.1, 64.8, "F", 2));
                    ii.Add(new IdealParameter(160, 162, 64.8, 66.3, "F", 2));
                    ii.Add(new IdealParameter(162, 165, 66.3, 67.8, "F", 2));
                    ii.Add(new IdealParameter(165, 167, 67.8, 69, "F", 2));
                    ii.Add(new IdealParameter(167, 170, 69, 70, "F", 2));
                    ii.Add(new IdealParameter(170, 172, 70, 71.2, "F", 2));
                    ii.Add(new IdealParameter(172, 175, 71.2, 72.5, "F", 2));
                    ii.Add(new IdealParameter(175, 177, 72.5, 73.3, "F", 2));
                    ii.Add(new IdealParameter(177, 180, 73.3, 74.9, "F", 2));

                    ii.Add(new IdealParameter(155, 157.5, 49.3, 51.7, "M", 0));
                    ii.Add(new IdealParameter(157.5, 160, 51.7, 53.5, "M", 0));
                    ii.Add(new IdealParameter(160, 162.5, 53.5, 55.3, "M", 0));
                    ii.Add(new IdealParameter(162.5, 165, 55.3, 57.1, "M", 0));
                    ii.Add(new IdealParameter(165, 167.5, 57.1, 59.3, "M", 0));
                    ii.Add(new IdealParameter(167.5, 170, 59.3, 60.5, "M", 0));
                    ii.Add(new IdealParameter(170, 172, 60.5, 63.3, "M", 0));
                    ii.Add(new IdealParameter(172, 175, 63.3, 63.3, "M", 0));
                    ii.Add(new IdealParameter(175, 177.5, 63.3, 67.3, "M", 0));
                    ii.Add(new IdealParameter(177.5, 180, 67.3, 68.9, "M", 0));
                    ii.Add(new IdealParameter(180, 182.5, 68.9, 70.9, "M", 0));
                    ii.Add(new IdealParameter(182.5, 185, 70.9, 72.8, "M", 0));

                    ii.Add(new IdealParameter(155, 157.5, 56, 58, "M", 1));
                    ii.Add(new IdealParameter(157.5, 160, 58, 60, "M", 1));
                    ii.Add(new IdealParameter(160, 162.5, 60, 61.7, "M", 1));
                    ii.Add(new IdealParameter(162.5, 165, 61.7, 63.5, "M", 1));
                    ii.Add(new IdealParameter(165, 167.5, 63.5, 65.8, "M", 1));
                    ii.Add(new IdealParameter(167.5, 170, 65.8, 67.8, "M", 1));
                    ii.Add(new IdealParameter(170, 172, 67.8, 69.7, "M", 1));
                    ii.Add(new IdealParameter(172, 175, 69.7, 71.7, "M", 1));
                    ii.Add(new IdealParameter(175, 177.5, 71.7, 73.8, "M", 1));
                    ii.Add(new IdealParameter(177.5, 180, 73.8, 75.2, "M", 1));
                    ii.Add(new IdealParameter(180, 182.5, 75.2, 77.2, "M", 1));
                    ii.Add(new IdealParameter(182.5, 185, 77.2, 79.2, "M", 1));

                    ii.Add(new IdealParameter(155, 157.5, 62.2, 64, "M", 2));
                    ii.Add(new IdealParameter(157.5, 160, 64, 66, "M", 2));
                    ii.Add(new IdealParameter(160, 162.5, 66, 68, "M", 2));
                    ii.Add(new IdealParameter(162.5, 165, 68, 69.5, "M", 2));
                    ii.Add(new IdealParameter(165, 167.5, 69.5, 71.8, "M", 2));
                    ii.Add(new IdealParameter(167.5, 170, 71.8, 73.8, "M", 2));
                    ii.Add(new IdealParameter(170, 172, 73.8, 76.8, "M", 2));
                    ii.Add(new IdealParameter(172, 175, 76.8, 77.8, "M", 2));
                    ii.Add(new IdealParameter(175, 177.5, 77.8, 79.8, "M", 2));
                    ii.Add(new IdealParameter(177.5, 180, 79.8, 81.2, "M", 2));
                    ii.Add(new IdealParameter(180, 182.5, 81.2, 83.6, "M", 2));
                    ii.Add(new IdealParameter(182.5, 185, 83.6, 85.2, "M", 2));

                    Db.IdealParameters.InsertAllOnSubmit(ii);
                    Db.SubmitChanges();

                    List<Product> products = new List<Product>();
                    Product p1 = new Product("Баклажаны", 0, 1.2, 0.1, 7.1, 24, 0, 0, 0);
                    products.Add(p1);
                    Product p2 = new Product("Морковь", 0, 1.3, 0.1, 9.3, 34, 0, 0, 0);
                    products.Add(p2);
                    Product p3 = new Product("Огурцы свежие", 0, 0.8, 0.1, 3.8, 14, 0, 0, 0);
                    products.Add(p3);
                    Product p4 = new Product("Салат", 0, 1.5, 0.2, 3.1, 17, 0, 0, 0);
                    products.Add(p4);
                    Product p5 = new Product("Шампиньоны", 0, 4.3, 1, 1, 27, 0, 0, 0);
                    products.Add(p5);
                    Product p6 = new Product("Творог нежирный", 2, 18, 0.6, 1.8, 88, 0, 0, 0);
                    products.Add(p6);
                    Product p7 = new Product("Свинина", 3, 14.3, 33, 0, 357, 0, 0, 0);
                    products.Add(p7);
                    Product p8 = new Product("Говядина", 3, 18.6, 16, 0, 218, 0, 0, 0);
                    products.Add(p8);
                    Product p9 = new Product("Филе куриное", 3, 23.6, 1.9, 0.4, 113, 0, 0, 0);
                    products.Add(p9);
                    Product p10 = new Product("Яйцо куриное", 1, 12.7, 11.5, 0.7, 157, 0, 0, 1);
                    products.Add(p10);
                    Product p11 = new Product("Масло оливковое", 1, 0, 99.8, 0, 898, 0, 0, 2);
                    products.Add(p10);

                    Db.Products.InsertAllOnSubmit(products);
                    Db.SubmitChanges();
                    
                    Dish d = new Dish("Салат овощной", 0, 200, 0);
                    Db.Dishes.InsertOnSubmit(d);
                    Db.SubmitChanges();
                    DishProduct dp = new DishProduct() { DId = d.DishID, Product = p2, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p3, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p4, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p11, Quantity = 20 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    Db.SubmitChanges();
                    
                    d = new Dish("Рагу овощное", 1, 200, 0);
                    Db.Dishes.InsertOnSubmit(d);
                    Db.SubmitChanges();
                    dp = new DishProduct() { DId = d.DishID, Product = p1, Quantity = 200 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p2, Quantity = 300 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p11, Quantity = 20 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    Db.SubmitChanges();

                    d = new Dish("Рагу мясное", 3, 200, 0);
                    Db.Dishes.InsertOnSubmit(d);
                    Db.SubmitChanges();
                    dp = new DishProduct() { DId = d.DishID, Product = p2, Quantity = 200 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p5, Quantity = 150 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p8, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p11, Quantity = 30 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    Db.SubmitChanges();

                    d = new Dish("Салат с курицей", 3, 150, 0);
                    Db.Dishes.InsertOnSubmit(d);
                    Db.SubmitChanges();
                    dp = new DishProduct() { DId = d.DishID, Product = p4, Quantity = 200 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p5, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p9, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p11, Quantity = 10 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    Db.SubmitChanges();

                    d = new Dish("Котлеты морковные", 1, 80, 0);
                    Db.Dishes.InsertOnSubmit(d);
                    Db.SubmitChanges();
                    dp = new DishProduct() { DId = d.DishID, Product = p2, Quantity = 300 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d.DishID, Product = p10, Quantity = 20 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d.DishProducts.Add(dp);
                    Db.SubmitChanges();

                    MessageBox.Show("Database Created Successfully!");
                }

                IQueryable<Person> PersonQuery = Db.Persons.Select(v => v);
                p = PersonQuery.FirstOrDefault();
                if (p == null) p = new Person();
                diet.Text = diet_;
                preference.Text = preference_;
            }
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            gender = "M";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (MyDataContext context = new MyDataContext(strConnectionString))
            {
                /* p.Name = name.Text;
                 p.Age = Convert.ToInt32(age.Text);
                 p.Height = Convert.ToInt32(height.Text);
                 p.Weight = Convert.ToInt32(weight.Text);
                 p.Sex = gender;
                 p.WaistCircumference = Convert.ToInt32(waist.Text);
                 p.HipCircumference = Convert.ToInt32(hip.Text);
                 p.WristCircumference = Convert.ToInt32(wrist.Text);*/

                //STUB!
                p.Name = "Аня";
                p.Age = 21;
                p.Height = 174;
                p.Weight = 63;
                p.Sex = "F";
                p.WaistCircumference = 62;
                p.HipCircumference = 88;
                p.WristCircumference = 16;
                p.Preference = 0;

                //constitution
                if (p.WristCircumference > 18.5) p.ConstitutionId = 2;
                else if (p.WristCircumference < 16) p.ConstitutionId = 0;
                else p.ConstitutionId = 1;

                //fat percentage
                p.PercentFat = Math.Round(((p.Weight * 1.0) / (p.Height * p.Height) * 10000), 1);

                //bioage
                double rl = 0;
                double kss = 0;
                if (gender == "M")
                {
                    rl = p.Age - 21;
                    kss = (p.WaistCircumference * p.Weight) / (p.HipCircumference * p.Height * p.Height * (17.2 + 0.31 * rl + 0.0012 * rl * rl));
                }
                else
                {
                    rl = p.Age - 18;
                    kss = (p.WaistCircumference * p.Weight) / (p.HipCircumference * p.Height * p.Height * (14.7 + 0.26 * rl + 0.001 * rl * rl));
                } double bioage = 0;
                if (gender == "M") bioage = kss * (p.Age - 18) + 18;
                else bioage = kss * (p.Age - 21) + 21;
                p.Diet = "";
                p.Ration = "";
                p.BioAge = (int)Math.Round(bioage);

                //insert
                using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
                {
                    Db.Persons.InsertOnSubmit(p);
                    Db.SubmitChanges();
                }
            }

            NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
        }

        private void sex_Checked(object sender, RoutedEventArgs e)
        {
            gender = "F";
        }

        private void diet_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (p.Name != null)
            {
                NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
            }
            if (a)
                NavigationService.Navigate(new Uri("/DietList.xaml", UriKind.Relative));
            a = true;
        }

        private void preference_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (b)
                NavigationService.Navigate(new Uri("/PreferenceList.xaml", UriKind.Relative));
            b = true;
        }
    }
}