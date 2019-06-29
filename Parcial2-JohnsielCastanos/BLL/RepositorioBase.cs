using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Parcial2_JohnsielCastanos.DAL;
using System.Linq.Expressions;
using Parcial2_JohnsielCastanos.Entidades;

namespace Parcial2_JohnsielCastanos.BLL
{
    public class RepositorioBase<T> : IDisposable, IRepositorio<T> where T : class
    {
        internal Contexto _contexto;

         public RepositorioBase(Contexto contexto)
         {
            _contexto = contexto;
         }


        public virtual bool ModificarDetalle(Inscripcion inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Estudiantes> dbEst = new RepositorioBase<Estudiantes>(new DAL.Contexto());


            try
            {
                var estudiante = dbEst.Buscar(inscripcion.EstudianteId);
                var anterior = new RepositorioBase<Inscripcion>(new DAL.Contexto()).Buscar(inscripcion.InscripcionId);
                estudiante.Balance -= (double)anterior.MontoInscripcion;

                foreach (var item in anterior.Asignaturas)
                {
                    if (!inscripcion.Asignaturas.Any(A => A.Id == item.Id))
                    {
                        db.Entry(item).State = EntityState.Deleted;

                    }

                }

                foreach (var item in inscripcion.Asignaturas)
                {
                    if (item.Id == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }
                }


                inscripcion.CalcularMonto();
                estudiante.Balance += (double)inscripcion.MontoInscripcion;
                dbEst.Modificar(estudiante);

                db.Entry(inscripcion).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }
        public virtual bool GuardarDetalle(Inscripcion inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                RepositorioBase<Estudiantes> dbE = new RepositorioBase<Estudiantes>(new DAL.Contexto());

                if (db.Inscripcion.Add(inscripcion) != null)
                {
                    var estudiante = dbE.Buscar(inscripcion.EstudianteId);

                    inscripcion.CalcularMonto();
                    estudiante.Balance =  (double)inscripcion.MontoInscripcion;
                    paso = db.SaveChanges() > 0;
                    dbE.Modificar(estudiante);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public virtual bool Guardar(T entity)
        {
             bool paso = false;

             try
             {
                 if (_contexto.Set<T>().Add(entity) != null)
                 {
                    _contexto.SaveChanges(); 
                    paso = true;
                 }
             }
             catch (Exception)
             {
                  throw;
             }
             return paso;
        }

            
         public virtual bool Modificar(T entity)
         {
             bool paso = false;
             try
             {
                _contexto.Entry(entity).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                {
                     paso = true;
                }
             }
             catch (Exception)
             {
                throw;
             }
             return paso;
         }

        public virtual  bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                 T entity = _contexto.Set<T>().Find(id);
                 _contexto.Set<T>().Remove(entity);

                 if (_contexto.SaveChanges() > 0)
                 {
                     paso = true;
                 }
                    _contexto.Dispose();
                 }
            catch (Exception)
            {
                 throw;
            }
             return paso;
        }

        
        public virtual T Buscar(int id)
        {
            T entity;
             try
             {
                 entity = _contexto.Set<T>().Find(id);
             }
             catch (Exception)
             {
                throw;
             }
             return entity;
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> expression)
        {
             List<T> Lista = new List<T>();
             try
             {
                Lista = _contexto.Set<T>().Where(expression).ToList();
             }
             catch (Exception)
             {
                 throw;
             }
             return Lista;
        }

        public virtual void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
