﻿using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Vanzator
    {
        [Key]
        public int Id { get; set; }

        public string Nume { get; set; }

        public string Telefon { get; set; }
    }
}
