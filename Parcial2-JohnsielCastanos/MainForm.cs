using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial2_JohnsielCastanos.UI.Registro;

namespace Parcial2_JohnsielCastanos
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AsignaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rAsignaturas frm = new rAsignaturas();
            frm.Show();
            
        }

        private void EstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEstudiantes frm = new rEstudiantes();
            frm.Show();
        }
    }
}
