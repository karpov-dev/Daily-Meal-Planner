using System;
using System.Collections.Generic;
using System.Text;
using Data_Access_Layer.DAOInterfaces;
using Data_Access_Layer.DAOClasses;
using Business_Layer;

namespace Service_Layer
{
    public class DataService : IService
    {
        public static DataService instance;
        public readonly ICategoryDAO categoryDAO = new CategoryDAO();
        public readonly IProductDAO productDAO = new ProductDAO();
        public readonly IDailyRationDAO dailyRationDAO = new DailyRationDAO();
        public readonly IUserDAO userDAO = new UserDAO();

        public static DataService GetInstance()
        {
            if ( instance != null )
                return instance;
            else
                return new DataService();
        }

        //product service
        public List<Product> GetProducts() => productDAO.GetProducts();
        public Product GetProductByName(string name) => productDAO.GetByName(name);
        public Product GetPRoductByName(string catecoryName, string name) => productDAO.GetByName(catecoryName, name);
        public bool AddProduct(string categoryName, Product product) => productDAO.Add(categoryName, product);
        public bool RemoveProduct(string categoryName, Product product) => productDAO.Remove(categoryName, product);
        public bool UpdateProdut(string categoryName, Product oldVersion, Product newVersion) => productDAO.Update(categoryName, oldVersion, newVersion);

        //deilyRation service
        public void InsertMealTime(MealTime mealTime) => dailyRationDAO.InsertMealTime(mealTime);
        public void RemoveMealTime(MealTime mealTime) => dailyRationDAO.RemoveMealTime(mealTime);
        public void RemoveMealTimeProduct(MealTime mealTimem, Product product) => dailyRationDAO.RemoveProduct(mealTimem, product);
        public void InsertMealTimeProduct(MealTime mealTime, Product product) => dailyRationDAO.InsertProduct(mealTime, product);
        public List<MealTime> GetMealTimes() => dailyRationDAO.Get();

        //category service
        public Category GetCategoryByName(string name) => categoryDAO.GetByName(name);
        public List<Category> GetCategories() => categoryDAO.GetCategories();
        public void UpsertCategory(Category oldVersion, Category newVersion) => categoryDAO.Upsert(oldVersion, newVersion);
        public void RemoveCategory(Category category) => categoryDAO.Remove(category);

        //user service
        public User GetUser() => userDAO.GetUser();

    }
}
