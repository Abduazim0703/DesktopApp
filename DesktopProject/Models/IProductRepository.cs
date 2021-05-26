using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopProject.Models
{
    public interface IProductRepository
    {
        void GetProduct(int id);

        IEnumerable<Product> GetAll();

        void Create(Product product);
        
        void Update(Product product);
        
        void Delete(int id);

    }
}
