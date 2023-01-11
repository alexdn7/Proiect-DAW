using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }

        public string Denumire { get; set; }

        public string Descriere { get; set; }
    }
}
