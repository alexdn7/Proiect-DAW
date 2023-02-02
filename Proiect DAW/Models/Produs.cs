using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Produs
    {
        public string ImgURL { get; set; }

        [Key]
        public int Id { get; set; }

        public string Denumire { get; set; }

        public string Descriere { get; set; }

        public decimal Pret { get; set; }
        public int Stoc { get; set; }

    }
}
