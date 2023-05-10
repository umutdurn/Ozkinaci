using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Advert
    {
        public int Id { get; set; }
        public CarModel CarModel { get; set; }
        public Gear Gear { get; set; }

    }
}
