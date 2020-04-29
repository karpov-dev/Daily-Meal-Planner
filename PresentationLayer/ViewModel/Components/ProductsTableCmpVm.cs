using Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.ViewModel.Components
{
    class ProductsTableCmpVm
    {
        public List<Product> Products { get; set; }

        public ProductsTableCmpVm(List<Product> products)
        {
            Products = products;
        }

        public ProductsTableCmpVm() { }
    }
}
