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
    public partial class NewProfilePageView : ContentPage
    {
        public NewProfilePageView()
        {
            InitializeComponent();
            NewProfileViewModel viewModel = new NewProfileViewModel();

            // Set the view model as the BindingContext
            BindingContext = viewModel;
        }
        private void OnCancelClicked(object sender, EventArgs e)
        {
            
            Navigation.PopAsync();
        }
    }
    
}