using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes
{
    class BaseDatos
    {
        static SqlConnection conn = new SqlConnection();

        static private bool Conectar()
        {
            try
            {
                conn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=EjPacientes;Integrated Security=True";
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static private void Desconectar()
        {
            conn.Close();
        }

        static public DataTable Buscar(string CadenaSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                SqlDataAdapter da = new SqlDataAdapter(CadenaSQL, conn);
                da.Fill(dt);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }

        static public bool EjecutarConsulta(string CadenaSQL)
        {
            bool Correcto;
            try
            {
                Conectar();
                SqlDataAdapter da = new SqlDataAdapter(CadenaSQL, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Correcto = true;
            }
            catch (Exception)
            {
                Correcto = false;
            }
            finally
            {
                Desconectar();
            }
            return Correcto;
        }
    }
}
