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
using DietApp;

namespace DietApp_
{
    public partial class AddAction : PhoneApplicationPage
    {
        public AddAction()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (MyDataContext Db = new MyDataContext(MainPage.strConnectionString))
            {
                Action a = new Action { Name = name.Text, Energy = Convert.ToDouble(energy.Text)};
                NavigationService.Navigate(new Uri("/ActionList.xaml", UriKind.Relative));
                Db.Actions.InsertOnSubmit(a);
                Db.SubmitChanges();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ActionList.xaml", UriKind.Relative)); 
        }
    }
}