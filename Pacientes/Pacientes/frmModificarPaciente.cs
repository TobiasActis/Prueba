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
    public partial class frmModificarPaciente : Form
    {
        Paciente paciente = new Paciente();
        public frmModificarPaciente(int idPaciente)
        {
            InitializeComponent();
            cmbSexo.ValueMember = "id";
            cmbSexo.DisplayMember = "descripcion";
            cmbSexo.DataSource = Sexo.BuscarTodo();

            if (idPaciente > 0)
            {
                DataTable dt = new DataTable();
                dt = Paciente.BuscarPorId(idPaciente);
                if (dt.Rows.Count > 0)
                {
                    paciente.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    paciente.Nombre = dt.Rows[0]["Nombre"].ToString();
                    paciente.Apellido = dt.Rows[0]["apellido"].ToString();
                    paciente.FechaNacimiento = Convert.ToDateTime(dt.Rows[0]["fechaNacimiento"]);
                    paciente.IdSexo = Convert.ToInt32(dt.Rows[0]["IdSexo"]);
                    paciente.Dni = Convert.ToInt32(dt.Rows[0]["Dni"]);

                    txtId.Text = paciente.Id.ToString();
                    cmbSexo.SelectedValue = paciente.IdSexo;
                    txtNombre.Text = paciente.Nombre;
                    txtApellido.Text = paciente.Apellido;
                    txtFechaNacimiento.Text = paciente.FechaNacimiento.ToString("dd/MM/yyyy");
                    txtDni.Text = paciente.Dni.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró paciente con el código " + idPaciente);
                }
            }
            else
            {
                MessageBox.Show("El código no es válido");

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime FechaNac = new DateTime();
            int Dni = 0;
            bool correcto = true;
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("El Nombre es obligatorio");
                correcto = false;
            }

            if (txtApellido.Text.Trim() == "")
            {
                MessageBox.Show("El Apellido es obligatorio");
                correcto = false;
            }

            if (txtFechaNacimiento.Text.Trim() == "")
            {
                MessageBox.Show("La Fecha Nacimiento es obligatoria");
                correcto = false;
            }
            else
            {
                if (!DateTime.TryParse(txtFechaNacimiento.Text, out FechaNac))
                {
                    MessageBox.Show("La Fecha Nacimiento no es válida");
                    correcto = false;
                }
            }

            if (txtDni.Text.Trim() == "")
            {
                MessageBox.Show("El DNI es obligatorio");
                correcto = false;
            }
            else
            {
                if (!int.TryParse(txtDni.Text, out Dni))
                {
                    MessageBox.Show("El Dni no es válido");
                    correcto = false;
                }
            }

            if (correcto)
            {
                paciente.Nombre = txtNombre.Text.Trim();
                paciente.Apellido = txtApellido.Text.Trim();
                paciente.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                paciente.Dni = Dni;
                paciente.IdSexo = Convert.ToInt32(cmbSexo.SelectedValue);
                if (paciente.Modificar())
                {
                    MessageBox.Show("Paciente guardado correctamente");
                    Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al guardar");
                }
            }
        }
    }
}
