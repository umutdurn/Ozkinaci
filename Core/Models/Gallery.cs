using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public Advert Advert { get; set; }
        public int Order { get; set; }
    }
}
