using System;
using System.Collections.Generic;
using System.Text;
using Business_Layer;
using Data_Access_Layer.DAOInterfaces;

namespace Data_Access_Layer.DAOClasses
{
    public class ProductDAO : IProductDAO
    {
        private DataBase _dataBase = DataBase.GetInstance();

        public bool Add(string categoryName, Product product)
        {
            if(!string.IsNullOrWhiteSpace(categoryName) && product != null )
            {
                Category category = _dataBase.GetCategoryByName(categoryName);
                if(category != null )
                {
                    category.Products.Add(product);
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string categoryName, Product product)
        {
            if( !string.IsNullOrWhiteSpace(categoryName) && product != null )
            {
                Category category = _dataBase.GetCategoryByName(categoryName);
                if(category != null )
                {
                    category.Products.Remove(product);
                    return true;
                }
            }
            return false;
        }

        public bool Update(string categoryName, Product oldVersion,  Product newVersion)
        {
            if( !string.IsNullOrWhiteSpace(categoryName) && oldVersion != null && newVersion != null )
            {
                Product product = GetByName(oldVersion.Name);
                if(product != null )
                {
                    Remove(categoryName, oldVersion);
                    Add(categoryName, newVersion);
                    return true;
                }
            }
            return false;
        }

        public Product GetByName(string name)
        {
            if ( !string.IsNullOrWhiteSpace(name) )
            {
                List<Category> categories = _dataBase.Categories;
                if ( categories != null )
                {
                    for ( int i = 0; i < categories.Count; i++ )
                    {
                        foreach ( Product product in categories[i].Products )
                        {
                            if ( product.Name == name )
                            {
                                return product;
                            }
                        }
                    }
                }
            }
            return null;
        }

        public Product GetByName(string categoryName, string name)
        {
            if ( !string.IsNullOrWhiteSpace(categoryName) && !string.IsNullOrWhiteSpace(name) )
            {
                Category category = _dataBase.GetCategoryByName(categoryName);
                if ( category != null )
                {
                    foreach ( Product product in category.Products )
                    {
                        if ( product.Name == name )
                        {
                            return product;
                        }
                    }
                }
            }
            return null;
        }

        public List<Product> GetProducts()
        {
            List<Category> categories = _dataBase.Categories;
            List<Product> productList = new List<Product>();
            for(int i = 0; i < categories.Count; i++ )
            {
                productList.AddRange(categories[i].Products);
            }
            return productList;
        }
    }
}
