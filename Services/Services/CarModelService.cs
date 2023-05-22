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
    public class CarModelService : Service<CarModel>, ICarModelService
    {
        public CarModelService(IUnitOfWork unitOfWork, IRepository<CarModel> repository) : base(unitOfWork, repository)
        {
        }

        public ICollection<CarModel> GetAllIncludeModels()
        {
            return _unitOfWork.CarModel.GetAllIncludeModels();
        }
    }
}
