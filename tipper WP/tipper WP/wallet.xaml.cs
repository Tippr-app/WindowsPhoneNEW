﻿using System;
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
using System.Net;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace tipper_WP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class wallet : Page
    {
        public string bal;

        public wallet()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String thing = e.Parameter as string; 
            
            if(thing != null)
            {
                if (thing.Length > 0)
                {
                    balenceTitle_Copy.Text = "$" + thing;
                }
                else
                {
                    balenceTitle_Copy.Text = "$0.00";
                }
            }


        }


        public async void GetaString()
        {
            try
            {
                //Create HttpClient
                HttpClient httpClient = new HttpClient();

                //Define Http Headers
                httpClient.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                //Call
                 bal = await httpClient.GetStringAsync(
                    new Uri("http://tippr.morrislowitz.com/dummydata/senderbalence_old"));
                //Replace current URL with your URL
            }

            catch (Exception ex)
            {
                //....
            }
        }

        private void settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(tipping));
        }

        private void getbal()
        {
            string walletUri = "http://tippr.morrislowitz.com/dummydata/senderbalence_old";
                HttpWebRequest shit = (HttpWebRequest)HttpWebRequest.Create(walletUri);
            //get
                shit.BeginGetResponse(GetAvatarImageCallback, shit);

        }

        void GetAvatarImageCallback(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                try
                {
                    WebResponse response = request.EndGetResponse(result);
                 ;
                }
                catch (WebException e)
                {
                    
                    return;
                }
            }
        }
        private void goback_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(menu));
        }

        private void add_funds_button_Click(object sender, RoutedEventArgs e)
        {
            GetaString();
               
            Frame.Navigate(typeof(wallet),"50.00");
        }
    }
}
