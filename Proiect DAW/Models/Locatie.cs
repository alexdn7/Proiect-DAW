using Proiect_DAW.Models.Base;

namespace Proiect_DAW.Models
{
    public class Locatie: BaseEntity
    {
        public string Tara { get; set; }
        public string Oras { get; set; }
        public string Strada { get; set; }

        public Producator Producator { get; set; }
    }
}
