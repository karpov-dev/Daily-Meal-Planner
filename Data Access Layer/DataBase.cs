using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Business_Layer;

namespace Data_Access_Layer
{
    public class DataBase
    {
        public static string DataPath { get; set; }
        private static DataBase instance;

        public List<Category> Categories { get; set; }
        public User User { get; set; }

        public DataBase(string dataPath)
        {
            if ( DataBase.DataPath == null )
            {
                DataPath = "products.xml";
            }
            DataBase.DataPath = dataPath;
            Categories = new List<Category>();
            User = new User();
            ReadData(dataPath);
        }

        public static DataBase GetInstance()
        {
            if(instance == null )
            {
                return new DataBase(DataPath);
            }
            else
            {
                return instance;
            }
        }


        public Category GetCategoryByName(string name)
        {
            for(int i = 0; i < Categories.Count; i++ )
            {
                if(Categories[i].Name == name )
                {
                    return Categories[i];
                }
            }
            return null;
        }


        private void ReadData(string filePath)
        {
            XDocument xdoc = XDocument.Load(filePath);

            foreach ( XElement category in xdoc.Element("Db").Elements("Category") )
            {
                Category xmlCategory = new Category()
                {
                    Name = category.Attribute("name").Value,
                    Description = category.Attribute("description").Value,
                };
                List<Product> xmlProducts = new List<Product>();
                foreach(XElement product in category.Elements("Product") )
                {
                    Product xmlProsuct = new Product();
                    xmlProsuct.Name = product.Element("Name").Value;
                    xmlProsuct.Gramms = Convert.ToDouble(product.Element("Gramms").Value);
                    xmlProsuct.Protein = Convert.ToDouble(product.Element("Protein").Value);
                    xmlProsuct.Fats = Convert.ToDouble(product.Element("Fats").Value);
                    xmlProsuct.Carbs = Convert.ToDouble(product.Element("Carbs").Value);
                    xmlProsuct.Calories100 = Convert.ToDouble(product.Element("Calories").Value);
                    xmlCategory.Products.Add(xmlProsuct);
                }
                Categories.Add(xmlCategory);
            }
        }
    }
}
