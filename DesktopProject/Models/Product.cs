using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopProject.Models
{
    public class Product
    {
        public string Category { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Classification { get; set; }

        public string SubClassification { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public Product(string category, string brand, string model, string classification, string subClassification, string description, int amount, int price)
        {
            Category = category;
            Brand = brand;
            Model = model;
            Classification = classification;
            SubClassification = subClassification;
            Description = description;
            Amount = amount;
            Price = price;
        }
    }
}
