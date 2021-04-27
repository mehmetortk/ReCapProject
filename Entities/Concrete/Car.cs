using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Car : IEntity
    {
        public int CarId { get; set; }
        public decimal CarDailyPrice { get; set; }
        public string CarDescription { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string CarModelYear { get; set; }
    }
}
