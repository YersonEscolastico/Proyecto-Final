using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Aqui agregamos public tambien, para que la clase pueda pueda ser encontrada en cualquier parte del proyecto,
//Y heredamos de BbContext para que EntityFrameWork pueda hacer su magia
namespace Registro.DAL.Scripts
{
   public class Contexto : DbContext
    {
        public DbSet<Entidades.Usuario> usuarios { get; set; }

        //base("ConStr") para pasar la conexion a la clase de EntityFrameWork
        public Contexto() : base("ConStr")
        { }
    }
}
