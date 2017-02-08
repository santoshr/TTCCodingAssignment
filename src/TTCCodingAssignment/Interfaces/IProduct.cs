using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTCCodingAssignment.Interfaces
{
    public interface IProduct
    {
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
