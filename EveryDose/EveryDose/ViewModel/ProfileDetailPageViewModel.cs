using EveryDose.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EveryDose.ViewModel
{
    public class ProfileDetailPageViewModel : INotifyPropertyChanged
    {
        private Profile profile;

        private string firstname;
        private string lastname;
        private string dateOfBirth;
        private string fullname;
        private string dob;
        private bool isSaveButtonVisible;
        

        public string Firstname
        {
            get { return firstname; }
            set
            {
                if (firstname != value)
                {
                    firstname = value;
                    OnPropertyChanged(nameof(Firstname));
                    UpdateSaveButtonVisibility();
                }
            }
        }

        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    OnPropertyChanged(nameof(Lastname));
                    UpdateSaveButtonVisibility();
                }
            }
        }

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (dateOfBirth != value)
                {
                    dateOfBirth = value;
                    OnPropertyChanged(nameof(DateOfBirth));
                    UpdateSaveButtonVisibility();
                }
            }
        }
        public string Fullname
        {
            get { return fullname; }
            set
            {
                if (firstname != value)
                {
                    fullname = value;
                    OnPropertyChanged(nameof(fullname));
                    
                }
            }
        }

        public string Dob
        {
            get { return dob; }
            set
            {
                if (dob != value)
                {
                    dob = value;
                    OnPropertyChanged(nameof(dob));

                }
            }
        }
        public bool IsSaveButtonVisible
        {
            get { return isSaveButtonVisible; }
            set
            {
                if (isSaveButtonVisible != value)
                {
                    isSaveButtonVisible = value;
                    OnPropertyChanged(nameof(IsSaveButtonVisible));
                }
            }
        }
        private void UpdateSaveButtonVisibility()
        {
            IsSaveButtonVisible = !string.IsNullOrWhiteSpace(Firstname) ||
                                  !string.IsNullOrWhiteSpace(Lastname) ||
                                  DateOfBirth != default;
        }



        public ICommand SaveCommand { get; }

        

        private async void OnSave()
        {
            
            profile.FirstName = Firstname;
            profile.LastName = Lastname;
            profile.DateOfBirth = DateOfBirth;

            // Save the profile to the database
            await App.Database.UpdateProfileAsync(profile);

            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public ProfileDetailPageViewModel(Profile profile)
        {
            this.profile = profile;
            Firstname = profile.FirstName;
            Lastname = profile.LastName;
            DateOfBirth = profile.DateOfBirth;
            Fullname = profile.FullName;
            Dob = profile.DateOfBirth;
            SaveCommand = new Command(OnSave);
            UpdateSaveButtonVisibility();
            IsSaveButtonVisible = false;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
