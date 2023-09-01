﻿using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data.Repositories
{
    public class AdvertRepository : Repository<Advert>, IAdvertRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public AdvertRepository(AppDbContext context) : base(context)
        {

        }

        public ICollection<Advert> GetAllInclude()
        {
            return _appDbContext.Advert.Include(x => x.CarModel)
                                       .ThenInclude(x => x.CarBrand)
                                       .Include(x => x.Gallery)
                                       .Include(x => x.Equipment)
                                       .Include(x => x.Color)
                                       .ToList();
        }

        public Advert GetByIdInclude(int id)
        {
            return _appDbContext.Advert.Include(x => x.CarModel)
                                       .ThenInclude(x => x.CarBrand)
                                       .ThenInclude(x => x.CarModel)
                                       .Include(x => x.CarModel)
                                       .ThenInclude(x => x.Equipment)
                                       .Include(x => x.Gallery)
                                       .Include(x => x.Expertiz)
                                       .Include(x => x.Color)
                                       .FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Advert> ShowcaseInclude()
        {
            return _appDbContext.Advert.Where(x => x.Showcase == true)
                                        .Include(x => x.CarModel)
                                        .ThenInclude(x => x.CarBrand)
                                        .Include(x => x.Gallery)
                                        .Include(x => x.Equipment)
                                        .Include(x => x.Color)
                                        .ToList();
        }
    }
}
