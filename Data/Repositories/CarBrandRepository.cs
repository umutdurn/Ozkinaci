using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CarBrandRepository : Repository<CarBrand>, ICarBrandRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CarBrandRepository(AppDbContext context) : base(context)
        {

        }

        public ICollection<CarBrand> GetAllInclude()
        {
            return _appDbContext.CarBrands.Include(x => x.CarModel)
                                   .ToList();
        }
    }
}
