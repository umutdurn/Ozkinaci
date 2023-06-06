using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CarModelRepository : Repository<CarModel>, ICarModelRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CarModelRepository(AppDbContext context) : base(context)
        {
        }

        public ICollection<CarModel> GetAllIncludeModels()
        {
            return _appDbContext.CarModels.Include(x => x.Category)
                                          .Include(x => x.CarBrand)
                                          .Include(x => x.Equipment).ToList();
        }

        public CarModel GetByIdIncludeModels(int id)
        {
            return _appDbContext.CarModels.Include(x => x.Equipment).Include(x => x.Category).Include(x => x.CarBrand).FirstOrDefault(x => x.Id == id);
        }

        public ICollection<CarModel> GetAllIncludeModelsByCarBrand(CarBrand carBrand)
        {
            return _appDbContext.CarModels.Where(x => x.CarBrand == carBrand).ToList();
        }
    }
}
