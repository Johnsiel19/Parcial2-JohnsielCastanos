using System;
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
    public partial class cAsignaturas : Form
    {
        public cAsignaturas()
        {
            InitializeComponent();
            FiltrocomboBox.Text = "Todo";
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Asignaturas>();
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.Text)
                {
                    case "Todo":
                        listado = db.GetList(p => true);
                        break;

                    case "Id":
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(p => p.AsignaturaId == id);
                        break;

                    case "Descripcion":
                        listado = db.GetList(p => p.Descripcion.Contains(CriteriotextBox.Text));
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
    }
}
