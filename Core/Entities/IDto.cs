

namespace Core.Entities
{
  public  interface IDto
    {
       
        public decimal CarDailyPrice { get; set; }
        public string CarDescription { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }

    }
}
