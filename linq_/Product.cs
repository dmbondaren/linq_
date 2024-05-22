using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_
{
    internal class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Category} - ${Price} - Qty: {Quantity}";
        }
    }
}
