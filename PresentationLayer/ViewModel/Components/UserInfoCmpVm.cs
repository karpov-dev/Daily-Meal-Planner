using Business_Layer;
using Service_Layer;
using PresentationLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.ViewModel.Components
{
    class UserInfoCmpVm : ModelPropertyChanged
    {
        private DataService _dataService = new DataService();
        private User _user;

        public UserInfoCmpVm()
        {
            _user = _dataService.GetUser();
        }

        public double Weight
        {
            get => _user.Weight;
            set
            {
                _user.Weight = value;
                OnPropertyChanged();
                UpdateUserInfo();
            }
        }
        public double Height
        {
            get => _user.Height;
            set
            {
                _user.Height = value;
                OnPropertyChanged();
                UpdateUserInfo();
            }
        }
        public int Age
        {
            get => _user.Age;
            set
            {
                _user.Age = value;
                OnPropertyChanged();
                UpdateUserInfo();
            }
        }

        public double BMR => _user.GetBMR();
        public double ARM => _user.GetARM();
        public double Calories => _user.GetCalories();


        private void UpdateUserInfo()
        {
            OnPropertyChanged("BMR");
            OnPropertyChanged("ARM");
            OnPropertyChanged("Calories");
        }
    }
}
