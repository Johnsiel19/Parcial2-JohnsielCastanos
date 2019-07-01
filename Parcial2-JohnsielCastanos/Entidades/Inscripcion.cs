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
        public int EstudianteId { get; set; }
        //[ForeignKey("EstudianteId")]
        public DateTime FechaInscripcion { get; set; }
        public double MontoInscripcion{ get; set; }
        public double MontoCreditos { get; set; }
        
        public virtual List<InscripcionDetalle> Asignaturas { get; set; }


        public Inscripcion()
        {
            InscripcionId = 0 ;
            FechaInscripcion = DateTime.Now;
            MontoInscripcion = 0;
            MontoCreditos = 0;
            EstudianteId = 0;
            Asignaturas = new List<InscripcionDetalle>();

        }

        public void CalcularMonto()
        {
            double total = 0;
            foreach (var item in Asignaturas)
            {
                total += (double)item.SubTotal;
            }
            MontoInscripcion = total;
        }
    }
}
