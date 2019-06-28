using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_JohnsielCastanos.Entidades
{
    public class Inscripcion
    {
        public int InscripcionId { get; set; }    
        public DateTime FechaInscripcion { get; set; }
        public decimal Monto { get; set; }
        public int EstudianteId { get; set; }
       // [ForeignKey("EstudianteId")]
        public virtual List<InscripcionDetalle> Asignaturas { get; set; }
        public Inscripcion()
        {
            InscripcionId = 0 ;
            FechaInscripcion = DateTime.Now;
            Monto = 0;
            EstudianteId = 0;
            Asignaturas = new List<InscripcionDetalle>();

        }
    }
}
