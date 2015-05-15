using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641







                                                       
    //                                  stayuptoo                                         
    //                              lateGotnothinginm                                     
    //                          ybrainThat'swhatpeoplesa                                  
    //                  yThat'swhatpeop           lesayIgo                                
    //               ontoomanydate                  sButIca                               
    //             n'tmakethemstay                   Atleas                               
    //             tthat'swhatpeopl                   esayT                               
    //             hat'swhatpe oplesa    yButIkeepcr  uisin                               
    //             gCan'tstop,won'tsto pmovingIt'slike Igot                               
    //             thismusicInmymind  ,sayingit'sgonnabealr                               
    //            ightC  ausetheplay  ersgonnaplay,play,pla                               
    //           yAndthehatersgonnaha te,hate,hat eBabyI'mj                               
    //          ustgonnashake,shake   ,shakeShakeitoffHeart                               
    //         breakersgonnabreak,break,breakAndthe  faker                                
    //        sgonn          afake,fake,fakeBab     yI'mju                                
    //       stgon                      nashake     ,shake                                
    //      ,shake                                 Shakei                                 
    //     toff,S                                 hakeit                                  
    //    offIne                                  vermis                                  
    //    sabea                      tI'm        lighti                                   
    //    ngup                      myfee tAn   dthat'                                    
    //    swha                      ttheydon't  seeTh                         at'swhatt   
    //   heydo                      n'tseeI'm  danci                        ngonmyownIma  
    //   kethe                     movesasIgo Andth                       at'swh    atth  
    //   eydon                     'tknowTha  t'swh                     attheyd    on'tk  
    //   nowBu                    tIkeepcru  isingC                   an'tsto     p,won   
    //   'tsto                    pgroovin   gIt'slikeIgotthismus   icInmym     ind,s     
    //    ayin                   git'sgon    nabealrightCausetheplayersgo      nnapl      
    //    ay,p                   lay,pla     yAndt   hehat   ersgonnaha      te,hat       
    //    e,ha                  teBabyI'      mju   stgonnashake,shak      e,shak         
    //    eShak               eitof fHear         tbreakersgonnabrea     k,break          
    //     ,bre             akAnd  thefake         rsgonnafake,fake,fa   keBabyI'         
    //     mjust            gonnashake,sha                     ke,shake    Shakeitof      
    //      f,Sha            keitoffHey,h              ey,h       eyJust  thin kwhil      
    //      eyoube              enge                   ttin        gdowna  ndoutabo       
    //       utthel                                iar              sAndt    hedi         
    //        rtydirty                            chea              tsoft     hewo        
    //           rldYouc                          ould              havebeengettin        
    // gdo        wntothissi                       ckbe           atMyexmanbrough         
    //thisnew    girlfriendShe'sli                  keo         hmygodB    u              
    //tI'mjustgonnas hakeAndtothefellaover           ther    ewithth                      
    //ehel lagoodhairWon'    tyoucomeonoverb abywecouldshake,shake                        
    // Caus  etheplayer         sgonnaplay, play,playAndthehate                           
    //  rsgo   nnahat         e,hate,hateB abyI' mjustgonnas                              
    //   hake,shake           ,shakeShake  itof                                           
    //    f.Shake              itoffHea   rtbr                                            
    //      eak                ersgon    nabr                                             
    //                          eak,br  eak,                                              
    //                           breakAndth                                               
    //                             efakers                                                
    //                               gon                      



namespace tipper_WP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            
        }

        private void newuserTitle_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void newuserTitle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(register_screen));
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(menu));
        }

        // Define a member variable for storing the signed-in user. 
        private MobileServiceUser user;

        // Define a method that performs the authentication process
        // using a Facebook sign-in. 
        private async System.Threading.Tasks.Task AuthenticateAsync()
        {
            while (user == null)
            {
                string message;
                try
                {
                    // Change 'MobileService' to the name of your MobileServiceClient instance.
                    // Sign-in using Facebook authentication.
                    user = await App.MobileService.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                    message =
                        string.Format("You are now signed in - {0}", user.UserId);
                }
                catch (InvalidOperationException)
                {
                    message = "You must log in. Login Required";
                }

                var dialog = new MessageDialog(message);
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
        }
        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            // Login the user and then load data from the mobile service.
            await AuthenticateAsync();
            string UID = user.UserId;
            // Hide the login button and load items from the mobile service.
            Frame.Navigate(typeof(register_screen), UID);
            
        }
    }
}
