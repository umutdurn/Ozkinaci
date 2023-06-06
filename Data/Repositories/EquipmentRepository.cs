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
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public EquipmentRepository(AppDbContext context) : base(context)
        {
        }

        public Equipment GetByIdAllInclude(int id)
        {
            return _appDbContext.Equipment.Include(x => x.CarModel).ThenInclude(x => x.CarBrand).FirstOrDefault(x => x.Id == id);
        }
    }
}
