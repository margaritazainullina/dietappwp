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
using System.Collections.Generic;

namespace DietApp
{
    [Table]
    public class Dish
    {
        public Dish() { }
        public Dish(string name, int type, int portion, int measure)// List<DishProduct> dp1)
        {
            Name = name;
            Type = type;
            Portion = portion;
            Measure = measure;
            DishProducts = new EntitySet<DishProduct>();            
        }

        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true,
            IsPrimaryKey = true, AutoSync = AutoSync.OnInsert)]
        public int DishID
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public string Name
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int Type
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int Portion
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int Measure
        {
            get;
            set;
        }

               
        [Association(ThisKey = "DishID", OtherKey = "DId", Storage = "DishProducts")]
        public EntitySet<DishProduct> DishProducts
        {
             get; set; 
        }

    }

}