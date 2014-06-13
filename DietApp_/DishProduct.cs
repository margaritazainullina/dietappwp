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
    public class DishProduct
    {
        /*public DishProduct() { }
        public DishProduct(int quantity, Product p)
        {
            Quantity = quantity;
            product.Entity = p;
            PId = p.ProductID;
        }
        */
        [Column(CanBeNull = false, IsDbGenerated = true, IsPrimaryKey = true)]
        public int DPID
        {
            get;
            set;
        }
        [Column(IsPrimaryKey = true)]
        public int DId
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int PId
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int Quantity
        {
            get;
            set;
        }

        private EntityRef<Product> product;
        [Association(ThisKey = "PId", OtherKey = "ProductID",
            Storage = "product", IsForeignKey = true)]
        public Product Product
        {
            get { return product.Entity; }
            set { product.Entity = value; }
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
