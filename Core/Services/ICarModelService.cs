using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICarModelService : IService<CarModel>
    {
        ICollection<CarModel> GetAllIncludeModels();
        ICollection<CarModel> GetAllIncludeModelsByCarBrand(CarBrand carBrand);
        CarModel GetByIdIncludeModels(int id);
    }
}
