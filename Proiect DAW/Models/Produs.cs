using Proiect_DAW.Models.Base;
using System.Collections.Generic;

namespace Proiect_DAW.Models
{
    public class Produs: BaseEntity
    {
        public string ImgURL { get; set; }
        public string Denumire { get; set; }

        public string Descriere { get; set; }

        public double Pret { get; set; }
        public int Stoc { get; set; }

        public Producator Producator { get; set; }
        public ICollection<Produs_Vanzator> Produs_Vanzator { get; set; }

    }
}
