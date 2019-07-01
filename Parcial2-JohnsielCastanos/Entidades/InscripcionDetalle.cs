using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_JohnsielCastanos.Entidades
{
    public class InscripcionDetalle
    {
        [Key]
        public int Id { get; set; }
        public int InscripcionId { get; set; }
       // [ForeignKey("InscripcionId")]

        public int AsignaturaId { get; set; }
       //[ForeignKey("AsignaturaId")]

        public decimal SubTotal { get; set;}



        public InscripcionDetalle()
        {
            Id = 0;
            InscripcionId = 0;
            AsignaturaId = 0;
            SubTotal = 0;
        }
        public InscripcionDetalle(int id, int Inscricionid, int asignaturaid)
        {


            Id = id;
            InscripcionId = Inscricionid;
            AsignaturaId = asignaturaid;
            SubTotal = 0;


        }

        //Constructor Con parametros con ID
        public InscripcionDetalle( int Inscricionid, int asignaturaid)
        {

            InscripcionId = Inscricionid;
            AsignaturaId = asignaturaid;
            SubTotal = 0;


        }



    }
}
