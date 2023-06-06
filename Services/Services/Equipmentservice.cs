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
    public class Equipmentservice : Service<Equipment>, IEquipmentService
    {
        public Equipmentservice(IUnitOfWork unitOfWork, IRepository<Equipment> repository) : base(unitOfWork, repository)
        {
        }

        public Equipment GetByIdAllInclude(int id)
        {
            return _unitOfWork.Equipment.GetByIdAllInclude(id);
        }
    }
}
