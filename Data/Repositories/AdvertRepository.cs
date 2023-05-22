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
    public class AdvertRepository : Repository<Advert>, IAdvertRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public AdvertRepository(AppDbContext context) : base(context)
        {

        }

        public ICollection<Advert> GetAllInclude()
        {
            return _appDbContext.Advert.Include(x => x.CarModel)
                                       .ThenInclude(x => x.CarBrand)
                                       .ToList();
        }
    }
}
