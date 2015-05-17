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
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace tipper_WP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class register_screen : Page
    {
        public register_screen()
        {
            this.InitializeComponent();
        }
        public string UID2;
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            UID2 = e.Parameter as string;
            
        }
        /// <summary>
        /// creation of user accounts 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void confirmButtonUser_Click(object sender, RoutedEventArgs e)
        {
            //dummy code 
            string id = UID2; 
            //user account object 
            //public Account_Creation(string _customerID, string _firstName, string _lastNAme, string _email, string _streetAddress, string _city, string _state, string _zip, string _phone, string _ccNumber, string _exp, string _ccv)
            Account_Creation new_account = new Account_Creation(id, firstName.Text, lastName.Text, email.Text, address.Text, state.Text, city.Text, zip.Text, phone.Text, cardNum.Text, exp.Text, ccv.Text);

            
            //if (!field_check())
            //{
            //    var dialog = new MessageDialog("Fields cannot be left blank");
            //    dialog.Commands.Add(new UICommand("OK"));
            //    await dialog.ShowAsync();
            //    Frame.Navigate(typeof(register_screen));//fuck you people 
            //} 
            new_account.create_account();
            
                if (new_account.create_account())
                {
                    var dialog = new MessageDialog("Your Account Has Been Created");
                    dialog.Commands.Add(new UICommand("OK"));
                    await dialog.ShowAsync();
                    Frame.Navigate(typeof(confirm));
                }
            
                else
                {
                    var dialog = new MessageDialog("Your Account Has Been Created");
                    dialog.Commands.Add(new UICommand("OK"));
                    await dialog.ShowAsync();
                    Frame.Navigate(typeof(confirm));
                }
        }

        private bool field_check()
        {
            if(email.Text == "")
            {return false;}
            if(firstName.Text == "")
            {return false;}
             if(lastName.Text == "")
            {return false;}
            if(pass.Password != confirmpass.Password)
            {return false;}
            if(address.Text == "")
            {return false;}
            if(state.Text == "")
            {return false;}
            if(city.Text == "")
            {return false;}
            if(zip.Text == "")
            {return false;}
            if(cardNum.Text == "")
            {return false;}
            if(exp.Text == "")
            {return false;}
            if (ccv.Text == "")
            { return false; }



            else
            {
                return true;
            }
        }



    }
}
