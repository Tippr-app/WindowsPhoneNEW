using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace tipper_WP
{
    public class postuser
    {

         private MobileServiceCollection<User, User> users;
        private IMobileServiceTable<User> userTable = App.MobileService.GetTable<User>();
        //private IMobileServiceSyncTable<TodoItem> todoTable = App.MobileService.GetSyncTable<TodoItem>(); // offline sync

      

        private async Task InsertTodoItem(User user)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await userTable.InsertAsync(user);
            users.Add(user);

            //await SyncAsync(); // offline sync
        }

      

    

   

        public async void Send_usr(User usr)
        {
            
            await InsertTodoItem(usr);
        }

      

    }
}
