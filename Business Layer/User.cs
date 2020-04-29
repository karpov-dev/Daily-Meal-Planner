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
        private double _weight;
        private double _height;
        private int _age;

        public double Weight
        {
            get => _weight;
            set
            {
                if(value < 170 && value > 25 )
                {
                    _weight = value;
                }
            }
        }
        public double Height
        {
            get => _height;
            set
            {
                if(value < 250 && value > 70 )
                {
                    _height = value;
                }
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if(value < 100 && value > 10 )
                {
                    _age = value;
                }
            }
        }
        public Activity Activity { get; set; }
        public DailyRation DailyRation { get; set; }

        public User(int age = 20, double weight = 65, double height = 170, Activity activity = Activity.Normal )
        {
            this.Age = age;
            this.Weight = weight;
            this.Height = height;
            this.Activity = activity;
            DailyRation = new DailyRation();
        }

        public double GetBMR() => Math.Round( 447.593 + 9.247 * Weight + 3.098 * Height - 4.330 * Age, 2 );
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
        public double GetCalories() => Math.Round( GetBMR() * GetARM(), 2);
    }
}
