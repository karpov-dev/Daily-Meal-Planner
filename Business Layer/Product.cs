using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    class Product : ICloneable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Gramms { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public double Calories100 { get; set; }
        public Category Category { get; set; }

        public Product() { }
        public Product(Product product)
        {
            this.Name = product.Name;
            this.Description = product.Description;
            this.Gramms = product.Gramms;
            this.Fats = product.Fats;
            this.Carbs = product.Carbs;
            this.Category = product.Category;
            this.Calories100 = product.Calories100;
        }

        public double GetCalories() => ( Gramms * Calories100 ) / 100;
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
