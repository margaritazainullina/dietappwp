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
    public class Product
    {
        public Product() { }
        public Product(string name, int iDType, double protein, double fat, double carbohydrates, int calories, double cost, double acidity, int measureId)
        {
            Name = name;
            //0 - сырое раст. происх.
            //1 - обраб. раст. происх.
            //2 - жив. происх
            //3 - мясо/рыба
            IDType = iDType;
            Protein = protein;
            Carbohydrates = carbohydrates;
            Fat = fat;
            Calories = calories;
            Cost = cost;
            Acidity = acidity;
            //0 - г.
            //1 - шт.
            //2 - мл.
            MeasureID = measureId;
        }

        [Column(CanBeNull = false, IsDbGenerated = true, IsPrimaryKey = true)]
        public int ProductID
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
        public int IDType
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Protein
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Carbohydrates
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Fat
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int Calories
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Cost
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Acidity
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int MeasureID
        {
            get;
            set;
        }
    }
}