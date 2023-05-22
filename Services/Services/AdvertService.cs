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
    public class AdvertService : Service<Advert>, IAdvertService
    {
        public AdvertService(IUnitOfWork unitOfWork, IRepository<Advert> repository) : base(unitOfWork, repository)
        {
        }

        public ICollection<Advert> GetAllInclude()
        {
            return _unitOfWork.Advert.GetAllInclude();
        }
    }
}
