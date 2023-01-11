using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Producator
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


    }
}
