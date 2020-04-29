using System;
using System.Collections.Generic;
using System.Text;
using Business_Layer;
using Data_Access_Layer.DAOInterfaces;

namespace Data_Access_Layer.DAOClasses
{
    public class CategoryDAO : ICategoryDAO
    {
        private DataBase _dataBase = DataBase.GetInstance();

        public Category GetByName(string name)
        {
            if( !string.IsNullOrWhiteSpace(name) )
            {
                List<Category> categories = _dataBase.Categories;
                foreach(Category category in categories )
                {
                    if(category.Name == name )
                    {
                        return category;
                    }
                }
            }
            return null;
        }

        public List<Category> GetCategories()
        {
            return _dataBase.Categories;
        }

        public List<Product> GetProductsByName(string name)
        {
            if( !string.IsNullOrWhiteSpace(name) )
            {
                List<Category> categories = _dataBase.Categories;
                for(int i = 0; i < categories.Count; i++ )
                {
                    if(categories[i].Name == name )
                    {
                        return categories[i].Products;
                    }
                }
            }
            return null;
        }

        public List<Category> Remove(Category category)
        {
            if(category != null )
            {
                _dataBase.Categories.Remove(category);
            }
            return _dataBase.Categories;
        }

        public bool Upsert(Category oldVersion, Category newVersion)
        {
            if ( newVersion == null ) return false;

            Category category = null;
            if (oldVersion != null )
            {
                category = GetByName(oldVersion.Name);
            }
            
            if(category == null )
            {
                _dataBase.Categories.Add(newVersion);
            }
            else
            {
                category.Products = newVersion.Products;
                category = newVersion;
            }
            return true;
        }
    }
}
