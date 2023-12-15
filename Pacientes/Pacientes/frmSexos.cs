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
    public partial class frmSexos : Form
    {
        public frmSexos()
        {
            InitializeComponent();
        }
        private void LlenarGrilla(DataTable datos)
        {
            dgvSexos.DataSource = null;
            dgvSexos.DataSource = datos;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoSexo form = new frmNuevoSexo();
            form.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvSexos.SelectedRows.Count > 0)
            {
                int id;
                id = Convert.ToInt32(dgvSexos.CurrentRow.Cells[0].Value);
                frmModificarSexo form = new frmModificarSexo(id);
                form.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un sexo");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSexos.SelectedRows.Count > 0)
            {
                int id;
                id = Convert.ToInt32(dgvSexos.CurrentRow.Cells[0].Value);

                DialogResult Borra = MessageBox.Show("Está seguro que desea eliminar el sexo?", "Advertencia", MessageBoxButtons.YesNo);
                if (Borra == DialogResult.Yes)
                {
                    Sexo.Eliminar(id);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un sexo");
            }
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
                dt = Sexo.BuscarPorId(codigoBuscado);
                LlenarGrilla(dt);
            }
        }

        private void btnBuscarPorDescripcion_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Sexo.BuscarPorDescripcion(txtDescripcion.Text);
            LlenarGrilla(dt);
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Sexo.BuscarTodo();
            LlenarGrilla(dt);
        }

        
    }
}
