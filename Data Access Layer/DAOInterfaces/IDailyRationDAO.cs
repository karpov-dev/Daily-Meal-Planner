using Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.DAOInterfaces
{
    public interface IDailyRationDAO
    {

        public void InsertMealTime(MealTime mealTime);
        public void RemoveMealTime(MealTime mealTime);
        public List<MealTime> Get();
        public void RemoveProduct(MealTime mealTime, Product product);
        public void InsertProduct(MealTime mealTime, Product product);

    }
}
