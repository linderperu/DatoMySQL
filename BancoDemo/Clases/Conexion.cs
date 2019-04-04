using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BancoDemo.Clases
{
    public class Conexion
    {
        public MySqlConnection conexion;

        public Conexion()
        {
            conexion = new MySqlConnection("server=127.0.0.1;port=3306;database=dbsistema;uid=root;pwd=;");
        }
        public bool abrirConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                return false;
                //que devuelva ese mensaje
                throw (ex);
            }
        }
        public bool cerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                //que devuelva ese mensaje
                throw (ex);
            }
        }
    }
}
