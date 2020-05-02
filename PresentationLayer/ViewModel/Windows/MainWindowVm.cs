using System;
using System.Collections.Generic;
using System.Text;
using PresentationLayer.Service;
using PresentationLayer.ViewModel.Components;
using PresentationLayer.Model;
using Business_Layer;
using Data_Access_Layer;

namespace PresentationLayer.ViewModel.Windows
{
    class MainWindowVm : ModelPropertyChanged
    {
        private RelayCommand _addProduct;
        public CategoriesTableCmpVm CategoriesTableCmpVm { get; set; }
        public MealPlannerCmpVm MealPlannerCmpVm { get; set; }

        public MainWindowVm()
        {
            CategoriesTableCmpVm = new CategoriesTableCmpVm();
            MealPlannerCmpVm = new MealPlannerCmpVm();
            System.Windows.Application.Current.Exit += Window_Exit;
        }

        private void Window_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            DataBase dataBase = DataBase.GetInstance();
            dataBase.WriteCategoriesData();
            dataBase.WriteUserData();
        }

        public RelayCommand AddProduct => _addProduct ?? ( _addProduct = new RelayCommand(obj =>
         {
             if(InteractionCmp.SelectedProduct != null )
             {
                 InteractionCmp.ActiveMealTime.Products.Add((Product) InteractionCmp.SelectedProduct.Clone());
                 MealPlannerCmpVm.UpdateComponent();
             }
         }) );
    }
}
