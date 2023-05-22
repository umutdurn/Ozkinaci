using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Category
    {
        public Category()
        {
            CarModels = new Collection<CarModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CarModel> CarModels { get; set; }
        public int Order { get; set; }
    }
}
