using ModelProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductRepository : IProductRepository
    {
        public void Delete(Products obj)
        {
            using (DesktopDbEntities db = new DesktopDbEntities())
            {
                db.Products.Attach(obj);
                db.Products.Remove(obj);
                db.SaveChanges();
            }
        }

        public Products GetById(int id)
        {
            using (DesktopDbEntities db = new DesktopDbEntities())
            {
                return db.Products.Find(id);
            }
        }

        public List<Products> GetAll()
        {
            using (DesktopDbEntities db = new DesktopDbEntities())
            {
                return db.Products.ToList();
            }
        }

        public Products Insert(Products obj)
        {
            using (DesktopDbEntities db = new DesktopDbEntities())
            {
                db.Products.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public void Update(Products obj)
        {
            using (DesktopDbEntities db = new DesktopDbEntities())
            {
                db.Products.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
