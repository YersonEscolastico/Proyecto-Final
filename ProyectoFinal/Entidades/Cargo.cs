using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    class Cargo
    {
        [Key]
        public int CargoId { get; set; }
        public string Descripcion { get; set; }

        public Cargo()
        {
            CargoId = 0;
            Descripcion= string.Empty;
        }
    }
}
