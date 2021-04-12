using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=CarRentAl; 
Trusted_Connection=true");
        }


        public  DbSet<Car> TblCar { get; set; }
        public  DbSet<Brand> TblBrand { get; set; }
        public  DbSet<Color> TblColor { get; set; }
    }
}
