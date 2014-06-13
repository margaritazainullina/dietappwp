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
using DietApp_;

namespace DietApp
{
    [Table]
    public class Person
    {
        public Person()
        {
            diet = new EntityRef<Diet>();
            Name = "";
            Age = 0;
            Sex = "M";
            Height = 0;
            Weight = 0;
            PercentFat = 0;
            ConstitutionId = 0;
            HipCircumference = 0;
            WristCircumference = 0;
            BioAge = 0;
            Ration = "";
            Preference = 0;

        }
        [Column(CanBeNull = false, IsDbGenerated = true, IsPrimaryKey = true)]
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
        [Column(CanBeNull = false)]
        public int DietID
        {
            get;
            set;
        }
        private EntityRef<Diet> diet;
        [Association(ThisKey = "DietID", OtherKey = "DietID",
            Storage = "diet", IsForeignKey = true)]
        public Diet Diet
        {
            get { return diet.Entity; }
            set { diet.Entity = value; }
        }
    }
}