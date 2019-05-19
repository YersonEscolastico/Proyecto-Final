using Registro.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Registro.Entidades;
using System.Data.Entity;
using Registro.DAL.Scripts;

namespace Registro.BLL
{
    ///<summary>
    ///Debemos programar toda la logica de negogios
    ///</summary>

        public class UsuariosBll
        {
        ///<summary>
        ///Permite guardar una entidad en la base de datos
        ///</summary>
        public static bool Guardar(Usuario usuarios)
            {
                bool paso = false;
                Contexto db = new Contexto();
                try
                {
                    if (db.usuarios.Add(usuarios) != null)
                    {
                        db.SaveChanges();
                        paso = true;
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
        public static bool Modificar(Usuario usuarios)
            {
                bool paso = false;
                Contexto db = new Contexto();

                try
                {
                    db.Entry(usuarios).State = System.Data.Entity.EntityState.Modified;
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
        public static bool Eliminar(int id)
            {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.usuarios.Find(id);
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
        public static Usuario Buscar(int id)
            {
                Contexto db = new Contexto();
                Usuario usuarios = new Usuario();
                try
                {
                    usuarios = db.usuarios.Find(id);
                    db.Dispose();
                }
                catch (Exception)
                {
                    throw;
                }
                return usuarios;
            }

        ///<summary>
        ///Permite estraer una lista de personas de la base de datos
        ///</summary>
        public static List<Usuario> GetList(Expression<Func<Usuario, bool>> persona)
            {
                List<Usuario> people = new List<Usuario>();
                Contexto db = new Contexto();
                try
                {
                    people = db.usuarios.Where(persona).ToList();
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





