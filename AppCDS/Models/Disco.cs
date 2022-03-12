using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCDS.Models
{
    [Index(nameof(NombreDisco), IsUnique = true)]
    public class Disco
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Autor { get; set; }

        [Display(Name = "Disco")]
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string NombreDisco { get; set; }
        
        [Required]
        [Display(Name = "Canciones")]
        public int NumeroCanciones { get; set; }

        [Required]
        [Range(1980, 2022)]
        [Display(Name = "Año")]
        public int Anio { get; set; }
    }
}
