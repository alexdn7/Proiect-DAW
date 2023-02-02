using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Producator
    {
        [Key]
        public int Id { get; set; }

        public string Nume { get; set; }

        public string Descriere { get; set; } 

        public string Adresa { get; set; }

    }
}
