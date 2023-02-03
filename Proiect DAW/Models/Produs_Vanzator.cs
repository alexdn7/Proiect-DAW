using Proiect_DAW.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Produs_Vanzator
    {
        public Guid ProdusId { get; set; }
        public Produs Produs { get; set; }


        public Guid VanzatorId { get; set; }
        public Vanzator Vanzator { get; set; }

    }
}
