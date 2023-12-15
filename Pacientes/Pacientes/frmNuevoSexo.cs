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
    public partial class frmNuevoSexo : Form
    {
        public frmNuevoSexo()
        {
            InitializeComponent();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool Correcto = true;
            if (txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("La descripción es obligatoria");
                Correcto = false;
            }
            if (Correcto)
            {
                Sexo sexo = new Sexo(txtDescripcion.Text.Trim());
                if (sexo.Nuevo())
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
