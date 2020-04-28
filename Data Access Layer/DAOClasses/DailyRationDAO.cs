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

        public bool Add(MealTime mealTime)
        {
            if(mealTime != null )
            {
                _dataBase.User.DailyRation.MealTimes.Add(mealTime.Name, mealTime);
                return true;
            }
            return false;
        }

        public MealTime GetMealTimeByName(string name)
        {
            if( !string.IsNullOrWhiteSpace(name) )
            {
                if ( _dataBase.User.DailyRation.MealTimes.ContainsKey(name) )
                {
                    return _dataBase.User.DailyRation.MealTimes[name];
                }
            }
            return null;
        }

        public List<Product> GetMealTimeProducts(string name)
        {
            if( !string.IsNullOrEmpty(name) )
            {
                if ( _dataBase.User.DailyRation.MealTimes.ContainsKey(name) )
                {
                    return _dataBase.User.DailyRation.MealTimes[name].Products;
                }
            }
            return null;
        }

        public Dictionary<string, MealTime> GetMealTimes()
        {
            return _dataBase.User.DailyRation.MealTimes;
        }

        public bool Remove(MealTime mealTime)
        {
            if(mealTime != null )
            {
                if ( _dataBase.User.DailyRation.MealTimes.ContainsKey(mealTime.Name) )
                {
                    _dataBase.User.DailyRation.MealTimes.Remove(mealTime.Name);
                    return true;
                }
            }
            return false;
        }

        public bool Update(MealTime oldVersion, MealTime newVersion)
        {
            if(oldVersion != null && newVersion != null )
            {
                if ( _dataBase.User.DailyRation.MealTimes.ContainsKey(oldVersion.Name) )
                {
                    _dataBase.User.DailyRation.MealTimes.Remove(oldVersion.Name);
                    this.Add(newVersion);
                    return true;
                }
            }
            return false;
        }
    }
}
