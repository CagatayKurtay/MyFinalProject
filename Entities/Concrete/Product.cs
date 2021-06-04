
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete  //1
{
    public class Product : IEntity           //public yaptığın zaman bu classa diğer katmanlarda ulaşır--internal yaparsan sadece entities ulaşır
    {
        public int ProductId { get; set; }
        
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnıtsInStock { get; set; }
        public decimal UnitPrice { get; set; }


    }
}
