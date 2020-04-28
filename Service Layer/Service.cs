using System;
using System.Collections.Generic;
using System.Text;
using Data_Access_Layer.DAOInterfaces;
using Data_Access_Layer.DAOClasses;
using Business_Layer;

namespace Service_Layer
{
    class Service
    {
        public readonly ICategoryDAO categoryDAO = new CategoryDAO();
        public readonly IProductDAO productDAO = new ProductDAO();
        public readonly IDailyRationDAO dailyRationDAO = new DailyRationDAO();

        //product service
        public Product GetProductByName(string name) => productDAO.GetByName(name);
        public Product GetPRoductByName(string catecoryName, string name) => productDAO.GetByName(catecoryName, name);
        public bool AddProduct(string categoryName, Product product) => productDAO.Add(categoryName, product);
        public bool RemoveProduct(string categoryName, Product product) => productDAO.Remove(categoryName, product);
        public bool UpdateProdut(string categoryName, Product oldVersion, Product newVersion) => productDAO.Update(categoryName, oldVersion, newVersion);

        //deilyRation service
        public Dictionary<string, MealTime> GetMealsTimes() => dailyRationDAO.GetMealTimes();
        public List<Product> GetMealTimeProducts(string name) => dailyRationDAO.GetMealTimeProducts(name);
        public bool AddMealTime(MealTime mealTime) => dailyRationDAO.Add(mealTime);
        public bool RemoveMealTime(MealTime mealTime) => dailyRationDAO.Remove(mealTime);
        public bool UpdateMealTime(MealTime oldVersion, MealTime newVersion) => dailyRationDAO.Update(oldVersion, newVersion);
        public MealTime GetMealTimeByName(string name) => dailyRationDAO.GetMealTimeByName(name);

        //category service
        public Category GetCategoryByName(string name) => categoryDAO.GetByName(name);
        public bool AddCategory(Category category) => categoryDAO.Add(category);
        public bool RemoveCategory(Category category) => categoryDAO.Remove(category);
        public bool UpdateCategory(Category oldVersion, Category newVersion) => categoryDAO.Update(oldVersion, newVersion);

    }
}
