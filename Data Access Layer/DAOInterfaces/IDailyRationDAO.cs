using Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.DAOInterfaces
{
    public interface IDailyRationDAO
    {

        public Dictionary<string, MealTime> GetMealTimes();
        public List<Product> GetMealTimeProducts(string name);
        public bool Add(MealTime mealTime);
        public bool Remove(MealTime mealTime);
        public bool Update(MealTime oldVersion, MealTime newVersion);
        public MealTime GetMealTimeByName(string name);
    }
}
