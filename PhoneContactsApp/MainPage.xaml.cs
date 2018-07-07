using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PhoneContactsApp
{
   
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const string TEXT_FILE_NAME = "PhoneContacts.txt";
        string contact = "";
        string str = "";
        Contacts x;

        public MainPage()
        {
            this.InitializeComponent();
            x = PhoneContactsApp.Contacts.GetPhoneContacts();
            this.DataContext = x;
        }

        private void createContactPage_click(object sender, RoutedEventArgs e)
        {

        }

        private async void createContact_click(object sender, RoutedEventArgs e)
        {
            contact = contact + Environment.NewLine + NameTextbox.Text + " number is " + NumberTextBox.Text + '.';
            string textFilePath = await FileHelper.WriteTextFile(TEXT_FILE_NAME, contact);
            NameTextbox.Text = "";
            NumberTextBox.Text = "";
            str = await FileHelper.ReadTextFile(TEXT_FILE_NAME);
            Contacts.Text = str;
        }

        private void readContactNumber_click(object sender, RoutedEventArgs e)
        {   
           DisplayContact.Text = str;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ContactsPage));
        }

        private void Contacts_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
