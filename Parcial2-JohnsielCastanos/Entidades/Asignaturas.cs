using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Parcial2_JohnsielCastanos.Entidades
{
    public class Asignaturas
    {
        [Key]
        public int AsignaturaId { get; set; }
        public string Descripcion { get; set; }
        public int Creditos { get; set; }

        public Asignaturas()
        {
            AsignaturaId = 0;
            Descripcion = string.Empty;
            Creditos = 0;

        }
    }
}
