using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class AccesoDatos
    {
        string rutaBD = @"Data Source=localhost\sqlexpress;Initial Catalog=VentaGamer;Integrated Security=True";
        public AccesoDatos() { }

        public SqlConnection obtenerConexion()
        {
            SqlConnection con = new SqlConnection(rutaBD);

            try
            {
                con.Open();
                return con;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public SqlDataAdapter obtenerAdaptador(string consultaSql, SqlConnection con)
        {
            SqlDataAdapter adaptador;

            try
            {
                adaptador = new SqlDataAdapter(consultaSql, con);
                return adaptador;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int ejecutarProcedimientoAlmacenado(SqlCommand comando, string nombre)
        {
            SqlConnection con = obtenerConexion();
            comando.Connection = con;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombre;
            int filasAfectadas = comando.ExecuteNonQuery();
            con.Close();

            return filasAfectadas;
        }

        public DataTable obtenerTabla(string tabla, string consultaSql)
        {
            DataSet ds = new DataSet();
            SqlConnection con = obtenerConexion();

            try
            {
                SqlDataAdapter adaptador = obtenerAdaptador(consultaSql, con);
                adaptador.Fill(ds, tabla);
                con.Close();
                
                return ds.Tables[tabla];
            }
            catch (Exception)
            {
                return null;
            } 
        }

        public int ejecutarTransaccion(string consulta)
        {
            SqlConnection con = obtenerConexion();
            SqlCommand comando = new SqlCommand(consulta, con);

            int filasAfectadas = comando.ExecuteNonQuery();
            con.Close();

            return filasAfectadas;
        }
    }
}
