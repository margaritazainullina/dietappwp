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

namespace DietApp_
{
    [Table]
    public class Action
    {
        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true,
             IsPrimaryKey = true, AutoSync = AutoSync.OnInsert)]
        public int ActionID
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
        public double Energy
        {
            get;
            set;
        }                
    }
}
