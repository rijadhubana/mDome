using mDome.MobileApp.ViewModels;
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
    public partial class NewsFeedPage : ContentPage
    {
        public NewsFeedPage()
        {
            InitializeComponent();
            BindingContext = vm = new NewsFeedViewModel();
        }
        NewsFeedViewModel vm = null;
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PostPage(vm.selectedPost.PostId));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewPostPage());
        }
    }
}