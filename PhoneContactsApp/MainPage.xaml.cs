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
        public static TextBlock  contactList { get; set; }
        public const string TEXT_FILE_NAME = "PhoneContacts.txt";
       string contact = "";
       public static string str = "";
       Contacts ContactsValue;
       string textFilePath = "";

        public MainPage()
        {
            this.InitializeComponent();
            contactList = ContactsList;
            ContactsValue = PhoneContactsApp.Contacts.GetPhoneContacts();
            this.DataContext = ContactsValue;
        }

        private void createContactPage_click(object sender, RoutedEventArgs e)
        {
            EnterName.Visibility = Visibility.Visible;
            CreateContactLbl.Visibility =  Visibility.Visible;
            CreateContactButn.Visibility =  Visibility.Visible;
            EnterPhoneNumber.Visibility = Visibility.Visible;
            NumberTextBox.Visibility = Visibility.Visible;
            NameTextbox.Visibility =  Visibility.Visible;
            newContact.Visibility = Visibility.Collapsed;
            TxtBlockCreateNewContact.Visibility = Visibility.Collapsed;
        }

        private async void createContact_click(object sender, RoutedEventArgs e)
        {
            if (NameTextbox.Text != "" && NumberTextBox.Text != "")
            {
                contact =  NameTextbox.Text.ToUpper() + " , " + NumberTextBox.Text + '.' + Environment.NewLine + contact;
                textFilePath = await FileHelper.WriteTextFile(TEXT_FILE_NAME, contact);
                NameTextbox.Text = "";
                NumberTextBox.Text = "";
                str = await FileHelper.ReadTextFile(TEXT_FILE_NAME);
                str = str.Replace(",", "number is");
            }
            ContactsList.Text = str;
        }       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ContactsPage));
            ContactsPage.ContactTextBlock.Text = str;           
        }

        private async void findContactNumber_click(object sender, RoutedEventArgs e)
        {

            string number = Contacts.findNumber(enterContact.Text.ToUpper(), await Contacts.GetPhContacts());
 
             DisplayContact.Text = " The Number for "+ enterContact.Text +" is "+number;
        }

        private void enterContact_GotFocus(object sender, RoutedEventArgs e)
        {
            enterContact.Text = "";
        }
              

        private void NumberTextBox_GettingFocus(UIElement sender, GettingFocusEventArgs args)
        {
            NumberTextBox.Text = "";
        }


    }
}
