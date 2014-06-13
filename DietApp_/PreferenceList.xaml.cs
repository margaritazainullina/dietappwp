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
    public partial class PreferenceView : PhoneApplicationPage
    {
        public PreferenceView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainPage.p.Preference = ListboxPreference.SelectedIndex;
            var v = ListboxPreference.SelectedItem;
            TextBlock s = v as TextBlock;
            MainPage.preference_ = s.Text;
            MainPage.pref = ListboxPreference.SelectedIndex;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}