using System;
using System.Collections.Generic;
using System.Text;
using PresentationLayer.ViewModel.Components;

namespace PresentationLayer.ViewModel.Windows
{
    class MainWindowVm
    {
        public UserInfoCmpVm UserInfoCmpVm { get; set; }
        public CategoriesTableCmpVm CategoriesTableCmpVm { get; set; }

        public MainWindowVm()
        {
            UserInfoCmpVm = new UserInfoCmpVm();
            CategoriesTableCmpVm = new CategoriesTableCmpVm();
        }
    }
}
