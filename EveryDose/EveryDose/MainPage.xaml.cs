using EveryDose.Model;
using EveryDose.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EveryDose
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new MainPageViewModel();
            if (BindingContext is MainPageViewModel viewModel)
            {
                viewModel.LoadProfiles();
            }
        }
        private void OnProfileSelected(object sender, SelectionChangedEventArgs e)
        {
            if (BindingContext is MainPageViewModel viewModel && e.CurrentSelection.Count > 0)
            {
                var selectedProfile = e.CurrentSelection[0] as Profile;
                viewModel.NavigateToProfileDetailCommand.Execute(selectedProfile);
                collectionView.SelectedItem = null;
            }
        }
    }
}
