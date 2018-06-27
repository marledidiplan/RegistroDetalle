using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroArticulosP.BLL;
using RegistroArticulosP.UI.Registro;
using RegistroArticulosP.DALL;
using System.Data.Entity;
using RegistroArticulosP.Entidades;

namespace RegistroArticulosP.UI.Registro
{
    public partial class RegistroPersona : Form
    {
        public RegistroPersona()
        {
            InitializeComponent();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            Persona persona = LlenaClase();

            bool paso = false;
            if (!Validar())
            {
                if (IdnumericUpDown.Value == 0)

                    paso = BLL.PersonaBLL.Guardar(persona);


                else
                    paso = BLL.PersonaBLL.Modificar(LlenaClase());

                if (paso)
                    MessageBox.Show("Guardado", "Con Exito!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo Guardar", "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Persona LlenaClase()
        {
            Persona persona = new Persona();
            persona.Nombre = NombretextBox.Text;
            persona.Fecha = FechadateTimePicker.Value;
            persona.Direccion = DirecciontextBox.Text;
            persona.Cedula = CedulamaskedTextBox.Text;
            persona.Telefono = TelefonomaskedTextBox.Text;

            return persona;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Clear();
            FechadateTimePicker.Value = DateTime.Now;
            CedulamaskedTextBox.Clear();
            DirecciontextBox.Clear();
            TelefonomaskedTextBox.Clear();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
           int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.PersonaBLL.Eliminar(id))
                MessageBox.Show("ELiminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public  bool Validar()
        {
            bool HayErrores = false;
            if(String.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider.SetError(NombretextBox, "Nombre Vacio");
                HayErrores = true;
            }
            if(String.IsNullOrWhiteSpace(CedulamaskedTextBox.Text))
            {
                errorProvider.SetError(CedulamaskedTextBox, "Cedula Vacia");
                HayErrores = true;
            }
            if(String.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text))
            {
                errorProvider.SetError(TelefonomaskedTextBox, "Telefono Vacio ");
                HayErrores = true;
            }
            if(String.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                errorProvider.SetError(DirecciontextBox, "Direccion Vacia");
                HayErrores = true;

            }
            return HayErrores;
        }

        public void LlenarCampo(Persona persona)
        {
            IdnumericUpDown.Value = persona.PersonaId;
            NombretextBox.Text = persona.Nombre;
            DirecciontextBox.Text = persona.Direccion;
            TelefonomaskedTextBox.Text = persona.Telefono;
            FechadateTimePicker.Value = persona.Fecha;
            CedulamaskedTextBox.Text = persona.Cedula;

        }
        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            LlenarCampo(BLL.PersonaBLL.Buscar(id));
        }
    }
}
