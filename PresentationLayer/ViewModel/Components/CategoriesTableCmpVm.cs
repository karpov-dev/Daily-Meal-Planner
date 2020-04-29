using Business_Layer;
using Service_Layer;
using PresentationLayer.Service;
using PresentationLayer.ViewModel.Windows;
using PresentationLayer.View.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PresentationLayer.ViewModel.Components
{
    class CategoriesTableCmpVm : ModelPropertyChanged
    {
        private Category _selectedCategory;
        private DataService _dataService = DataService.GetInstance();

        private RelayCommand _addCategory;
        private RelayCommand _editCategory;
        private RelayCommand _deleteCategory;

        public ObservableCollection<Category> Categories => new ObservableCollection<Category>(_dataService.GetCategories());
        public List<Product> Products
        {
            get
            {
                if(SelectedCategory != null )
                {
                    return SelectedCategory.Products;
                }
                return null;
            }
        }

        public CategoriesTableCmpVm()
        {
            SelectedCategory = GetDefaultCategory();
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                OnPropertyChanged("Products");
            }
        }

        public RelayCommand AddCategory => _addCategory ?? ( _addCategory = new RelayCommand(obj =>
         {
             CategoryEditor categoryEditor = new CategoryEditor(null);
             categoryEditor.Closed += CategoryEditor_Closed;
             categoryEditor.Show();
         }) );
        public RelayCommand EditCategory => _editCategory ?? ( _editCategory = new RelayCommand(obj =>
         {
             CategoryEditor categoryEditor = new CategoryEditor(SelectedCategory);
             categoryEditor.Closed += CategoryEditor_Closed;
             categoryEditor.Show();
         }) );
        public RelayCommand DeleteCategory => _deleteCategory ?? ( _deleteCategory = new RelayCommand(obj =>
         {
             _dataService.RemoveCategory(SelectedCategory);
             SelectedCategory = GetDefaultCategory();
             OnPropertyChanged("Categories");
         }) );

        
        private Category GetDefaultCategory()
        {
            if(Categories != null && Categories.Count > 0 )
            {
                return Categories[0];
            }
            return null;
        }
        private void CategoryEditor_Closed(object sender, System.EventArgs e)
        {
            OnPropertyChanged("Categories");
            OnPropertyChanged("Products");
        }
    }
}
