using DailyMealPlanner.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMealPlanner.ViewModel.Components
{
    class CategoriesCMPVM
    {
        private RelayCommand _addCategory;
        private RelayCommand _editCategory;
        private RelayCommand _deleteCategory;

        public CategoriesTableCMPVM Categories { get; set; }

        public CategoriesCMPVM()
        {
            Categories = new CategoriesTableCMPVM();
        }

        public RelayCommand AddCategory
        {
            get => _addCategory ?? ( _addCategory = new RelayCommand((obj) =>
            {

            }));
        }

        public RelayCommand EditCategory
        {
            get => _editCategory ?? ( _addCategory = new RelayCommand((obj) =>
             {

             }) );
        }

        public RelayCommand DeleteCategory
        {
            get => _deleteCategory ?? ( _deleteCategory = new RelayCommand((obj) =>
            {

            }) );
        }
    }
}
