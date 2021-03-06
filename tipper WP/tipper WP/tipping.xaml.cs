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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace tipper_WP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class tipping : Page
    {
        data bar;
        string code;
        public tipping()
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
            bar = e.Parameter as data;
            code = bar.code;
            scannedtext.Text = code; 
        }

        private void confirmAmount_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(confrimtip));
        }

        private void goback_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(test));
        }

        private void quickTip1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(tipping));
        }

        private void quickTip2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(tipping));
        }

        private void quickTip3_Click(object sender, RoutedEventArgs e)
        {
            ammountBox.Text = "5.00";
            //Frame.Navigate(typeof(tipping));
        }
    }
}
