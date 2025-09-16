using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Product(
     int ProductId,
     string ProductName,
     Categories Category,
     double Price,
     int Quanity
     )
    {
        public Product() : this(1, "", Categories.childrenBooks, 0, 0)
        {

        }
    }
}
