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
    public partial class MainPage : PhoneApplicationPage
    {
        public static string strConnectionString = @"isostore:/DB.sdf";
        private string gender;

        public static Person p;

        Boolean a = false;
        Boolean b = false;

        public static String Name1 = "";
        public static String Age1 = "";
        public static String Height1 = "";
        public static String Weight1 = "";
        public static String WaistCircumference1 = "";
        public static String HipCircumference1 = "";
        public static String WristCircumference1 = "";
        public static int pref = 0;
        public static Diet d;

        public static String preference_ = "Ем все";
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            using (MyDataContext Db = new MyDataContext(strConnectionString))
            {
                //  Db.DeleteDatabase();
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
                    Product p1 = new Product("Баклажаны", 0, 1.2, 0.1, 7.1, 24, 0, 15.1, 0);
                    products.Add(p1);
                    Product p2 = new Product("Морковь", 0, 1.3, 0.1, 9.3, 34, 0, 15.1, 0);
                    products.Add(p2);
                    Product p3 = new Product("Огурцы свежие", 0, 0.8, 0.1, 3.8, 14, 0, 13.5, 0);
                    products.Add(p3);
                    Product p4 = new Product("Салат", 0, 1.5, 0.2, 3.1, 17, 0, 14.2, 0);
                    products.Add(p4);
                    Product p5 = new Product("Шампиньоны", 0, 4.3, 1, 1, 27, 0, 3.5, 0);
                    products.Add(p5);
                    Product p6 = new Product("Творог нежирный", 2, 18, 0.6, 1.8, 88, 0, 1.7, 0);
                    products.Add(p6);
                    Product p7 = new Product("Свинина", 3, 14.3, 33, 0, 357, 0, 12.47, 0);
                    products.Add(p7);
                    Product p8 = new Product("Говядина", 3, 18.6, 16, 0, 218, 0, 38.61, 0);
                    products.Add(p8);
                    Product p9 = new Product("Филе куриное", 3, 23.6, 1.9, 0.4, 113, 0, 24.32, 0);
                    products.Add(p9);
                    Product p10 = new Product("Яйцо куриное", 1, 12.7, 11.5, 0.7, 157, 0, 11.16, 1);
                    products.Add(p10);
                    Product p11 = new Product("Масло оливковое", 1, 0, 99.8, 0, 898, 0, 6.1, 2);
                    products.Add(p10);

                    Db.Products.InsertAllOnSubmit(products);
                    Db.SubmitChanges();

                    Dish d1 = new Dish("Салат овощной", 0, 200, 0);
                    Db.Dishes.InsertOnSubmit(d1);
                    Db.SubmitChanges();
                    DishProduct dp = new DishProduct() { DId = d1.DishID, Product = p2, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d1.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d1.DishID, Product = p3, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d1.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d1.DishID, Product = p4, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d1.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d1.DishID, Product = p11, Quantity = 20 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d1.DishProducts.Add(dp);
                    Db.SubmitChanges();

                    Dish d2 = new Dish("Рагу овощное", 1, 200, 0);
                    Db.Dishes.InsertOnSubmit(d2);
                    Db.SubmitChanges();
                    dp = new DishProduct() { DId = d2.DishID, Product = p1, Quantity = 200 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d2.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d2.DishID, Product = p2, Quantity = 300 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d2.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d2.DishID, Product = p11, Quantity = 20 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d2.DishProducts.Add(dp);
                    Db.SubmitChanges();

                    Dish d3 = new Dish("Рагу мясное", 3, 200, 0);
                    Db.Dishes.InsertOnSubmit(d3);
                    Db.SubmitChanges();
                    dp = new DishProduct() { DId = d3.DishID, Product = p2, Quantity = 200 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d3.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d3.DishID, Product = p5, Quantity = 150 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d3.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d3.DishID, Product = p8, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d3.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d3.DishID, Product = p11, Quantity = 30 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d3.DishProducts.Add(dp);
                    Db.SubmitChanges();

                    Dish d4 = new Dish("Салат с курицей", 3, 150, 0);
                    Db.Dishes.InsertOnSubmit(d4);
                    Db.SubmitChanges();
                    dp = new DishProduct() { DId = d4.DishID, Product = p4, Quantity = 200 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d4.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d4.DishID, Product = p5, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d4.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d4.DishID, Product = p9, Quantity = 100 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d4.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d4.DishID, Product = p11, Quantity = 10 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d4.DishProducts.Add(dp);
                    Db.SubmitChanges();

                    Dish d5 = new Dish("Котлеты морковные", 1, 80, 0);
                    Db.Dishes.InsertOnSubmit(d5);
                    Db.SubmitChanges();
                    dp = new DishProduct() { DId = d5.DishID, Product = p2, Quantity = 300 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d5.DishProducts.Add(dp);
                    dp = new DishProduct() { DId = d5.DishID, Product = p10, Quantity = 20 };
                    Db.DishProducts.InsertOnSubmit(dp);
                    d5.DishProducts.Add(dp);
                    Db.SubmitChanges();

                    List<Ration> r = new List<Ration>();
                    r.Add(new Ration { Time = "9:00", DayWeek = 0, WeightDish = 80, Dish = d5 });
                    r.Add(new Ration { Time = "9:00", DayWeek = 0, WeightDish = 100, Dish = d1 });
                    r.Add(new Ration { Time = "12:00", DayWeek = 0, WeightDish = 150, Dish = d3 });
                    r.Add(new Ration { Time = "12:00", DayWeek = 0, WeightDish = 80, Dish = d5 });
                    r.Add(new Ration { Time = "18:00", DayWeek = 0, WeightDish = 200, Dish = d4 });

                    r.Add(new Ration { Time = "9:00", DayWeek = 1, WeightDish = 80, Dish = d5 });
                    r.Add(new Ration { Time = "9:00", DayWeek = 1, WeightDish = 150, Dish = d2 });
                    r.Add(new Ration { Time = "12:00", DayWeek = 1, WeightDish = 100, Dish = d4 });
                    r.Add(new Ration { Time = "12:00", DayWeek = 1, WeightDish = 80, Dish = d5 });
                    r.Add(new Ration { Time = "18:00", DayWeek = 1, WeightDish = 200, Dish = d1 });

                    r.Add(new Ration { Time = "9:00", DayWeek = 2, WeightDish = 100, Dish = d1 });
                    r.Add(new Ration { Time = "9:00", DayWeek = 2, WeightDish = 150, Dish = d3 });
                    r.Add(new Ration { Time = "12:00", DayWeek = 2, WeightDish = 100, Dish = d4 });
                    r.Add(new Ration { Time = "12:00", DayWeek = 2, WeightDish = 100, Dish = d2 });
                    r.Add(new Ration { Time = "18:00", DayWeek = 2, WeightDish = 100, Dish = d1 });
                    r.Add(new Ration { Time = "18:00", DayWeek = 2, WeightDish = 80, Dish = d5 });
                    Db.Rations.InsertAllOnSubmit(r);
                    Db.SubmitChanges();

                    List<DietApp_.Action> a = new List<DietApp_.Action>();
                    DietApp_.Action a1 = new DietApp_.Action { Name = "Бег", Energy = 8.14 };
                    DietApp_.Action a2 = new DietApp_.Action { Name = "Ходьба", Energy = 3.08 };
                    DietApp_.Action a3 = new DietApp_.Action { Name = "Плавание", Energy = 8.8 };
                    DietApp_.Action a4 = new DietApp_.Action { Name = "Теннис", Energy = 6.16 };
                    DietApp_.Action a5 = new DietApp_.Action { Name = "Катание на коньках", Energy = 4.62 };
                    DietApp_.Action a6 = new DietApp_.Action { Name = "Настольный теннис", Energy = 5.5 };
                    DietApp_.Action a7 = new DietApp_.Action { Name = "Езда на велосипеде", Energy = 3.52 };
                    a.Add(a1);
                    a.Add(a2);
                    a.Add(a3);
                    a.Add(a4);
                    a.Add(a5);
                    a.Add(a6);
                    a.Add(a7);
                    Db.Actions.InsertAllOnSubmit(a);
                    Db.SubmitChanges();

                    Schedule s = new Schedule { DayWeek = 0, Time = "10:00", Action = a2, Duration = 30 };
                    Db.Schedules.InsertOnSubmit(s);
                    Db.SubmitChanges();
                    s.Action = a2;
                    Db.SubmitChanges();

                    s = new Schedule { DayWeek = 0, Time = "06:00", Action = a1, Duration = 25 };
                    Db.Schedules.InsertOnSubmit(s);
                    Db.SubmitChanges();
                    s.Action = a1;
                    Db.SubmitChanges();

                    s = new Schedule { DayWeek = 1, Time = "06:00", Action = a1, Duration = 30 };
                    Db.Schedules.InsertOnSubmit(s);
                    Db.SubmitChanges();
                    s.Action = a1;
                    Db.SubmitChanges();

                    s = new Schedule { DayWeek = 1, Time = "11:00", Action = a7, Duration = 60 };
                    Db.Schedules.InsertOnSubmit(s);
                    Db.SubmitChanges();
                    s.Action = a7;
                    Db.SubmitChanges();

                    s = new Schedule { DayWeek = 2, Time = "19:00", Action = a3, Duration = 45 };
                    Db.Schedules.InsertOnSubmit(s);
                    Db.SubmitChanges();
                    s.Action = a3;
                    Db.SubmitChanges();

                    s = new Schedule { DayWeek = 2, Time = "15:00", Action = a4, Duration = 30 };
                    Db.Schedules.InsertOnSubmit(s);
                    Db.SubmitChanges();
                    s.Action = a3;
                    Db.SubmitChanges();

                    List<Product> l = new List<Product>();

                    Diet diet1 = new Diet("Без диеты", 0);
                    d = diet1;
                    Db.Diets.InsertOnSubmit(diet1);
                    Db.SubmitChanges();

                    Diet diet2 = new Diet("Диета №1", 30);
                    Db.Diets.InsertOnSubmit(diet2);
                    Db.SubmitChanges();
                    DietProduct dpr = new DietProduct { DId = diet2.DietID, Product = p1 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p2 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p3 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p4 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p5 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p6 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p9 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p10 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p11 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    diet2.DietProducts.Add(dpr);
                    Db.SubmitChanges();

                    diet2 = new Diet("Диета №2", 60);
                    Db.Diets.InsertOnSubmit(diet2);
                    Db.SubmitChanges();
                    dpr = new DietProduct { DId = diet2.DietID, Product = p1 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p2 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p3 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p4 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p5 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p6 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p7 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p9 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p11 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    diet2.DietProducts.Add(dpr);
                    Db.SubmitChanges();

                    diet2 = new Diet("Диета №3", 30);
                    Db.Diets.InsertOnSubmit(diet2);
                    Db.SubmitChanges();
                    dpr = new DietProduct { DId = diet2.DietID, Product = p1 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p2 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p3 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p4 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p5 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p6 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p7 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p8 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    dpr = new DietProduct { DId = diet2.DietID, Product = p9 };
                    Db.DietProducts.InsertOnSubmit(dpr);
                    diet2.DietProducts.Add(dpr);
                    Db.SubmitChanges();

                    MessageBox.Show("База данных успешно создана.");
                }

                name.Text = Name1;
                age.Text = Age1;
                height.Text = Height1;
                weight.Text = Weight1;
                waist.Text = WaistCircumference1;
                hip.Text = HipCircumference1;
                wrist.Text = WristCircumference1;
                if (gender == "M")
                {
                    radioButton1.IsChecked = true;
                    sex.IsChecked = false;
                }
                else { sex.IsChecked = true; radioButton1.IsChecked = false; }

                IQueryable<Person> PersonQuery = Db.Persons.Select(v => v);
                p = PersonQuery.FirstOrDefault();
                if (p == null)
                {
                    p = new Person();
                    IQueryable<Diet> q = from Diet in Db.Diets select Diet;
                    p.Diet = d;
                    d = q.FirstOrDefault();
                    Db.Persons.InsertOnSubmit(p);
                    Db.SubmitChanges();
                    preference.Text = preference_;
                    p.Diet = d;
                    diet.Text = d.Name;
                }
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
                if (name.Text != "" && age.Text != "" && height.Text != "" && weight.Text != ""
                           && waist.Text != "" && hip.Text != "" && wrist.Text != "")
                {
                    p.Name = name.Text;
                    p.Age = Convert.ToInt32(age.Text);
                    p.Height = Convert.ToInt32(height.Text);
                    p.Weight = Convert.ToInt32(weight.Text);
                    p.Sex = gender;
                    p.WaistCircumference = Convert.ToInt32(waist.Text);
                    p.HipCircumference = Convert.ToInt32(hip.Text);
                    p.WristCircumference = Convert.ToInt32(wrist.Text);
                    p.Ration = "";

                    //STUB!
                    /*p.Name = "Аня";
                    p.Age = 21;
                    p.Height = 174;
                    p.Weight = 63;
                    p.Sex = "F";
                    p.WaistCircumference = 62;
                    p.HipCircumference = 88;
                    p.WristCircumference = 16;
                    p.Preference = 0;*/

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
                    p.BioAge = (int)Math.Round(bioage);

                    if (d != null)
                    {
                        IQueryable<Diet> q = from Diet in context.Diets where d.DietID == Diet.DietID select Diet;
                        d = q.FirstOrDefault();
                    }
                    if (d == null)
                    {
                        IQueryable<Diet> q = from Diet in context.Diets select Diet;
                        d = q.FirstOrDefault();
                    }
                    p.Diet = d;

                    //insert
                    context.Persons.InsertOnSubmit(p);
                    context.SubmitChanges();

                    NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
                }
            }


        }

        private void sex_Checked(object sender, RoutedEventArgs e)
        {
            gender = "F";
        }

        private void diet_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (p.Name != "")
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

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name1 = name.Text;
        }

        private void age_TextChanged(object sender, TextChangedEventArgs e)
        {
            Age1 = age.Text;
        }

        private void height_TextChanged(object sender, TextChangedEventArgs e)
        {
            Height1 = height.Text;
        }

        private void weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            Weight1 = weight.Text;
        }

        private void wrist_TextChanged(object sender, TextChangedEventArgs e)
        {
            WristCircumference1 = wrist.Text;
        }

        private void hip_TextChanged(object sender, TextChangedEventArgs e)
        {
            HipCircumference1 = hip.Text;
        }

        private void waist_TextChanged(object sender, TextChangedEventArgs e)
        {
            WaistCircumference1 = waist.Text;
        }
    }
}