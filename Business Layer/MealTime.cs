using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    public class MealTime
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public MealTime(string name)
        {
            this.Name = name;
            this.Products = new List<Product>();
        }

        public MealTime(string name, List<Product> products)
        {
            this.Name = name;
            this.Products = Products;
        }

        public double GetCalories()
        {
            double calories = 0;
            for(int i = 0; i < Products.Count; i++ )
            {
                calories += Products[i].GetCalories();
            }
            return calories;
        }
    }
}
