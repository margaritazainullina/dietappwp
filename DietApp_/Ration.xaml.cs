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
    public partial class Page2 : PhoneApplicationPage
    {
        Boolean a = false;
        public Page2()
        {
            InitializeComponent();
        }

        private void day_SelectionChanged(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DaysList.xaml", UriKind.Relative));
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddActivity.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RationOptimisation.xaml", UriKind.Relative));
        }

        private void textBox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DaysList.xaml", UriKind.Relative));
        }

        private void day_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DayList.xaml", UriKind.Relative));
        }
    }
}