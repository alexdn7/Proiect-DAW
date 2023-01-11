using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Vanzator
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
