using EveryDose.Model;
using EveryDose.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace EveryDose.ViewModel
{
    public class NewProfileViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string dateOfBirth;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public Command SaveCommand { get; }

        public NewProfileViewModel()
        {
            SaveCommand = new Command(SaveProfile);
        }

        private async void SaveProfile()
        {
            // Create a new profile object with the input data
            Profile profile = new Profile
            {
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth
            };

            // Save the profile to the database
            await App.Database.SaveProfileAsync(profile);

            // Reset the input fields
            FirstName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = string.Empty;

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

