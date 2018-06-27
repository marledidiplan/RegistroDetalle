using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroArticulosP.Entidades;
using RegistroArticulosP.BLL;
using System.Linq.Expressions;

namespace RegistroArticulosP.UI.Consulta
{
    public partial class ConsultaPersona : Form
    {
        public ConsultaPersona()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Persona, bool>> filtro = p => true;
            int id;
            switch (FiltrarcomboBox.SelectedIndex)
            {
                case 0://Id
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = p => p.PersonaId == id;
                    break;
                case 1://Fecha
                    filtro = p => p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value;
                    break;
                case 2: //Nombre
                    filtro = p => p.Nombre.Contains(CriteriotextBox.Text) && p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value;
                    break;
                case 3:// Direccion 
                    filtro = p => p.Direccion.Contains(CriteriotextBox.Text) && p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value;
                    break;
                case 4:// Cedula
                    filtro = p => p.Cedula.Equals(CriteriotextBox.Text) && p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value;
                    break;
                case 5:// Telefono 
                    filtro = p => p.Telefono.Equals(CriteriotextBox.Text) && p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value;
                    break;
            }
            ConsultadataGridView.DataSource = BLL.PersonaBLL.GetList(filtro);

        }

        private void ConsultaPersona_Load(object sender, EventArgs e)
        {

        }
    }
}
