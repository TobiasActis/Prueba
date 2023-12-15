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
    public partial class frmModificarSexo : Form
    {
        Sexo sexo = new Sexo();
        public frmModificarSexo(int IdSexo)
        {
            InitializeComponent();
            if (IdSexo > 0)
            {
                DataTable dt = new DataTable();
                dt = Sexo.BuscarPorId(IdSexo);
                if (dt.Rows.Count > 0)
                {
                    sexo.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    sexo.Descripcion = dt.Rows[0]["Descripcion"].ToString();

                    txtId.Text = sexo.Id.ToString();
                    txtDescripcion.Text = sexo.Descripcion;
                }
                else
                {
                    MessageBox.Show("No se encontró sexo con el código " + IdSexo);
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
            bool correcto = true;
            if (txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("La descripción es obligatoria");
                correcto = false;
            }

            if (correcto)
            {
                sexo.Descripcion = txtDescripcion.Text.Trim();

                if (sexo.Modificar())
                {
                    MessageBox.Show("Sexo guardado correctamente");
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