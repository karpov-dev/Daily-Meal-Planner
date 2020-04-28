using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    public class Category : ICloneable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
        public Category(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            Products = new List<Product>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
