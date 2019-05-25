using Registro.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Registro.Entidades;
using System.Data.Entity;
using ProyectoFinal.Entidades;

namespace ProyectoFinal.BLL
{
    public class CargosBLL
    {

        ///<summary>
        ///Permite guardar una entidad en la base de datos
        ///</summary>
        public static bool Guardar(Cargos cargos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.cargos.Add(cargos) != null)
                {
                    paso = db.SaveChanges() > 0;
                }

                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        ///<summary>
        ///Permite modificar una entidad en la base de datos
        ///</summary>
        public static bool Modificar(Cargos cargos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(cargos).State = System.Data.Entity.EntityState.Modified;
                paso = (db.SaveChanges() > 0);
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        ///<summary>
        ///Permite eliminar una entidad en la base de datos
        ///</summary>
        public static bool Eliminar(int CargoId)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.cargos.Find(CargoId);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        ///<summary>
        ///Permite buscar una entidad en la base de datos
        ///</summary>
        public static Cargos Buscar(int id)
        {
            Contexto db = new Contexto();
            Cargos cargos = new Cargos();
            try
            {
                cargos = db.cargos.Find(id);
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return cargos;
        }

        ///<summary>
        ///Permite estraer una lista de personas de la base de datos
        ///</summary>
        public static List<Cargos> GetList(Expression<Func<Cargos, bool>> cargos)
        {
            List<Cargos> people = new List<Cargos>();
            Contexto db = new Contexto();
            try
            {
                people = db.cargos.Where(cargos).ToList();
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return people;
        }
    }
}



