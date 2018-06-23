using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroArticulosP.Entidades;
using RegistroArticulosP.UI.Registro;
using RegistroArticulosP.UI.Consulta;

namespace RegistroArticulosP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void registroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistroArticulos ra = new RegistroArticulos();
            ra.MdiParent = this;
            ra.Show();
        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroPersona rp = new RegistroPersona();
            rp.MdiParent = this;
            rp.Show();
        }

        private void cotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroCotizacion rc = new RegistroCotizacion();
            rc.MdiParent = this;
            rc.Show();
        }
    }
}
