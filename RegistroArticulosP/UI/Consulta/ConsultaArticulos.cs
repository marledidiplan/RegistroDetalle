using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroArticulosP.Entidades;
using System.Linq.Expressions;
using RegistroArticulosP.UI.Consulta;
using RegistroArticulosP.BLL;
using System.ComponentModel.DataAnnotations;

namespace RegistroArticulosP.UI.Consulta
{
    public partial class ConsultaArticulos : Form
    {
        public ConsultaArticulos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en true

            Expression<Func<ArticulosProductos, bool>> Filtro = a => true;

            int id;
            switch (FiltrarcomboBox.SelectedIndex)
            {
                case 0:
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    Filtro = a => a.IdArticulos == id
                    && (a.FechaVencimiento <= DesdedateTimePicker.Value && a.FechaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 1:
                    Filtro = a => a.Descripcion.Equals(CriteriotextBox.Text)
                    && (a.FechaVencimiento <= DesdedateTimePicker.Value && a.FechaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 2:
                    Filtro = a => a.Precio.Equals(CriteriotextBox.Text)
                    && (a.FechaVencimiento <= DesdedateTimePicker.Value && a.FechaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 3:
                    Filtro = a => a.Existencia.Equals(CriteriotextBox.Text)
                    && (a.FechaVencimiento <= DesdedateTimePicker.Value && a.FechaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 4:
                    Filtro = a => a.CantidadCotizada.Equals(CriteriotextBox.Text)
                    && (a.FechaVencimiento <= DesdedateTimePicker.Value && a.FechaVencimiento <= HastadateTimePicker.Value);
                    break;
            }
        }
    }
}
