

namespace Core.Entities
{
  public  interface IDto
    {
       
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }

    }
}
