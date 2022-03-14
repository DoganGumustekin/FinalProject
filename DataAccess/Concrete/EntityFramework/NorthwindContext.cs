using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework  //Context=Veritabanı tabloları ile kendi class larımızı ilişkilendirdiğimiz classtır.
{
    public class NorthwindContext:DbContext//entity framework ile böyle bir base sınıf geliyor.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//benim projemin hangi db ile ilişkili olduğunu belirteceğim yer.
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true"); //@=normalde dillerde \ ile ayrım yaparız c# ta bu \\ dir. @ onu tek \ a indirger. 
        }                                                                  //parantez içinde sql serverim nerede yi yazıyorum.
        public DbSet<Product> Products { get; set; } //veritabanını bağladım ama benim hangi nesnem hangi nesneye karşılık geliyor? DbSet yapar bunu
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
