using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Customer(
    int Tz,
    string? Name,
    string? Adress,
    string? Phone
    )
    {
        public Customer() : this(0, "", "", "")
        {

        }
    }
}
