using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial2_JohnsielCastanos.DAL;
using Parcial2_JohnsielCastanos.Entidades;
using System.Data.Entity;

namespace Parcial2_JohnsielCastanos.BLL
{
    public class InscripcionBLL
    {

        public static bool Modificar(Inscripcion inscripcion)
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
        public static bool Guardar(Inscripcion inscripcion)
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
                    estudiante.Balance = (double)inscripcion.MontoInscripcion;
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

    }
}
