using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Aplication.DTO
{
    public class ProductInsertDTO
    {
        public string? ProductName { get; set; }
        public string? Brand { get; set; }
        public decimal Price { get; set; }
    }
}
