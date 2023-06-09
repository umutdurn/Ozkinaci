using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Expertiz
    {
        public int Id { get; set; }
        public Advert Advert { get; set; }
        public string OnTampon { get; set; }
        public string OnSagCamurluk { get; set; }
        public string OnSolCamurluk { get; set; }
        public string Kaput { get; set; }
        public string OnSagKapi { get; set; }
        public string OnSolKapi { get; set; }
        public string ArkaSagKapi { get; set; }
        public string ArkaSolKapi { get; set; }
        public string Tavan { get; set; }
        public string ArkaSolCamurluk { get; set; }
        public string ArkaSagCamurluk { get; set; }
        public string BagajKapagi { get; set; }
        public string ArkaTampon { get; set; }
    }
}
