using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCDS.Models
{
    public class DiscoCategoriasViewModel
    {
        public List<Disco> Discos { get; set; }
        public SelectList Autores { get; set; }
        public string DiscoAutor { get; set; }
        public SelectList Anios { get; set; }
        public int DiscoAnio { get; set; }
        public string SearchString { get; set; }
        public int TotalDiscos { get; set; }
    }
}
