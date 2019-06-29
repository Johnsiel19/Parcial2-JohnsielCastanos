using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Parcial2_JohnsielCastanos.Entidades;

namespace Parcial2_JohnsielCastanos.BLL
{
    public interface IRepositorio<T> where T : class
    {
        List<T> GetList(Expression<Func<T, bool>> expression);
        T Buscar(int id);
        bool Guardar(T entity);
        bool GuardarDetalle(Inscripcion inscripcion);
        bool ModificarDetalle(Inscripcion inscripcion);
        bool Modificar(T entity);
        bool Eliminar(int id);
       



    }

}
