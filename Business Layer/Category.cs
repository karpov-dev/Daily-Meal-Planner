using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    class Category : ICloneable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Category() { }
        public Category(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
