using Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer
{
    public interface IService
    {
        //products
        public List<Product> GetProducts();
        public Product GetProductByName(string name);
        public Product GetPRoductByName(string catecoryName, string name);
        public bool AddProduct(string categoryName, Product product);
        public bool RemoveProduct(string categoryName, Product product);
        public bool UpdateProdut(string categoryName, Product oldVersion, Product newVersion);

        //daily ration
        public void InsertMealTime(MealTime mealTime);
        public void RemoveMealTime(MealTime mealTime);
        public void RemoveMealTimeProduct(MealTime mealTimem, Product product);
        public void InsertMealTimeProduct(MealTime mealTime, Product product);
        public List<MealTime> GetMealTimes();

        //food category
        public Category GetCategoryByName(string name);
        public List<Category> GetCategories();
        public void RemoveCategory(Category category);
        public void UpsertCategory(Category oldVersion, Category newVersion);

        //user 
        public User GetUser();
    }
}
