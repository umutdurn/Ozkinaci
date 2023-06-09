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

        public Advert GetByIdInclude(int id)
        {
            return _unitOfWork.Advert.GetByIdInclude(id);
        }

        public ICollection<Advert> ShowcaseInclude()
        {
            return _unitOfWork.Advert.ShowcaseInclude();
        }
    }
}
