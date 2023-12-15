using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes
{
    class Sexo
    {
        #region Campos
        private int id;
        private string descripcion;
        #endregion

        #region Propiedades
        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string Descripcion
        {
            set
            {
                descripcion = value;
            }
            get
            {
                return descripcion;
            }
        }
        #endregion

        #region Constructor
        public Sexo(string pDescripcion)
        {
            Descripcion = pDescripcion;
        }

        public Sexo()
        {

        }
        #endregion

        #region Métodos
        public bool Nuevo()
        {
            bool Correcto;
            string Consulta = "INSERT INTO sexos (descripcion) values ('" + Descripcion + "')";
            Correcto = BaseDatos.EjecutarConsulta(Consulta);
            return Correcto;
        }

        public bool Modificar()
        {
            bool Correcto;
            string Consulta = "UPDATE sexos SET descripcion='" + Descripcion + "' WHERE id =" + Id + "";
            Correcto = BaseDatos.EjecutarConsulta(Consulta);
            return Correcto;
        }
        static public bool Eliminar(int idSeleccionado)
        {
            bool Correcto;
            string Consulta = "DELETE FROM sexos WHERE id='" + idSeleccionado + "'";
            Correcto = BaseDatos.EjecutarConsulta(Consulta);
            return Correcto;
        }
        static public DataTable BuscarTodo()
        {
            DataTable dt = new DataTable();
            string Consulta = "SELECT * FROM sexos";
            dt = BaseDatos.Buscar(Consulta);
            return dt;
        }
        static public DataTable BuscarPorId(int IdBuscado)
        {
            DataTable dt = new DataTable();
            string Consulta = "SELECT * FROM sexos WHERE id = " + IdBuscado + "";
            dt = BaseDatos.Buscar(Consulta);
            return dt;
        }
        static public DataTable BuscarPorDescripcion(string DescripcionBuscada)
        {
            DataTable dt = new DataTable();
            string Consulta = "SELECT * FROM sexos WHERE descripcion LIKE '%" + DescripcionBuscada + "%'";
            dt = BaseDatos.Buscar(Consulta);
            return dt;
        }
        #endregion
    }
}