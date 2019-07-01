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
    public partial class cEstudiantes : Form
    {
        public cEstudiantes()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {

            var listado = new List<Estudiantes>();
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            if (FiltroFecha.Checked == true)
            {
                try
                {


                    if (CriteriotextBox.Text.Trim().Length > 0)
                    {
                        switch (FiltrocomboBox.Text)
                        {
                            case "Todo":
                                listado = db.GetList(p => true);
                                break;

                            case "Id":
                                int id = Convert.ToInt32(CriteriotextBox.Text);
                                listado = db.GetList(p => p.EstudianteId == id);
                                break;

                            case "Nombre":
                                listado = db.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                                break;


                            case "Balance":
                                double mont = Convert.ToInt32(CriteriotextBox.Text);
                                listado = db.GetList(p => p.Balance == mont);
                                break;

                            default:
                                break;
                        }
                        listado = listado.Where(c => c.FechaIngreso.Date >= DesdedateTimePicker.Value.Date && c.FechaIngreso.Date <= HastadateTimePicker.Value.Date).ToList();
                    }
                    else
                    {
                        listado = db.GetList(p => true);
                    }

                    ConsultadataGridView.DataSource = null;
                    ConsultadataGridView.DataSource = listado;

                }
                catch (Exception)
                {
                    MessageBox.Show("Introdujo un dato incorrecto");

                }


            }
            else
            {
                try
                {

                    if (CriteriotextBox.Text.Trim().Length > 0)
                    {
                        switch (FiltrocomboBox.Text)
                        {
                            case "Todo":
                                listado = db.GetList(p => true);
                                break;

                            case "Id":
                                int id = Convert.ToInt32(CriteriotextBox.Text);
                                listado = db.GetList(p => p.EstudianteId == id);
                                break;

                            case "Nombre":
                                listado = db.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                                break;


                            case "Balance":
                                double mont = Convert.ToInt32(CriteriotextBox.Text);
                                listado = db.GetList(p => p.Balance == mont);
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        listado = db.GetList(p => true);
                    }

                    ConsultadataGridView.DataSource = null;
                    ConsultadataGridView.DataSource = listado;

                }
                catch (Exception)
                {
                    MessageBox.Show("Introdujo un dato incorrecto");

                }

            }


        }
    }
    
}
