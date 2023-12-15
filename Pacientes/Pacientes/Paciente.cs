using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes
{
    class Paciente
    {
        #region Campos
        private int id;
        private string apellido;
        private string nombre;
        private DateTime fechaNacimiento;
        private int idSexo;
        private int dni;
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
        public string Apellido
        {
            set
            {
                apellido = value;
            }
            get
            {
                return apellido;
            }
        }
        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }
        public DateTime FechaNacimiento
        {
            set
            {
                fechaNacimiento = value;
            }
            get
            {
                return fechaNacimiento;
            }
        }

        public int IdSexo
        {
            set
            {
                idSexo = value;
            }
            get
            {
                return idSexo;
            }
        }
        public int Dni
        {
            set
            {
                dni = value;
            }
            get
            {
                return dni;
            }
        }
        #endregion

        #region Constructor
        public Paciente(string pApellido, string pNombre, DateTime pFechaNacimiento, int pIdSexo, int pDni)
        {
            Apellido = pApellido;
            Nombre = pNombre;
            FechaNacimiento = pFechaNacimiento;
            IdSexo = pIdSexo;
            Dni = pDni;
        }

        public Paciente()
        {

        }
        #endregion

        #region Métodos
        public bool Nuevo()
        {
            bool Correcto;
            string Consulta = "INSERT INTO pacientes (apellido, nombre, fechanacimiento, idSexo, dni) " +
                "values ('" + Apellido + "', '" + Nombre + "', '" + fechaNacimiento + "', " + idSexo + ", " + Dni + ")";
            Correcto = BaseDatos.EjecutarConsulta(Consulta);
            return Correcto;
        }
        public bool Modificar()
        {
            bool Correcto;
            string Consulta = "UPDATE pacientes SET apellido='" + Apellido + "', nombre = '" + Nombre + "', fechanacimiento = '" + FechaNacimiento
            + "', idSexo = " + idSexo + ", dni = " + Dni + " WHERE id =" + Id + "";
            Correcto = BaseDatos.EjecutarConsulta(Consulta);
            return Correcto;
        }
        static public bool Eliminar(int idSeleccionado)
        {
            bool Correcto;
            string Consulta = "DELETE FROM pacientes WHERE id='" + idSeleccionado + "'";
            Correcto = BaseDatos.EjecutarConsulta(Consulta);
            return Correcto;
        }
        static public DataTable BuscarTodo()
        {
            DataTable dt = new DataTable();
            string Consulta = "SELECT " +
                "pacientes.id as Id, " +
                "pacientes.apellido as Apellido, " +
                "pacientes.nombre as Nombre, " +
                "pacientes.fechanacimiento as FechaNacimiento, " +
                "sexos.descripcion as Sexo, " +
                "pacientes.dni as dni " +
                "FROM pacientes " +
                "INNER JOIN sexos ON sexos.id = pacientes.idSexo";
            dt = BaseDatos.Buscar(Consulta);
            return dt;
        }
        static public DataTable BuscarPorId(int IdBuscado)
        {
            DataTable dt = new DataTable();
            string Consulta = "SELECT " +
                "pacientes.id as Id, " +
                "pacientes.apellido as Apellido, " +
                "pacientes.nombre as Nombre, " +
                "pacientes.fechanacimiento as FechaNacimiento, " +
                "pacientes.idSexo as IdSexo, " +
                "pacientes.dni as dni " +
                "FROM pacientes " +
                "WHERE pacientes.id = " + IdBuscado + "";
            dt = BaseDatos.Buscar(Consulta);
            return dt;
        }

        static public DataTable BuscarPorApellido(string ApellidoBuscado)
        {
            DataTable dt = new DataTable();
            string Consulta = "SELECT " +
                "pacientes.id as Id, " +
                "pacientes.apellido as Apellido, " +
                "pacientes.nombre as Nombre, " +
                "pacientes.fechanacimiento as FechaNacimiento, " +
                "pacientes.idSexo as IdSexo, " +
                "pacientes.dni as dni " +
                "FROM pacientes " +
                "WHERE pacientes.apellido LIKE '%" + ApellidoBuscado + "%'";
            dt = BaseDatos.Buscar(Consulta);
            return dt;
        }

        static public DataTable BuscarPorNombre(string NombreBuscado)
        {
            DataTable dt = new DataTable();
            string Consulta = "SELECT " +
                "pacientes.id as Id, " +
                "pacientes.apellido as Apellido, " +
                "pacientes.nombre as Nombre, " +
                "pacientes.fechanacimiento as FechaNacimiento, " +
                "pacientes.idSexo as IdSexo, " +
                "pacientes.dni as dni " +
                "FROM pacientes " +
                "WHERE pacientes.nombre LIKE '%" + NombreBuscado + "%'";
            dt = BaseDatos.Buscar(Consulta);
            return dt;
        }

        static public DataTable BuscarPorDni(string DniBuscado)
        {
            DataTable dt = new DataTable();
            string Consulta = "SELECT " +
                "pacientes.id as Id, " +
                "pacientes.apellido as Apellido, " +
                "pacientes.nombre as Nombre, " +
                "pacientes.fechanacimiento as FechaNacimiento, " +
                "pacientes.idSexo as IdSexo, " +
                "pacientes.dni as dni " +
                "FROM pacientes " +
                "WHERE pacientes.dni =" + DniBuscado + "";
            dt = BaseDatos.Buscar(Consulta);
            return dt;
        }
        static public DataTable BuscarPorSexo(int IdSexo)
        {
            DataTable dt = new DataTable();
            string Consulta = "SELECT " +
                "pacientes.id as Id, " +
                "pacientes.apellido as Apellido, " +
                "pacientes.nombre as Nombre, " +
                "pacientes.fechanacimiento as FechaNacimiento, " +
                "pacientes.idSexo as IdSexo, " +
                "pacientes.dni as dni " +
                "FROM pacientes " +
                "WHERE pacientes.idSexo = " + IdSexo;
            dt = BaseDatos.Buscar(Consulta);
            return dt;
        }

        #endregion
    }
}