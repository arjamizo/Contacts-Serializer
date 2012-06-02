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
using Microsoft.Phone.UserData;

namespace ContactsSerializer
{

    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            (FindName("result") as TextBox).Text = "press load to serialize contacts\n";
        }

        private void getContacts_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = "loaded";
            (sender as Button).UpdateLayout();
            (sender as Button).Click -= getContacts_Click; //remove click handler
            //Thread.Sleep(1000);
            //(sender as Button).Visibility = Visibility.Collapsed;
            fillContactsTextBox();
            //MessageBox.Show("udało się");
        }
        String str="";
        private string fillContactsTextBox()
        {
            Contacts cons = new Contacts();
            str = "";
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);
            cons.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #1");
            return str;
        }

        void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            //Do something with the results.
            //MessageBox.Show(e.Results.Count().ToString());
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Contact con in e.Results)
            {
                sb.AppendLine("\"" + con.DisplayName + "\", "+con.PhoneNumbers.FirstOrDefault());
            }

            str = sb.ToString(); 
            (FindName("result") as TextBox).Text = str;
            (FindName("result") as TextBox).UpdateLayout();
            //MessageBox.Show(str);
        }
    }
}