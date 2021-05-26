using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProduct;

namespace DataLayer
{
    public interface IProductRepository
    {
        List<Products> GetAll();
        Products GetById(int id);
        Products Insert(Products obj);
        void Update(Products obj);
        void Delete(Products obj);

    }
}
