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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace tipper_WP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class menu : Page
    {

        string fuck;
        public menu()
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
            fuck = e.Parameter as string;
           
        }

        private void wallent_button__Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(wallet),fuck);
        }

        private void goback_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void goback_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(menu));
        }

        private void settings_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }

        private void Tip_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(test));
            
        }
    }
}
