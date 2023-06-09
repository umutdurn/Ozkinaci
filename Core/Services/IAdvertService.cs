﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAdvertService : IService<Advert>
    {
        ICollection<Advert> GetAllInclude();
        ICollection<Advert> ShowcaseInclude();
        Advert GetByIdInclude(int id);
    }
}
