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
    
    public partial class rInscripcion : Form
    {
        public List<InscripcionDetalle> Detalle { get; set; }
        public rInscripcion()
        {
            InitializeComponent();
            LlenarComboBox();
            LLenarComboBox2();
            EstudiantecomboBox.Text = null;
            AsignaturacomboBox.Text = null;
            this.Detalle = new List<InscripcionDetalle>();
        }

        private void Limpiar()
        {
            InscripcionIdnumericUpDown.Value = 0;
            MontoInscripciontextBox.Text = string.Empty;
            EstudiantecomboBox.Text = string.Empty;
            AsignaturacomboBox.Text = string.Empty;
            MontonumericUpDown.Value = 0;
            this.Detalle = new List<InscripcionDetalle>();
            errorProvider.Clear();
            CargarGrid();
        }
       
        private Inscripcion LlenaClase()
        {
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.Asignaturas = this.Detalle;
   
            inscripcion.EstudianteId = Convert.ToInt32(EstudiantecomboBox.SelectedValue);
            
            
            inscripcion.InscripcionId = Convert.ToInt32(InscripcionIdnumericUpDown.Value);
            inscripcion.MontoCreditos = (double)MontonumericUpDown.Value;
            inscripcion.CalcularMonto();
            inscripcion.FechaInscripcion = FechaInscripciondateTimePicker.Value;
            
            return inscripcion;

        }

        private void Obtener(Inscripcion inscripcion)
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            Estudiantes asignaturas;

            asignaturas = db.Buscar(inscripcion.EstudianteId);

            LlenarComboBox3(asignaturas);



        }

        private void LlenarComboBox3(Estudiantes estudiante)
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            var listado2 = new List<Estudiantes>();
            listado2 = db.GetList(p => p.EstudianteId == estudiante.EstudianteId);
            EstudiantecomboBox.DataSource = listado2;
            EstudiantecomboBox.DisplayMember = "Nombre";
            EstudiantecomboBox.ValueMember = "EstudianteId";

        }
        private void LlenaCampo(Inscripcion inscripcion)
        {
            InscripcionIdnumericUpDown.Value = inscripcion.InscripcionId;
            if(InscripcionIdnumericUpDown.Value >0)
            {
                Obtener(inscripcion);

            }
            MontoInscripciontextBox.Text = inscripcion.MontoInscripcion.ToString();
            MontonumericUpDown.Value = (decimal)inscripcion.MontoCreditos;
            FechaInscripciondateTimePicker.Value = inscripcion.FechaInscripcion;
            this.Detalle = inscripcion.Asignaturas;
            CargarGrid();
  
        }

        private void CargarGrid()
        {
            detalleDataGridView.DataSource = null;
            detalleDataGridView.DataSource = Detalle;
        }

        private bool Validar()
        {

            bool paso = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(EstudiantecomboBox.Text))
            {
                errorProvider.SetError(EstudiantecomboBox, "El campo Estudiante no puede estar vacio");
                EstudiantecomboBox.Focus();
                paso = false;
            }

            if (MontonumericUpDown.Value == 0)
            {
                errorProvider.SetError(MontonumericUpDown, "Debes elegir un monto de creditos");
                MontonumericUpDown.Focus();
                paso = false;
            }

            if (Detalle.Count == 0){
                errorProvider.SetError(AsignaturacomboBox, "La inscripcion por lo menos debe tener una asignatura");
                AsignaturacomboBox.Focus();
                paso = false;
            }


            if (FechaInscripciondateTimePicker.Value > DateTime.Now)
            {
                errorProvider.SetError(FechaInscripciondateTimePicker, "La fecha no puede ser despues de hoy");
                FechaInscripciondateTimePicker.Focus();
                paso = false;
            }


            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Inscripcion> db = new RepositorioBase<Inscripcion>();
            Inscripcion inscripcion = db.Buscar((int)InscripcionIdnumericUpDown.Value);
            return (inscripcion != null);
        }

        private void LlenarComboBox()
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();
            var listado2 = new List<Asignaturas>();
            listado2 = db.GetList(p => true);
            AsignaturacomboBox.DataSource = listado2;
            AsignaturacomboBox.DisplayMember = "Descripcion";
            AsignaturacomboBox.ValueMember = "AsignaturaId";

        }

        private void LLenarComboBox2()
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            var listado = new List<Estudiantes>();
            listado = db.GetList(l => true);
            EstudiantecomboBox.DataSource = listado;
            EstudiantecomboBox.DisplayMember = "Nombre";
            EstudiantecomboBox.ValueMember = "EstudianteId";
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Inscripcion> db = new RepositorioBase<Inscripcion>();
            int id;
            Inscripcion inscripcion = new Inscripcion();

            int.TryParse(InscripcionIdnumericUpDown.Text, out id);
            Limpiar();

            inscripcion = db.Buscar(id);

            if (inscripcion != null)
            {
                LlenaCampo(inscripcion);
            }
            else
            {
                MessageBox.Show("Inscripcion no existe");
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            
            Inscripcion inscripcion;
            bool paso = false;

            if (!Validar())
                return;

            inscripcion = LlenaClase();
            inscripcion.CalcularMonto();
            if (InscripcionIdnumericUpDown.Value == 0)
            {
                paso = InscripcionBLL.Guardar(inscripcion);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una inscripcion que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso= InscripcionBLL.Modificar(inscripcion);

            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Inscripcion> db = new RepositorioBase<Inscripcion>();
            errorProvider.Clear();
            int id;
            int.TryParse(InscripcionIdnumericUpDown.Text, out id);
            Limpiar();
            if (InscripcionBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado");
            }
            else
            {
                errorProvider.SetError(InscripcionIdnumericUpDown, "No se puede elimina, porque no existe");
            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();
            if(AsignaturacomboBox.Text == "")
            {
                errorProvider.SetError(AsignaturacomboBox, "Debe elegir una asignatura");
                AsignaturacomboBox.Focus();

            }
            else
            {

            
                Asignaturas asignatura = db.Buscar((int)AsignaturacomboBox.SelectedValue);
                if (detalleDataGridView.DataSource != null)
                    this.Detalle = (List<InscripcionDetalle>)detalleDataGridView.DataSource;

                this.Detalle.Add(new InscripcionDetalle()
                {
                    InscripcionId = (int)InscripcionIdnumericUpDown.Value,
                    AsignaturaId = (int)AsignaturacomboBox.SelectedValue,
                    Id = 0,
                    SubTotal = (asignatura.Creditos * MontonumericUpDown.Value)
                });

                CargarGrid();
            }
           
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (detalleDataGridView.Rows.Count > 0 && detalleDataGridView.CurrentRow != null)
            {
                //remover la fila
                Detalle.RemoveAt(detalleDataGridView.CurrentRow.Index);
                CargarGrid();
            }
        }
    }
}
