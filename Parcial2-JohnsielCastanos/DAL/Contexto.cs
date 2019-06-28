using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Parcial2_JohnsielCastanos.Entidades;
using System.Data.Entity;

namespace Parcial2_JohnsielCastanos.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Inscripcion> Inscripcions { get; set; }


        public Contexto() : base("ConStr")
        { }
    }
}
