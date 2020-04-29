using Business_Layer;
using PresentationLayer.Service;
using Service_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PresentationLayer.ViewModel.Windows
{
    class CategoryEditorVm
    {
        private Category _oldVersion;
        private DataService _dataService = DataService.GetInstance();
        private RelayCommand _deleteProduct;
        private RelayCommand _saveCommand;
        
        public Category Category { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }

        public CategoryEditorVm(Category category)
        {
            if ( category != null )
            {
                Category = (Category) category.Clone();
                _oldVersion = (Category) category.Clone();
            }
            else
            {
                Category = new Category();
                _oldVersion = null;
            }    
            Products = new ObservableCollection<Product>(Category.Products);
        }

        public RelayCommand DeleteProduct => _deleteProduct ?? ( _deleteProduct = new RelayCommand(obj =>
         {
             if(SelectedProduct != null )
             {
                 Products.Remove(SelectedProduct);
             }
         }) );
        public RelayCommand SaveCommand => _saveCommand ?? ( _saveCommand = new RelayCommand(obj =>
         {
             Category.Products = new List<Product>(Products);
             _dataService.UpsertCategory(_oldVersion, Category);
         }) );

    }
}
