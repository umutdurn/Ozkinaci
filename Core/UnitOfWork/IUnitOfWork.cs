using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IAdvertRepository Advert { get; }
        public ICarModelRepository CarModel { get; }
        public IEquipmentRepository Equipment { get; }

        Task CommitAsync();
        void Commit();
    }
}
