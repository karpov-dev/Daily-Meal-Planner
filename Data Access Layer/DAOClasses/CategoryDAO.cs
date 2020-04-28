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

        public bool Add(Category category)
        {
            if(category != null )
            {
                _dataBase.Categories.Add(category);
                return true;
            }
            return false;
        }

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

        public bool Remove(Category category)
        {
            if(category != null )
            {
                _dataBase.Categories.Remove(category);
                return true;
            }
            return true;
        }

        public bool Update(Category oldVersion, Category newVersion)
        {
            if( oldVersion != null && newVersion != null )
            {
                Category category = GetByName(oldVersion.Name);
                if(category != null )
                {
                    Remove(oldVersion);
                    Add(newVersion);
                    return true;
                }
            }
            return false;
        }
    }
}
