﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial2_JohnsielCastanos.DAL;
using Parcial2_JohnsielCastanos.BLL;
using Parcial2_JohnsielCastanos.Entidades;

namespace Parcial2_JohnsielCastanos.UI.Consultas
{
    public partial class cInscripciones : Form
    {
        public cInscripciones()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Inscripcion>();
            RepositorioBase<Inscripcion> db = new RepositorioBase<Inscripcion>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.Text)
                {
                    case "Todo":
                        listado = db.GetList(p => true);
                        break;

                    case "Id":
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(p => p.InscripcionId == id);
                        break;

                    case "Estudiante Id":
                        int est = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(p => p.EstudianteId == est);
                        break;
                       
                    case "Monto":
                        double mont = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(p => p.EstudianteId == mont);
                        break;

                    default:
                        break;
                }
                listado = listado.Where(c => c.FechaInscripcion.Date >= DesdedateTimePicker.Value.Date && c.FechaInscripcion.Date <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = db.GetList(p => true);
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
    }
}
