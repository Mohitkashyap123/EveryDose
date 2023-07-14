using EveryDose.Model;
using EveryDose.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EveryDose.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand AddButtonCommand { get; }

        private async void ExecuteAddButtonCommand()
        {
            
            await Application.Current.MainPage.Navigation.PushAsync(new NewProfilePageView());
        }
        private ObservableCollection<Profile> profiles;
        public ICommand NavigateToProfileDetailCommand { get; }

        public ObservableCollection<Profile> Profiles
        {
            get { return profiles; }
            set
            {
                profiles = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            LoadProfiles();
            NavigateToProfileDetailCommand = new Command<Profile>(ExecuteNavigateToProfileDetailCommand);
            AddButtonCommand = new Command(ExecuteAddButtonCommand);
        }

        public async void LoadProfiles()
        {
            var profiles = await App.Database.GetProfileAsync();
            Profiles = new ObservableCollection<Profile>(profiles);

        }

        private void ExecuteNavigateToProfileDetailCommand(Profile profile)
        {
            Application.Current.MainPage.Navigation.PushAsync(new ProfileDetailPageView(profile));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
