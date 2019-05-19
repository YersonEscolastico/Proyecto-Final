using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Usuarios { get; set; }
        public string NivelUsuario { get; set; }
        public string Clave { get; set; }
        public string Confirmar_Clave { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Usuario()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Usuarios = string.Empty;
            NivelUsuario = string.Empty;
            Clave = string.Empty;
            Confirmar_Clave = string.Empty;
            FechaIngreso = DateTime.Now;
        }
    }
}
