using Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer
{
    public interface IService
    {
        public List<Product> GetProducts();
        public Product GetProductByName(string name);
        public Product GetPRoductByName(string catecoryName, string name);
        public bool AddProduct(string categoryName, Product product);
        public bool RemoveProduct(string categoryName, Product product);
        public bool UpdateProdut(string categoryName, Product oldVersion, Product newVersion);

        public Dictionary<string, MealTime> GetMealsTimes();
        public List<Product> GetMealTimeProducts(string name);
        public bool AddMealTime(MealTime mealTime);
        public bool RemoveMealTime(MealTime mealTime);
        public bool UpdateMealTime(MealTime oldVersion, MealTime newVersion);
        public MealTime GetMealTimeByName(string name);

        public Category GetCategoryByName(string name);
        public List<Category> GetCategories();
        public List<Category> RemoveCategory(Category category);
        public bool UpsertCategory(Category oldVersion, Category newVersion);

        public User GetUser();
    }
}
