using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Advert
    {
        public Advert()
        {
            Gallery = new Collection<Gallery>();
            Expertiz = new Collection<Expertiz>();
        }
        public bool Showcase { get; set; }
        public int Id { get; set; }
        public CarModel CarModel { get; set; }
        public Equipment? Equipment { get; set; }
        public int Gear { get; set; } //0 Otomatik, 1 Vitesli
        public int Fuel { get; set; } //0 Dizel, 1 Benzinli, 2 Elektrikli
        public int Year { get; set; }
        public float Km { get; set; }
        public string MaxSpeed { get; set; }
        public string To0100 { get; set; }
        public string Tork { get; set; }
        public float EmptyWeight { get; set; }
        public int? FuelTank { get; set; }
        public string FuelConsumption { get; set; } // Yakıt Tüketimi
        public string CylinderVolume { get; set; } // Silindir Hacmi
        public int CylinderNumber { get; set; } // Silindir Adedi
        public int ValveNumber { get; set; } // Supap Adedi
        public string CaseType { get; set; } // Kasa tipi
        public string EnginePower { get; set; } // Motor Gücü
        public string Color { get; set; } // Araç Rengi
        public string TypeOfTransfer { get; set; } // Aktarma Türü
        public decimal Price { get; set; }
        public ICollection<Gallery> Gallery { get; set; }
        public ICollection<Expertiz> Expertiz { get; set; }

    }
}
