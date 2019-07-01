using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcial2_JohnsielCastanos.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial2_JohnsielCastanos.DAL;
using Parcial2_JohnsielCastanos.Entidades;

namespace Parcial2_JohnsielCastanos.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
      
           [TestMethod()]
        public void AsignaturaGuardarTest()
        {
            Asignaturas a = new Asignaturas();
            a.AsignaturaId = 1;
            a.Descripcion = "lengua espanola";
            a.Creditos = 5;

            RepositorioBase<Asignaturas> r = new RepositorioBase<Asignaturas>();
            bool paso = false;
            paso = r.Guardar(a);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void AsignaturaModificarTest()
        {
            RepositorioBase<Asignaturas> repositorio = new RepositorioBase<Asignaturas>();
            bool paso = false;
            Asignaturas a = repositorio.Buscar(1);
            a.Creditos = 4;
            paso = repositorio.Modificar(a);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void AsignaturasBuscarTest()
        {
            RepositorioBase<Asignaturas> repositoriobase = new RepositorioBase<Asignaturas>();
            Asignaturas a = repositoriobase.Buscar(1);
            Assert.IsNotNull(a);
        }

        [TestMethod()]
        public void AsignaturasGetListTest()
        {
            RepositorioBase<Asignaturas> repositorio = new RepositorioBase<Asignaturas>();
            List<Asignaturas> lista = new List<Asignaturas>();
            lista = repositorio.GetList(e => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void EstudianteGuardarTest()
        {
            Estudiantes e = new Estudiantes();
            e.EstudianteId = 1;
            e.FechaIngreso = DateTime.Now;
            e.Nombre = "Johnsiel";
            e.Balance = 2000;

            RepositorioBase<Estudiantes> r = new RepositorioBase<Estudiantes>();
            bool paso = false;
            paso = r.Guardar(e);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void EstudianteModificarTest()
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();
            bool paso = false;
            Estudiantes e = repositorio.Buscar(1);
            e.Nombre = "Maria";
            paso = repositorio.Modificar(e);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void EstudianteBuscarTest()
        {
            RepositorioBase<Estudiantes> repositoriobase = new RepositorioBase<Estudiantes>();
            Estudiantes e = repositoriobase.Buscar(1);
            Assert.IsNotNull(e);
        }

        [TestMethod()]
        public void EstudianteGetListTest()
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();
            List<Estudiantes> lista = new List<Estudiantes>();
            lista = repositorio.GetList(e => true);
            Assert.IsNotNull(lista);
        }
        [TestMethod()]
        public void InscripcionGuardarTest()
        {
            Inscripcion i = new Inscripcion();
            i.InscripcionId = 1;
            i.EstudianteId = 1;
            i.FechaInscripcion = DateTime.Now;
            i.MontoCreditos = 2000;


            RepositorioBase<Inscripcion> r = new RepositorioBase<Inscripcion>();
            bool paso = false;
            paso = r.Guardar(i);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void InscripcionModificarTest()
        {
            RepositorioBase<Inscripcion> repositorio = new RepositorioBase<Inscripcion>();
            bool paso = false;
            Inscripcion i = repositorio.Buscar(1);
            i.MontoCreditos = 200;
            paso = repositorio.Modificar(i);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void InscripcionBuscarTest()
        {
            RepositorioBase<Inscripcion> repositoriobase = new RepositorioBase<Inscripcion>();
            Inscripcion i = repositoriobase.Buscar(1);
            Assert.IsNotNull(i);
        }

        [TestMethod()]
        public void InscripcionGetListTest()
        {
            RepositorioBase<Inscripcion> repositorio = new RepositorioBase<Inscripcion>();
            List<Inscripcion> lista = new List<Inscripcion>();
            lista = repositorio.GetList(e => true);
            Assert.IsNotNull(lista);
        }
        [TestMethod()]
        public void AsignaturaEliminarTest()
        {
            RepositorioBase<Asignaturas> repositoriobase = new RepositorioBase<Asignaturas>();
            bool paso = false;
            paso = repositoriobase.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void EstudiantesEliminarTest()
        {
            RepositorioBase<Estudiantes> repositoriobase = new RepositorioBase<Estudiantes>();
            bool paso = false;
            paso = repositoriobase.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void InscripcionEliminarTest()
        {
            RepositorioBase<Inscripcion> repositoriobase = new RepositorioBase<Inscripcion>();
            bool paso = false;
            paso = repositoriobase.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
    }
}
    
