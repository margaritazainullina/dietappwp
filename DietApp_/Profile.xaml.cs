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

namespace DietApp
{
    public partial class Profile : PhoneApplicationPage
    {
        Boolean a = false;
        Boolean b = false;
        public Profile()
        {
            InitializeComponent();
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                IQueryable<Person> PersonQuery = from Person in Db.Persons select Person;
                Person p = PersonQuery.FirstOrDefault();
                age.Text = p.Age + "";
                name.Text = p.Name;
                height.Text = p.Height + "";
                weight.Text = p.Weight + "";
                fat.Text = p.PercentFat + "";
                bioage.Text = p.BioAge + "";
                if (p.Sex == "m")
                {
                    M.IsChecked = true;
                    F.IsChecked = false;
                }
                else
                {
                    F.IsChecked = true;
                    M.IsChecked = false;
                }

                IQueryable<IdealParameter> IpQuery = from IdealParameter in Db.IdealParameters
                                                     where IdealParameter.Height_min <= p.Height
                                                     where IdealParameter.Height_max >= p.Height
                                                     where IdealParameter.ConstitutionId == p.ConstitutionId
                                                     select IdealParameter;
                IdealParameter ip = IpQuery.FirstOrDefault();

                double idealW = Math.Round(((ip.Weight_max + ip.Weight_min) / 2), 1);
                ideal.Text = idealW + "";

                if (p.Weight > ip.Weight_min) info.Text = "Вам стоит сбросить вес на " + (ip.Weight_max - p.Weight) + "кг";
                else if (p.Weight < ip.Weight_max) info.Text = "Вам стоит набрать вес на " + (p.Weight - ip.Weight_min) + "кг";
                else info.Text = "Ваш вес в норме";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DayList.xaml", UriKind.Relative));
        }

        private void diet_SelectionChanged(object sender, RoutedEventArgs e)
        {
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
    }
}