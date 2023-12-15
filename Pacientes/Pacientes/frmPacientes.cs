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
    public partial class frmPacientes : Form
    {
        public frmPacientes()
        {
            InitializeComponent();
        }
        private void frmPacientes_Load(object sender, EventArgs e)
        {
            cmbSexo.ValueMember = "id";
            cmbSexo.DisplayMember = "descripcion";
            cmbSexo.DataSource = Sexo.BuscarTodo();

        }
        private void LlenarGrilla(DataTable datos)
        {
            dgvPacientes.DataSource = null;
            dgvPacientes.DataSource = datos;
        }

        private void btnBuscarPorId_Click(object sender, EventArgs e)
        {
            int codigoBuscado;
            if (!int.TryParse(txtId.Text, out codigoBuscado))
            {
                MessageBox.Show("El código no es válido");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = Paciente.BuscarPorId(codigoBuscado);
                LlenarGrilla(dt);
            }
        }

        private void btnBuscarPorNombre_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Paciente.BuscarPorNombre(txtNombre.Text);
            LlenarGrilla(dt);
        }

        private void btnBuscarPorApellido_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Paciente.BuscarPorApellido(txtApellido.Text);
            LlenarGrilla(dt);
        }

        private void btnBuscarPorSexo_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Paciente.BuscarPorSexo(Convert.ToInt32(cmbSexo.SelectedValue));
            LlenarGrilla(dt);
        }
        private void btnBuscarPorDni_Click(object sender, EventArgs e)
        {
            int codigoBuscado;
            if (!int.TryParse(txtDni.Text, out codigoBuscado))
            {
                MessageBox.Show("El DNI no es válido");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = Paciente.BuscarPorDni(txtDni.Text);
                LlenarGrilla(dt);
            }
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Paciente.BuscarTodo();
            LlenarGrilla(dt);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoPaciente form = new frmNuevoPaciente();
            form.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count > 0)
            {
                int id;
                id = Convert.ToInt32(dgvPacientes.CurrentRow.Cells[0].Value);

                DialogResult Borra = MessageBox.Show("Está seguro que desea eliminar el paciente?", "Advertencia", MessageBoxButtons.YesNo);
                if (Borra == DialogResult.Yes)
                {
                    Paciente.Eliminar(id);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un paciente");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count > 0)
            {
                int id;
                id = Convert.ToInt32(dgvPacientes.CurrentRow.Cells[0].Value);
                frmModificarPaciente form = new frmModificarPaciente(id);
                form.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un paciente");
            }
        }

    }
}
