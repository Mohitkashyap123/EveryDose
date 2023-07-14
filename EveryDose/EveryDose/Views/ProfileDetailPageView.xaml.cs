using EveryDose.Model;
using EveryDose.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EveryDose.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileDetailPageView : ContentPage
    {
        public ProfileDetailPageView(Profile profile)
        {
            InitializeComponent();
            BindingContext = new ProfileDetailPageViewModel(profile);
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}