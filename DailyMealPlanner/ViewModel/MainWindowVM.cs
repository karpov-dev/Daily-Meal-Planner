using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyMealPlanner.ViewModel.Components;
using 

namespace DailyMealPlanner.ViewModel
{
    class MainWindowVM
    {
        public CategoriesCMPVM CategoriesVM { get; set; }
        public UserInfoCMPVM UserInfoVM { get; set; }
        public MealTimeEditorVM MealTimeEditor { get; set; }
    }
}
