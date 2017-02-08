using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTCCodingAssignment.Interfaces;

namespace TTCCodingAssignment.Concrete
{
    public class Product : IProduct
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        string name;
        decimal price;
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Name cannot be null or empty.");
                this.name = value;

            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                    throw new Exception("Price must be greater than zero.");
                this.price = value;
            }
        }
    }
}
