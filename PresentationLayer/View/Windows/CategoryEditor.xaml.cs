using Business_Layer;
using PresentationLayer.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для CategoryEditor.xaml
    /// </summary>
    public partial class CategoryEditor : Window
    {
        public CategoryEditor(Category category)
        {
            InitializeComponent();
            DataContext = new CategoryEditorVm(category);
        }
    }
}
