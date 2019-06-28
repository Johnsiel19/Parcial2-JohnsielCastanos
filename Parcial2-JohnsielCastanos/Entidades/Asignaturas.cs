using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_JohnsielCastanos.Entidades
{
    public class Asignaturas
    {

        public int MateriaId { get; set; }
        public string Descripcion { get; set; }
        public int Creditos { get; set; }

        public Asignaturas()
        {
            MateriaId = 0;
            Descripcion = string.Empty;
            Creditos = 0;

        }
    }
}
