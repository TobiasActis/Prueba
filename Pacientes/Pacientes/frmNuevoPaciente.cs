using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacientes
{
    public partial class frmNuevoPaciente : Form
    {
        public frmNuevoPaciente()
        {
            InitializeComponent();
            cmbSexo.ValueMember = "id";
            cmbSexo.DisplayMember = "descripcion";
            cmbSexo.DataSource = Sexo.BuscarTodo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool Correcto = true;
            DateTime FechaNac = new DateTime();
            int Dni = 0;
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("La nombre es obligatoria");
                Correcto = false;
            }
            if (txtApellido.Text.Trim() == "")
            {
                MessageBox.Show("El apellido es obligatorio");
                Correcto = false;
            }
            if (txtFechaNacimiento.Text.Trim() == "")
            {
                MessageBox.Show("La Fecha Nacimiento es obligatoria");
                Correcto = false;
            }
            else
            {
                if (!DateTime.TryParse(txtFechaNacimiento.Text, out FechaNac))
                {
                    MessageBox.Show("La Fecha Nacimiento no es válida");
                    Correcto = false;
                }
            }

            if (txtDni.Text.Trim() == "")
            {
                MessageBox.Show("El DNI es obligatorio");
                Correcto = false;
            }
            else
            {
                if (!int.TryParse(txtDni.Text, out Dni))
                {
                    MessageBox.Show("El Dni no es válido");
                    Correcto = false;
                }
            }

            if (Correcto)
            {
                Paciente paciente = new Paciente(txtApellido.Text.Trim(), txtNombre.Text.Trim(), FechaNac, Convert.ToInt32(cmbSexo.SelectedValue), Dni);
                if (paciente.Nuevo())
                {
                    MessageBox.Show("Guardado Correctamente");
                    Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
