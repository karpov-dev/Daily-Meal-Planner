using Business_Layer;
using PresentationLayer.Service;
using Service_Layer;

namespace PresentationLayer.ViewModel.Windows
{
    class AddMealTimeVm : ModelPropertyChanged
    {
        private DataService _dataService = DataService.GetInstance();
        private RelayCommand _addMealTime;
        private string _mealTimeName;

        public string MealTimeName
        {
            get => _mealTimeName;
            set
            {
                _mealTimeName = value;
                OnPropertyChanged("SaveIsEnabled");
            }
        }
        public bool SaveIsEnabled
        {
            get
            {
                if ( !string.IsNullOrWhiteSpace(MealTimeName) ) return true;
                return false;
            }
        }

        public RelayCommand AddMealTime => _addMealTime ?? ( _addMealTime = new RelayCommand(obj =>
         {
             if ( !string.IsNullOrWhiteSpace(MealTimeName) )
             {
                 MealTime mealTime = new MealTime(MealTimeName);
                 _dataService.InsertMealTime(mealTime);
                 
             }
         }) );
    }
}
