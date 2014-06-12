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

namespace DietApp
{
    [Table]
    public class Person
    {
        [Column(CanBeNull = false, IsDbGenerated=true, IsPrimaryKey=true) ]
        public int PersonID
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
        public int Age
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public string Sex
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Height
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Weight
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int ConstitutionId
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double PercentFat
        {
            get;
            set;
        }
         [Column(CanBeNull = false)]
        public int WaistCircumference
        {
            get;
            set;
        }
         [Column(CanBeNull = false)]
        public int HipCircumference
        {
            get;
            set;
        }
         [Column(CanBeNull = false)]
        public int WristCircumference
        {
            get;
            set;
        }
         [Column(CanBeNull = false)]
        public int BioAge
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public string Diet
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public string Ration
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int Preference
        {
            get;
            set;
        }
    }
}