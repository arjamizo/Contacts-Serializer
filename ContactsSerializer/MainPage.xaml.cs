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
using System.Threading;

namespace ContactsSerializer
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            (FindName("result") as TextBox).Text = "Hello World\n";
        }

        private void getContacts_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = "cze";
            (sender as Button).UpdateLayout();
            (FindName("result") as TextBox).Text += "How are you?\n";
            (FindName("result") as TextBox).UpdateLayout();
            MessageBox.Show("udało się");
        }
    }
}