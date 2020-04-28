using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    public enum Activity
    {
        Low,
        Normal,
        Average,
        High
    }

    public class User
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public Activity Activity { get; set; }
        public DailyRation DailyRation { get; set; }

        public User(int age = 20, double weight = 65, double height = 170, Activity activity = Activity.Normal )
        {
            this.Age = age;
            this.Weight = Weight;
            this.Height = Height;
            this.Activity = activity;
            DailyRation = new DailyRation();
        }

        public double GetBMR() => 447.593 + 9.247 * Weight + 3.098 * Height - 4.330 * Age;
        public double GetCalories() => GetBMR() * GetARM();
        public double GetARM()
        {
            switch ( Activity )
            {
                case Activity.Low:
                    return 1.2;
                case Activity.Normal:
                    return 1.375;
                case Activity.Average:
                    return 1.55;
                case Activity.High:
                    return 1.725;
                default:
                    return 1.375;
            }
        }
    }
}
