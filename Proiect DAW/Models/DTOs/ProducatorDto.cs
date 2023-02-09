using System;
using System.Collections.Generic;

namespace Proiect_DAW.Models.DTOs
{
    public class ProducatorDto
    {
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public Guid LocatieId { get; set; }
        public ICollection<Produs> Produse { get; set; }
    }
}
