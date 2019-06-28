using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_JohnsielCastanos.Entidades
{
    public class Estudiantes
    {
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public double Balance { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Estudiantes()
        {
            EstudianteId = 0;
            Nombre = string.Empty;
            Balance = 0;
            FechaIngreso = DateTime.Now;
        }
    }
}
