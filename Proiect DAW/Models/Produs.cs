﻿using Proiect_DAW.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Produs: BaseEntity
    {
        public string ImgURL { get; set; }
        public string Denumire { get; set; }

        public string Descriere { get; set; }

        public decimal Pret { get; set; }
        public int Stoc { get; set; }

        public ICollection<Produs_Vanzator> Produs_Vanzator { get; set; }


    }
}
