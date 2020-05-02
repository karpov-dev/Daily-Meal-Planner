using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Business_Layer;

namespace Data_Access_Layer
{
    public class DataBase
    {
        private const string DEFAULT_USER_DATA_PATH = "user.xml";
        private const string DEFAULT_CATEGORY_DATA_PATH = "products.xml";

        public static string UserDataPath { get; set; }
        public static string CategoryDataPath { get; set; }

        private static DataBase instance;

        public List<Category> Categories { get; set; }
        public User User { get; set; }

        public DataBase()
        {
            if ( UserDataPath == null ) UserDataPath = DEFAULT_USER_DATA_PATH;
            if ( CategoryDataPath == null ) CategoryDataPath = DEFAULT_CATEGORY_DATA_PATH;

            Categories = new List<Category>();
            User = new User();

            if(File.Exists(CategoryDataPath)) ReadCategoriesData(CategoryDataPath);
            if ( File.Exists(UserDataPath) ) ReadUserData(UserDataPath);
        }

        public static DataBase GetInstance()
        {
            if(instance == null )
            {
                instance = new DataBase();
                return instance;
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

        #region Read Data

        public void ReadCategoriesData(string filePath)
        {
            XDocument xdoc = XDocument.Load(filePath);

            foreach ( XElement category in xdoc.Element("Db").Elements("Category") )
            {
                Category xmlCategory = new Category()
                {
                    Name = category.Attribute("name").Value
                };
                List<Product> xmlProducts = new List<Product>();
                foreach(XElement product in category.Elements("Product") )
                {
                    xmlCategory.Products.Add(GetProductByXElement(product));
                }
                Categories.Add(xmlCategory);
            }
        }

        public void ReadUserData(string filePath)
        {
            XDocument xdoc = XDocument.Load(filePath);

            XElement xmlUser = xdoc.Element("DataBase").Element("User");
            User.Age = Convert.ToInt32(xmlUser.Element("Age").Value);
            User.Weight = Convert.ToDouble(xmlUser.Element("Weight").Value);
            User.Height = Convert.ToDouble(xmlUser.Element("Height").Value);
            User.DailyRation.MealTimes.Clear();
            //User.Activity = (Activity)Convert.ToInt32(xmlUser.Element("Activity").Value);
            foreach ( XElement xmlMealTime in xmlUser.Element("DailyRation").Elements("MealTime") )
            {
                MealTime mealTime = new MealTime(xmlMealTime.Attribute("Name").Value);
                foreach ( XElement xmlProduct in xmlMealTime.Elements("Product") )
                {
                    mealTime.Products.Add(GetProductByXElement(xmlProduct));
                }
                User.DailyRation.MealTimes.Add(mealTime);
            }
        }

        #endregion

        #region Write Data

        public void WriteCategoriesData()
        {
            XDocument xdoc = new XDocument();

            XElement db = new XElement("Db");
            foreach(Category category in Categories )
            {
                XElement xmlCategory = new XElement("Category");
                xmlCategory.Add(new XAttribute("name", category.Name));
                foreach(Product product in category.Products )
                {
                    xmlCategory.Add(GetXElementByProduct(product));
                }
                db.Add(xmlCategory);
            }
            xdoc.Add(db);
            xdoc.Save("products.xml");

        }

        public void WriteUserData()
        {
            XDocument xdoc = new XDocument();

            XElement xmlDataBase = new XElement("DataBase");
            XElement xmlUser = new XElement("User");
            xmlUser.Add(new XElement("Age", Convert.ToString(User.Age)));
            xmlUser.Add(new XElement("Weight", Convert.ToString(User.Weight)));
            xmlUser.Add(new XElement("Height", Convert.ToString(User.Height)));
            xmlUser.Add(new XElement("Activity", Convert.ToString(User.Activity)));
            XElement xmlDailyRation = new XElement("DailyRation");
            foreach ( MealTime mealTime in User.DailyRation.MealTimes )
            {
                XElement xmlMealTime = new XElement("MealTime");
                xmlMealTime.Add(new XAttribute("Name", mealTime.Name));
                foreach ( Product product in mealTime.Products )
                {
                    xmlMealTime.Add(GetXElementByProduct(product));
                }
                xmlDailyRation.Add(xmlMealTime);
            }
            xmlUser.Add(xmlDailyRation);
            xmlDataBase.Add(xmlUser);
            xdoc.Add(xmlDataBase);
            xdoc.Save("user.xml");
        }

        #endregion

        private XElement GetXElementByProduct(Product product)
        {
            if ( product == null ) return null;

            XElement xmlProduct = new XElement("Product");
            xmlProduct.Add(new XElement("Name", Convert.ToString(product.Name)));
            xmlProduct.Add(new XElement("Gramms", Convert.ToString(product.Gramms)));
            xmlProduct.Add(new XElement("Protein", Convert.ToString(product.Protein)));
            xmlProduct.Add(new XElement("Fats", Convert.ToString(product.Fats)));
            xmlProduct.Add(new XElement("Carbs", Convert.ToString(product.Carbs)));
            xmlProduct.Add(new XElement("Calories", Convert.ToString(product.Calories100)));
            return xmlProduct;
        }

        private Product GetProductByXElement(XElement element)
        {
            if ( element == null ) return null;

            Product product = new Product();
            product.Name = element.Element("Name").Value;
            product.Gramms = Convert.ToDouble(element.Element("Gramms").Value);
            product.Protein = Convert.ToDouble(element.Element("Protein").Value);
            product.Fats = Convert.ToDouble(element.Element("Fats").Value);
            product.Carbs = Convert.ToDouble(element.Element("Carbs").Value);
            product.Calories100 = Convert.ToDouble(element.Element("Calories").Value);
            return product;
        }
    }
}
