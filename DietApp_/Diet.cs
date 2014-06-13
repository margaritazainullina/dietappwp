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
    public class Diet
    {
        public Diet() { }
        public Diet(string name, int duration)
        {
            Name = name;
            Duration = duration;
            DietProducts = new EntitySet<DietProduct>();
        }

        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true,
            IsPrimaryKey = true, AutoSync = AutoSync.OnInsert)]
        public int DietID
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
        public int Duration
        {
            get;
            set;
        }

        [Association(ThisKey = "DietID", OtherKey = "DId", Storage = "DietProducts")]
        public EntitySet<DietProduct> DietProducts
        {
            get;
            set;
        }

    }

}