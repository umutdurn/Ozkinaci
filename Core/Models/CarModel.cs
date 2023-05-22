using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CarModel
    {
        public CarModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public CarBrand CarBrand { get; set; }
        public string Detail { get; set; }
        public Equipment? Equipment { get; set; }
        public int Order { get; set; }

    }
}
