using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    public class DailyRation
    {
        public List<MealTime> MealTimes { get; set; }

        public DailyRation()
        {
            MealTimes = new List<MealTime>();
            MealTimes.Add( new MealTime("Завтрак") );
            MealTimes.Add( new MealTime("Обед") );
            MealTimes.Add( new MealTime("Ужин") );

        }

        public double GetCalories()
        {
            double calories = 0;
            foreach(MealTime mealTime in MealTimes){
                calories += mealTime.GetCalories();
            }
            return calories;
        }
    }
}
