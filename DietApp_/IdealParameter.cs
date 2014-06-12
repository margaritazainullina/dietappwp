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
    public class IdealParameter
    {
        public IdealParameter() { }
        public IdealParameter(double height_min, double height_max, double weight_min, double weight_max, string sex, int constitution)
        {
            Height_min = height_min;
            Height_max = height_max; 
            Weight_min = weight_min;
            Weight_max = weight_max;
            Sex = sex;
            ConstitutionId = constitution;
        }
                      
        [Column(CanBeNull = false, IsDbGenerated=true, IsPrimaryKey=true) ]
        public int ParameterID
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Height_min
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Height_max
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Weight_min
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public double Weight_max
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
        public int ConstitutionId
        {
            get;
            set;
        }
    }
}