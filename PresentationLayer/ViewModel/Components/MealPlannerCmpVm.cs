using Business_Layer;
using PresentationLayer.Service;
using PresentationLayer.Model;
using PresentationLayer.View.Windows;
using Service_Layer;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;

namespace PresentationLayer.ViewModel.Components
{
    class MealPlannerCmpVm : ModelPropertyChanged
    {
        private DataService _dataService = DataService.GetInstance();
        private User _user;
        private RelayCommand _addMealTime;
        private RelayCommand _deleteMealTime;
        private RelayCommand _deleteSelectedProduct;
        private RelayCommand _createPDF;

        public ObservableCollection<MealTime> MealTimes => new ObservableCollection<MealTime>(_dataService.GetMealTimes());
        public ObservableCollection<Product> Products
        {
            get
            {
                if(SelectedMealTime != null )
                {
                    return new ObservableCollection<Product>(SelectedMealTime.Products);
                }
                return new ObservableCollection<Product>();
            }
        }

        public string SelectedUserActivity
        {
            get
            {
                switch ( _user.Activity )
                {
                    case Activity.Low: return _user.GetActivities()[0];
                    case Activity.Normal: return _user.GetActivities()[1];
                    case Activity.Average: return _user.GetActivities()[2];
                    case Activity.High: return _user.GetActivities()[3];
                    default: return _user.GetActivities()[1];
                }
            }
            set
            {
                switch ( value )
                {
                    case "Низкая": _user.Activity = Activity.Low; break;
                    case "Средняя": _user.Activity = Activity.Normal; break;
                    case "Выше средней": _user.Activity = Activity.Average; break;
                    case "Высокая": _user.Activity = Activity.High; break;
                }
                OnPropertyChanged();
                UpdateComponent();
            }
        }
        public MealTime SelectedMealTime
        {
            get => InteractionCmp.ActiveMealTime;
            set
            {
                InteractionCmp.ActiveMealTime = value;
                OnPropertyChanged("Products");
                OnPropertyChanged();
            }
        }
        public Product SelectedProduct { get; set; }

        public int UserAge
        {
            get => _user.Age;
            set
            {
                _user.Age = value;
                OnPropertyChanged();
                UpdateComponent();
            }
        }
        public double UserWeight
        {
            get => _user.Weight;
            set
            {
                _user.Weight = value;
                OnPropertyChanged();
                UpdateComponent();
            }
        }
        public double UserHeight
        {
            get => _user.Height;
            set
            {
                _user.Height = value;
                OnPropertyChanged();
                UpdateComponent();
            }
        }
        public double UserBMR => _user.GetBMR();
        public double UserARM => _user.GetARM();
        public double UserCalories => _user.GetCalories();
        public List<string> UserActivities => _user.GetActivities();
        public double TotalCalories
        {
            get
            {
                double totalCalories = 0;
                foreach(MealTime mealTime in MealTimes )
                {
                    totalCalories += mealTime.GetCalories();
                }
                return totalCalories;
            }
            set { }
        }

        public MealPlannerCmpVm()
        {
            _user = _dataService.GetUser();
            SetDefaultMealTime();
        }

        public RelayCommand AddMealTimeCommand => _addMealTime ?? ( _addMealTime = new RelayCommand(obj =>
        {
            AddMealTime addMealTimeWindow = new AddMealTime();
            addMealTimeWindow.Show();
            addMealTimeWindow.Closed += AddMealTimeWindow_Closed;
            SetDefaultMealTime();
        }) );
        public RelayCommand DeleteMealTime => _deleteMealTime ?? ( _deleteMealTime = new RelayCommand(obj =>
         {
             if(SelectedMealTime != null )
             {
                 _dataService.RemoveMealTime(SelectedMealTime);
                 UpdateComponent();
                 SetDefaultMealTime();
             }
         }) );
        public RelayCommand DeleteSelectedProduct => _deleteSelectedProduct ?? ( _deleteSelectedProduct = new RelayCommand(obj =>
         {
             if(SelectedProduct != null && SelectedMealTime != null)
             {
                 _dataService.RemoveMealTimeProduct(SelectedMealTime, SelectedProduct);
                 UpdateComponent();
             }
         }) );
        public RelayCommand CreatePDF => _createPDF ?? ( _createPDF = new RelayCommand(obj =>
         {
             if(!PDFGenerator.CreatePDF(_user, _user.DailyRation))
             {
                 MessageBoxResult msg = MessageBox.Show("PDF файл успешно создан", "PDF создан успешно", MessageBoxButton.OK);
             }
             else
             {
                 MessageBoxResult msg = MessageBox.Show("При создании PDF возникла ошибка", "Ошибка", MessageBoxButton.OK);
             }
                
         }) );

        public void UpdateComponent()
        {
            OnPropertyChanged("MealTimes");
            OnPropertyChanged("Products");
            OnPropertyChanged("UserBMR");
            OnPropertyChanged("UserARM");
            OnPropertyChanged("UserCalories");
            OnPropertyChanged("TotalCalories");
        }
        private void SetDefaultMealTime()
        {
            if ( MealTimes != null && MealTimes.Count > 0 )
            {
                SelectedMealTime = MealTimes[0];
            }
        }
        private void AddMealTimeWindow_Closed(object sender, System.EventArgs e)
        {
            UpdateComponent();
        }

    }
}
