using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using DietApp;

namespace DietApp
{
    [Table]
    public class Ration
    {
       [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true,
            IsPrimaryKey = true, AutoSync = AutoSync.OnInsert)]
        public int RationID
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public string Time
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int DayWeek
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int WeightDish
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int DId
        {
            get;
            set;
        }
        private EntityRef<Dish> dish;
        [Association(ThisKey = "DId", OtherKey = "DishID",
            Storage = "dish", IsForeignKey = true)]
        public Dish Dish
        {
            get { return dish.Entity; }
            set { dish.Entity = value; }
        }
    }
}
