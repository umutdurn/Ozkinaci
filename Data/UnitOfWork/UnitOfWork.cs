﻿using Core.Models;
using Core.Repositories;
using Core.UnitOfWork;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private AdvertRepository _advertRepository;
        private CarModelRepository _carModelRepository;
        private EquipmentRepository _equipmentRepository;
        private CarBrandRepository _carBrandRepository;

        public IAdvertRepository Advert => _advertRepository ?? new AdvertRepository(_appDbContext);
        public ICarModelRepository CarModel => _carModelRepository ?? new CarModelRepository(_appDbContext);

        public IEquipmentRepository Equipment => _equipmentRepository ?? new EquipmentRepository(_appDbContext);

        public ICarBrandRepository CarBrand => _carBrandRepository ?? new CarBrandRepository(_appDbContext);

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
