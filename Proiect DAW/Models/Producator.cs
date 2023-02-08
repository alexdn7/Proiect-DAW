using Proiect_DAW.Models.Base;
using System;
using System.Collections.Generic;

namespace Proiect_DAW.Models
{
    public class Producator: BaseEntity
    {
        public string Nume { get; set; }

        public string Descriere { get; set; } 

        public string Adresa { get; set; }

        public Locatie Locatie { get; set; }
        public Guid LocatieId { get; set; }

        public ICollection<Produs> Produse { get; set; }
    }
}
