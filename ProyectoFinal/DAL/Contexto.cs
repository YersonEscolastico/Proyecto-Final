using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.Entidades;
using Registro.DAL;
using Registro.Entidades;

//Aqui agregamos public tambien, para que la clase pueda pueda ser encontrada en cualquier parte del proyecto,
//Y heredamos de BbContext para que EntityFrameWork pueda hacer su magia
namespace Registro.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Cargos> cargos { get; set; }


        //base("ConStr") para pasar la conexion a la clase de EntityFrameWork
        public Contexto() : base("ConStr")
        { }
    }
}
