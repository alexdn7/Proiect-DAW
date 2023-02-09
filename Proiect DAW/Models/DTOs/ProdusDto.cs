using System;

namespace Proiect_DAW.Models.DTOs
{
    public class ProdusDto
    {
        public string ImgURL { get; set;}
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        public double Pret { get; set; }
        public int Stoc { get; set; }

        public Guid ProducatorID { get; set; }
    }
}
