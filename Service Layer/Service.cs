using System;
using System.Collections.Generic;
using System.Text;
using Data_Access_Layer.DAOInterfaces;
using Data_Access_Layer.DAOClasses;

namespace Service_Layer
{
    class Service
    {
        public readonly ICategoryDAO categoryDAO = new CategoryDAO();
        public readonly IProductDAO productDAO = new ProductDAO();
        public readonly IDailyRationDAO dailyRationDAO = new DailyRationDAO();
    }
}
