using mDome.MobileApp.ViewModels;
using mDome.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mDome.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationListPage : ContentPage
    {
        public NotificationListPage()
        {
            InitializeComponent();
            BindingContext = vm = new NotificationsViewModel();
        }
        NotificationsViewModel vm;
        private void DeleteNotification(object sender, SelectedItemChangedEventArgs e)
        {
            vm.DeleteNotificationCommand.Execute(null);
        }
    }
}