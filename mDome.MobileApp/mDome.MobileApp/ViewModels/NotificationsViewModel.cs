using mDome.MobileApp.Helper;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class NotificationsViewModel : BaseViewModel
    {
        private readonly APIService _notificationService = new APIService("Notification");
        public NotificationsViewModel()
        {
            InitCommand = new Command(async () => await Init());
            DeleteNotificationCommand = new Command(async () => await DeleteNotification());
            InitCommand.Execute(null);
        }
        public ICommand InitCommand { get; set; }
        public ICommand DeleteNotificationCommand { get; set; }
        public ObservableCollectionFast<Notification> NotificationList { get; set; } = new ObservableCollectionFast<Notification>();
        string _notificationNumber;
        public string NotificationNumber
        {
            get
            {
                return _notificationNumber;
            }

            set
            {
                _notificationNumber = value;
                OnPropertyChanged("NotificationNumber");
            }
        }
        public int NotifInt { get; set; }
        Model.Notification _selectedNotification;
        public Model.Notification SelectedNotification
        {
            get
            {
                return _selectedNotification;
            }

            set
            {
                _selectedNotification = value;
                OnPropertyChanged("SelectedNotification");
            }
        }
        private async Task Init()
        {
            var notifications = await _notificationService.Get<List<Model.Notification>>(new NotificationSearchRequest()
            { UserId = APIService.loggedProfile.UserId });
            var sorted = notifications.OrderByDescending(a => a.NotifDateTime).ToList();
            NotificationList.AddRange(sorted);
            NotifInt = notifications.Count;
            NotificationNumber = "Notifications: " + NotifInt.ToString();
        }
        private async Task DeleteNotification()
        {
            NotificationList.Remove(SelectedNotification);
            await _notificationService.Delete<Notification>(SelectedNotification.NotificationId);
            SelectedNotification = null;
            NotifInt --;
            NotificationNumber = "Notifications: " + NotifInt.ToString();
        }
    }
}
