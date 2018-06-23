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

namespace RegistroArticulosP.UI.Registro
{
    public partial class RegistroArticulos : Form
    {
        public RegistroArticulos()
        {
            InitializeComponent();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            ArticulosProductos articulosProducto = new ArticulosProductos();
            bool paso = false;
            if (!Validar())
            {
                if (IdnumericUpDown.Value == 0)

                    paso = BLL.ArticulosBLL.Guardar(articulosProducto);


                else
                    paso = BLL.ArticulosBLL.Modificar(LlenaClase());

                if (paso)
                    MessageBox.Show("Guardado", "Con Exito!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo Guardar", "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private ArticulosProductos LlenaClase()
        {
            ArticulosProductos articulosProducto = new ArticulosProductos();

            articulosProducto.IdArticulos = Convert.ToInt32(IdnumericUpDown.Value);
            articulosProducto.FechaVencimiento = FechaVencimientodateTimePicker.Value;
            articulosProducto.Descripcion = DescripciontextBox.Text;
            articulosProducto.Precio = Convert.ToInt32(PreciotextBox.Text);
            articulosProducto.Existencia = Convert.ToInt32(ExistenciatextBox.Text);
            articulosProducto.CantidadCotizada = Convert.ToInt32(CantidadCotizadatextBox.Text);
            return articulosProducto;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechaVencimientodateTimePicker.Value = DateTime.Now;
            DescripciontextBox.Clear();
            PreciotextBox.Clear();
            ExistenciatextBox.Clear();
            CantidadCotizadatextBox.Clear();

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado!", "Con Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Eliminar", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            ArticulosProductos articulosProducto = BLL.ArticulosBLL.Buscar(id);
            if (articulosProducto != null)
            {
                DescripciontextBox.Text = articulosProducto.Descripcion;
                PreciotextBox.Text = articulosProducto.Precio.ToString();
                FechaVencimientodateTimePicker.Value = articulosProducto.FechaVencimiento;
                ExistenciatextBox.Text = articulosProducto.Existencia.ToString();
                CantidadCotizadatextBox.Text = articulosProducto.CantidadCotizada.ToString();

            }
        }
        public bool Validar()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                errorProvider.SetError(DescripciontextBox, "Descripcion Vacio");
                HayErrores = true;
            }
            if (PreciotextBox.Text == String.Empty)
            {
                errorProvider.SetError(PreciotextBox, "Precio Vacio");
                HayErrores = true;
            }
            if (ExistenciatextBox.Text == String.Empty)
            {
                errorProvider.SetError(ExistenciatextBox, "Existencia Vacia");
                HayErrores = true;
            }
            if (CantidadCotizadatextBox.Text == String.Empty)
            {
                errorProvider.SetError(CantidadCotizadatextBox, "Cantidad Cotizada Vacia");
                HayErrores = true;
            }
            return HayErrores;
        }

        private void RegistroArticulos_Load(object sender, EventArgs e)
        {

        }
    }

}
