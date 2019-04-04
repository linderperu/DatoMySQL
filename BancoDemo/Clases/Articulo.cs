using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agregamos esta referencia
using MySql.Data.MySqlClient;

namespace BancoDemo.Clases
{
    class Articulo
    {
        public int idarticulo { get; set; }
        public int idcategoria { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public int condicion { get; set; }

        public Articulo()
        {

        }
        public Articulo(int pidarticulo, int pidcategoria, string pcodigo, string pnombre, int pstock, string pdescripcion, string pimagen, int pcondicion)
        {
            this.idarticulo = pidarticulo;
            this.idcategoria = pidcategoria;
            this.codigo = pcodigo;
            this.nombre = pnombre;
            this.stock = pstock;
            this.descripcion = pdescripcion;
            this.imagen = pimagen;
            this.condicion = pcondicion;
        }
        public static int agregarArticulo(MySqlConnection conexion, Articulo pArticulo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO articulo (idcategoria,codigo,nombre,stock,descripcion,imagen,condicion) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", pArticulo.idcategoria, pArticulo.codigo, pArticulo.nombre, pArticulo.stock, pArticulo.descripcion, pArticulo.imagen, pArticulo.condicion), conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }
        //public static int actualizarArticulo()
        //{

        //}
        //public static int eliminarArticulo()
        //{

        //}
        public static IList<Articulo> Buscar(MySqlConnection conexion, string pnombre, string pdescripcion)
        {
            IList<Articulo> lista = new List<Articulo>();
            MySqlCommand comando = new MySqlCommand(string.Format("SELECT idarticulo,idcategoria,codigo,nombre,stock,descripcion,imagen,condicion FROM articulo where nombre LIKE('%{0}%') AND descripcion LIKE('%{1}%')",pnombre,pdescripcion),conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Articulo particulo = new Articulo();
                particulo.idarticulo = reader.GetInt32(0);
                particulo.idcategoria = reader.GetInt32(1);
                particulo.codigo=reader.GetString(2);
                particulo.nombre = reader.GetString(3);
                particulo.stock = reader.GetInt32(4);
                particulo.descripcion = reader.GetString(5);
                particulo.imagen = reader.GetString(6);
                particulo.condicion = reader.GetInt32(7);
                lista.Add(particulo);
            }
            return lista;
        }
        public static Articulo obtenerArticulo(MySqlConnection conexion, int pidArticulo)
        {
            Articulo particulo = new Articulo();
            MySqlCommand comando = new MySqlCommand(string.Format("SELECT idarticulo,idcategoria,codigo,nombre,stock,descripcion,imagen,condicion FROM articulo where idarticulo LIKE('{0}')", pidArticulo), conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                particulo.idarticulo = reader.GetInt32(0);
                particulo.idcategoria = reader.GetInt32(1);
                particulo.codigo = reader.GetString(2);
                particulo.nombre = reader.GetString(3);
                particulo.stock = reader.GetInt32(4);
                particulo.descripcion = reader.GetString(5);
                particulo.imagen = reader.GetString(6);
                particulo.condicion = reader.GetInt32(7);
                
            }
            return particulo;
        }



    }
}
