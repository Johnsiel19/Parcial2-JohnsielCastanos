using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial2_JohnsielCastanos.Entidades;
using Parcial2_JohnsielCastanos.DAL;
using Parcial2_JohnsielCastanos.BLL;

namespace Parcial2_JohnsielCastanos.UI.Registro
{
    public partial class rAsignaturas : Form
    {
        public rAsignaturas()
        {
            InitializeComponent();
        }
        public static bool NoDuplicado(string descripcion)
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>(new DAL.Contexto());
            bool paso = false;
            Contexto db2 = new Contexto();

            try
            {
                if (db2.Asignaturas.Any(p => p.Descripcion.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private void Limpiar()
        {
            AsignaturaIdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            CreditosnumericUpDown.Value = 0;
            errorProvider.Clear();

        }

        private Asignaturas LlenaClase()
        {
            Asignaturas asignatura = new Asignaturas();
            asignatura.AsignaturaId = Convert.ToInt32(AsignaturaIdnumericUpDown.Value);
            asignatura.Descripcion = DescripciontextBox.Text;
            asignatura.Creditos = Convert.ToInt32(CreditosnumericUpDown.Value);
            return asignatura;

        }

        private void LlenaCampo(Asignaturas asignaturas )
        {
            AsignaturaIdnumericUpDown.Value = asignaturas.AsignaturaId;
            DescripciontextBox.Text = asignaturas.Descripcion;
            CreditosnumericUpDown.Value = asignaturas.Creditos;
  

        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                errorProvider.SetError(DescripciontextBox, "Este campo no puede estar vacio");
                paso = false;
            }

            if (CreditosnumericUpDown.Value == 0)
            {
                errorProvider.SetError(CreditosnumericUpDown, "Los creditos no pueden ser cero");
                paso = false;

            }
            if (NoDuplicado(DescripciontextBox.Text))
            {
                errorProvider.SetError(DescripciontextBox, "El nombre de la asignatura no debe ser igual a ningun otro");
                paso = false;

            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>(new DAL.Contexto());
            Asignaturas asigantura = db.Buscar((int)AsignaturaIdnumericUpDown.Value);
            return (asigantura != null);

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>(new DAL.Contexto());
            Asignaturas asignatura;
            bool paso = false;

            if (!Validar())
                return;

            asignatura = LlenaClase();


            if (AsignaturaIdnumericUpDown.Value == 0)
            {
                paso = db.Guardar(asignatura);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una Asignatura que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(asignatura);

            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>(new DAL.Contexto());
            errorProvider.Clear();
            int id;
            int.TryParse(AsignaturaIdnumericUpDown.Text, out id);
            Limpiar();
            if (db.Eliminar(id))
            {
                MessageBox.Show("Eliminado");
            }
            else
            {
                errorProvider.SetError(AsignaturaIdnumericUpDown, "No se puede elimina, porque no existe");
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>(new DAL.Contexto());
            int id;
            Asignaturas asignaturas = new Asignaturas();

            int.TryParse(AsignaturaIdnumericUpDown.Text, out id);
            Limpiar();

            asignaturas = db.Buscar(id);

            if (asignaturas != null)
            {
                MessageBox.Show("Asignatura escontrada");
                LlenaCampo(asignaturas);

            }
            else
            {
                MessageBox.Show("Asignatura  no existe");
            }
        }
    }
}
