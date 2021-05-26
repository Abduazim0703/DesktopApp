using System.Collections.Generic;
using DataLayer;
using ModelProduct;

namespace BusinessLayer
{
    public static class ProductServices
    {
        static IProductRepository repository;

        static ProductServices()
        {
            repository = new ProductRepository();
        }

        public static List<Products> GetAll()
        {
            return repository.GetAll();
        }

        public static Products GetById(int id)
        {
            return repository.GetById(id);
        }

        public static Products Insert(Products obj)
        {
            return repository.Insert(obj);
        }

        public static void Update(Products obj)
        {
            repository.Update(obj);
        }

        public static void Delete(Products obj)
        {
            repository.Delete(obj);
        }
    }
}
