using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAdvertRepository : IRepository<Advert>
    {
        ICollection<Advert> GetAllInclude();
        Advert GetByIdInclude(int id);
    }
}
