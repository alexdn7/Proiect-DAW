using Proiect_DAW.Models.Base;
using System.Collections.Generic;

namespace Proiect_DAW.Models
{
    public class Vanzator: BaseEntity
    {
        public string Nume { get; set; }

        public string Telefon { get; set; }

        public ICollection <Produs_Vanzator> Produs_Vanzator { get; set; }

    }
}
