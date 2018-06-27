using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using RegistroArticulosP.BLL;
using RegistroArticulosP.Entidades;
using RegistroArticulosP.DALL;
namespace RegistroArticulosP.UI.Registro
{
    public partial class RegristroCotizacion : Form
    {
        public RegristroCotizacion()
        {
            InitializeComponent();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Cotizacion cotizacion = LlenaClase();
            bool Paso = false;

            if (Errores())
            {
                MessageBox.Show("Revisar todos los campos", "Validadon",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            //Determinar si es Guardar o Modificar
            if (IdnumericUpDown.Value == 0)
                Paso = BLL.CotizacionBLL.Guardar(cotizacion);
            else
                
                Paso = BLL.CotizacionBLL.Modificar(LlenaClase());

            if (Paso)
            {
                Nuevobutton.PerformClick();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            CantidadtextBox.Clear();
            PreciotextBox.Clear();
            ImportetextBox.Clear();
            TotaltextBox.Clear();
            ObservacionestextBox.Clear();

            dataGridView.DataSource = null;
            errorProvider.Clear();
        }

        private Cotizacion LlenaClase()
        {
            Cotizacion cotizacion = new Cotizacion();

            cotizacion.IdCotizacion = Convert.ToInt32(IdnumericUpDown.Value);
            cotizacion.Fecha = FechadateTimePicker.Value;
            cotizacion.Comentarios= ObservacionestextBox.Text;

            //Agregar cada linea del Grid al detalle
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                cotizacion.AgregarDetalle(
                    ToInt(item.Cells["id"].Value),
                    ToInt(item.Cells["CotizacionId"].Value),
                    ToInt(item.Cells["PersonaId"].Value),
                    ToInt(item.Cells["ArticuloId"].Value),
                    ToInt(item.Cells["Cantidad"].Value),
                    ToInt(item.Cells["Precio"].Value),
                    ToInt(item.Cells["Importe"].Value)
                  );
            }
            return cotizacion;
        }


        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            if (BLL.CotizacionBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<CotizacionDetalle> detalle = new List<CotizacionDetalle>();

            if (dataGridView.DataSource != null)
            {
                detalle = (List<CotizacionDetalle>)dataGridView.DataSource;
            }
            detalle.Add(
                new CotizacionDetalle(
                    id: 0,
                    idCotizacion: (int)IdnumericUpDown.Value,
                   idPersona: (int)PersonacomboBox.SelectedValue,
                    idArticulos: (int)ArticuloscomboBox.SelectedValue,
                    cantidad: (int)Convert.ToInt32(CantidadtextBox.Text),
                    precio: (int)Convert.ToInt32(PreciotextBox.Text),
                    importe: (int)Convert.ToInt32(ImportetextBox.Text)

                ));
          dataGridView.DataSource = null;
          dataGridView.DataSource = detalle;
        }

        private bool Errores()
        {
            bool Errores = false;

            if (String.IsNullOrWhiteSpace(ObservacionestextBox.Text))
            {
                errorProvider.SetError(ObservacionestextBox, "No dejar el Comentario vacio");
                Errores = true;
            }

            if (String.IsNullOrWhiteSpace(CantidadtextBox.Text))
            {
                errorProvider.SetError(ObservacionestextBox, "No dejar Cantidad vacia");
                Errores = true;
            }

            if (String.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                errorProvider.SetError(PreciotextBox, "No dejar Precio vacio");
                Errores = true;
            }

            if (dataGridView.RowCount == 0)
            {
                errorProvider.SetError(dataGridView, "Seleccionar todos");
                Errores = true;
            }

            return Errores;
        }
        private void LlenarComboBox()
        {
            RepositorioBase<Persona> repository = new RepositorioBase<Persona>(new Contexto());
            RepositorioBase<ArticulosProductos> reposito = new RepositorioBase<ArticulosProductos>(new Contexto());
            PersonacomboBox.DataSource = repository.GetList(m => true);
            PersonacomboBox.ValueMember = "PersonaId";
            PersonacomboBox.DisplayMember = "Nombres";

            ArticuloscomboBox.DataSource = reposito.GetList(m => true);
            ArticuloscomboBox.ValueMember = "ArticuloId";
            ArticuloscomboBox.DisplayMember = "Descripcion";
        }
        private void LlenarCampos(Cotizacion cotizacion)
        {
            IdnumericUpDown.Value = cotizacion.IdCotizacion;
            FechadateTimePicker.Value = cotizacion.Fecha;
            ObservacionestextBox.Text = cotizacion.Comentarios;

           
            dataGridView.DataSource = cotizacion.Detalle;

            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["CotizacionId"].Visible = false;
        }


        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;
        }

        private void RegristroCotizacion_Load(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto(); 
            PersonacomboBox.ValueMember = "Id";
            PersonacomboBox.DisplayMember = "Nombre";
            PersonacomboBox.DataSource = contexto.personas.ToList();

           
        }
    }


}

