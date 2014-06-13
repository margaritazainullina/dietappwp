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

namespace DietApp_
{
    public partial class DayList2 : PhoneApplicationPage
    {
        public DayList2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddSchedule.dayIdx = ListboxDay.SelectedIndex;
            NavigationService.Navigate(new Uri("/AddSchedule.xaml", UriKind.Relative));
        }
    }
}