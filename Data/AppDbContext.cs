using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Advert> Advert { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Admin> Admin { get; set; }


    }
}
