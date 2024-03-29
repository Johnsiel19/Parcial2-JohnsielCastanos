﻿using System;
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
    public partial class rEstudiantes : Form
    {
        public rEstudiantes()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            EstudianteIdnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            BalancetextBox.Text = string.Empty;
            errorProvider.Clear();

        }
        
        private Estudiantes LlenaClase()
        {
            Estudiantes estudiante = new Estudiantes();
            estudiante.EstudianteId = Convert.ToInt32(EstudianteIdnumericUpDown.Value);
            estudiante.Nombre = NombretextBox.Text.Trim();
            estudiante.FechaIngreso = FechaIngresodateTimePicker.Value;
            return estudiante;

        }

        private void LlenaCampo(Estudiantes estudiante)
        {
            EstudianteIdnumericUpDown.Value = estudiante.EstudianteId;
            NombretextBox.Text = estudiante.Nombre;
            FechaIngresodateTimePicker.Value = estudiante.FechaIngreso;
            BalancetextBox.Text = estudiante.Balance.ToString(); 
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider.SetError(NombretextBox, "Este campo no puede estar vacio");
                paso = false;
            }

            if (FechaIngresodateTimePicker.Value > DateTime.Now)
            {
                errorProvider.SetError(FechaIngresodateTimePicker, "La fecha no puede ser despues de hoy");
                FechaIngresodateTimePicker.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>(new DAL.Contexto());
            Estudiantes estudiante = db.Buscar((int)EstudianteIdnumericUpDown.Value);
            return (estudiante != null);

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>(new DAL.Contexto());
            Estudiantes estudiante;
            bool paso = false;

            if (!Validar())
                return;

            estudiante = LlenaClase();


            if (EstudianteIdnumericUpDown.Value == 0)
            {
                paso = db.Guardar(estudiante);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Estudiante que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(estudiante);

            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

      
        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            try
            {
                if (EstudianteIdnumericUpDown.Value > 0)
                {
                    if(Convert.ToUInt32( BalancetextBox.Text) > 0)
                    {

                        MessageBox.Show("NO se pudo eliminar porque tiene Balance pendiente", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        if (db.Eliminar((int)EstudianteIdnumericUpDown.Value))
                        {
                            MessageBox.Show("Eliminado", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se puede eliminar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }


                    }
                   

                }
            }
            catch (Exception)
            {
                MessageBox.Show("NO se pudo eliminar", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>(new DAL.Contexto());
            int id;
            Estudiantes estudiante = new Estudiantes();

            int.TryParse(EstudianteIdnumericUpDown.Text, out id);
            Limpiar();

            estudiante = db.Buscar(id);

            if (estudiante != null)
            {
                MessageBox.Show("Estudiante escontrado");
                LlenaCampo(estudiante);

            }
            else
            {
                MessageBox.Show("Estudiante  no existe");
            }
        }

        private void NombretextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
