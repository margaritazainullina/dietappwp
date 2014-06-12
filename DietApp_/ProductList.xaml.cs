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
    public partial class ProductList : PhoneApplicationPage
    {
        public ProductList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddProductPage.xaml", UriKind.Relative));
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string text = "";

            CheckBox chkStatus = (CheckBox)sender;

            if (chkStatus.IsChecked == true)
            {
                text = chkStatus.CommandParameter.ToString();
            }
        }
    }
}