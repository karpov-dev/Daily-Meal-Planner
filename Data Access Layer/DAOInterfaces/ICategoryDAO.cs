using Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.DAOInterfaces
{
    public interface ICategoryDAO
    {

        public Category GetByName(string name);
        public bool Add(Category category);
        public bool Remove(Category category);
        public bool Update(Category oldVersion, Category newVersion);

    }
}
