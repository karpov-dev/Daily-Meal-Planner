using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    class DailyRation
    {
        public Dictionary<string, MealTime> MealTimes { get; set; }

        public DailyRation()
        {
            MealTimes = new Dictionary<string, MealTime>();
            MealTimes["Завтрак"] = new MealTime("Завтрак");
            MealTimes["Обед"] = new MealTime("Обед");
            MealTimes["Ужин"] = new MealTime("Ужин");

        }

        public double GetCalories()
        {
            double calories = 0;
            foreach(string name in MealTimes.Keys){
                calories += MealTimes[name].GetCalories();
            }
            return calories;
        }
    }
}
