﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
  public  class CarDetailsDto : IDto
    {
        public string BrandName { get ; set; }
        public string CarDescription { get; set; }
        public string ColorName { get; set; }
        public decimal CarDailyPrice { get; set; }
    }
}
