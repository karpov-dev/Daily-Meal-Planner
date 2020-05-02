using Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.DAOInterfaces
{
    public interface ICategoryDAO
    {

        public Category GetByName(string name);
        public List<Product> GetProductsByName(string name);
        public List<Category> GetCategories();
        public void Remove(Category category);
        public void Upsert(Category oldVersion, Category newVersion);

    }
}
