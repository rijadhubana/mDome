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
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage(NavigationPage nav)
        {
            InitializeComponent();
            nav.BarBackgroundColor = Color.Black;
            Detail = nav;
            IsPresented = false;
        }
    }
}