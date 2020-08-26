using mDome.MobileApp.Helper;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class ReportViewModel : BaseViewModel
    {
        private readonly APIService _requestService = new APIService("Request");
        public ReportViewModel()
        {
            InitCommand = new Command(async () => await Init());
            NewRequestCommand = new Command(async () => await NewRequest());
            InitCommand.Execute(null);
        }
        public ICommand InitCommand { get; set; }
        public ICommand NewRequestCommand { get; set; }
        public int OpenReportsNumber { get; set; }
        string _openReportsString;
        public string OpenReportsString
        {
            get
            {
                return _openReportsString;
            }

            set
            {
                _openReportsString = value;
                OnPropertyChanged("OpenReportsString");
            }
        }
        public ObservableCollectionFast<Model.Request> Reports { get; set; } = new ObservableCollectionFast<Model.Request>();
        private async Task Init()
        {
            var requests = await _requestService.Get<List<Request>>(new RequestSearchRequest() { UserId = APIService.loggedProfile.UserId });
            Reports.AddRange(requests);
            OpenReportsNumber = requests.Count;
            OpenReportsString = "Open reports/requests: " + OpenReportsNumber.ToString();
        }
        private async Task NewRequest()
        {
            string popup = await Application.Current.MainPage.DisplayPromptAsync("New request", "Please type your request in the text box.");
            if (string.IsNullOrWhiteSpace(popup))
                return;
            else
            {
                var returnedReq = await _requestService.Insert<Request>(new RequestUpsertRequest()
                {
                    NameOfUser = APIService.loggedProfile.Username,
                    RequestDate = DateTime.Now,
                    RequestText = popup,
                    UserId = APIService.loggedProfile.UserId
                });
                Reports.Add(returnedReq);
                OpenReportsNumber++;
                OpenReportsString= "Open reports/requests: " + OpenReportsNumber.ToString();
                await Application.Current.MainPage.DisplayAlert("Success", "Request successfully added!", "OK");
            }
        }

    }
}
