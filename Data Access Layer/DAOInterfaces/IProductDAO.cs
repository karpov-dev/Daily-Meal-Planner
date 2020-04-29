using Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.DAOInterfaces
{
    public interface IProductDAO
    {

        public List<Product> GetProducts();
        public Product GetByName(string name);
        public Product GetByName(string categoryName, string name);
        public bool Add(string categoryName, Product product);
        public bool Remove(string categoryName, Product product);
        public bool Update(string categoryName, Product oldVersion, Product newVersion);

    }
}
