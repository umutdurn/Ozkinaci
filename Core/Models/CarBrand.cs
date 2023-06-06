using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CarBrand
    {
        public CarBrand()
        {
            CarModel = new Collection<CarModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public ICollection<CarModel> CarModel { get; set; }
    }
}
