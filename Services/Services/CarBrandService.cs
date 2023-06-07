using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CarBrandService : Service<CarBrand>, ICarBrandService
    {
        public CarBrandService(IUnitOfWork unitOfWork, IRepository<CarBrand> repository) : base(unitOfWork, repository)
        {
        }

        public ICollection<CarBrand> GetAllInclude()
        {
            return _unitOfWork.CarBrand.GetAllInclude();
        }
    }
}
