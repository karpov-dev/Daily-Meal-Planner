using System;
using System.Collections.Generic;
using System.Text;
using Business_Layer;
using Data_Access_Layer.DAOInterfaces;

namespace Data_Access_Layer.DAOClasses
{
    public class DailyRationDAO : IDailyRationDAO
    {
        private DataBase _dataBase = DataBase.GetInstance();

        public List<MealTime> Get()
        {
            return _dataBase.User.DailyRation.MealTimes;
        }

        public void InsertMealTime(MealTime mealTime)
        {
            if ( mealTime == null ) return;

            _dataBase.User.DailyRation.MealTimes.Add(mealTime);
        }

        public void InsertProduct(MealTime mealTime, Product product)
        {
            if ( mealTime == null && product == null ) return;

            mealTime.Products.Add(product);
        }

        public void RemoveMealTime(MealTime mealTime)
        {
            if ( mealTime == null ) return;

            _dataBase.User.DailyRation.MealTimes.Remove(mealTime);
        }

        public void RemoveProduct(MealTime mealTime, Product product)
        {
            if ( mealTime == null && product == null ) return;

            mealTime.Products.Remove(product);
        } 
    }
}
