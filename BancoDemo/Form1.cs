using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BancoDemo
{
    public partial class frmDatos : Form
    {
        Clases.Conexion conexion = new Clases.Conexion();
        static Clases.Articulo articuloSeleccionado { get; set;}
        public frmDatos()
        {
            InitializeComponent();
        }

        private void frmDatos_Load(object sender, EventArgs e)
        {
            try
            {
                if (conexion.abrirConexion() == true)
                {
                    listarArticulos(conexion.conexion, txtNombre.Text, txtDescripcion.Text);
                    conexion.cerrarConexion();
                }

            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public void listarArticulos(MySqlConnection conexion,string pnombre, string pdescripcion)
        {
            dgvArticulos.DataSource = Clases.Articulo.Buscar(conexion, pnombre, pdescripcion);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexion.abrirConexion() == true)
                {
                    Clases.Articulo pArticulo = new Clases.Articulo();
                    pArticulo.idcategoria =int.Parse(txtIdCategoria.Text);
                    pArticulo.codigo = txtCodigo.Text;
                    pArticulo.nombre = txtNombre.Text;
                    pArticulo.stock = int.Parse(txtStock.Text);
                    pArticulo.descripcion = txtDescripcion.Text;
                    pArticulo.imagen = txtImagen.Text;
                    pArticulo.condicion = int.Parse(txtCondicion.Text);

                    int resultado;
                    resultado = Clases.Articulo.agregarArticulo(conexion.conexion, pArticulo);
                    if (resultado > 0)
                    {
                        txtCodigo.Clear();
                        txtCondicion.Clear();
                        txtDescripcion.Clear();
                        txtIdArticulo.Clear();
                        txtIdCategoria.Clear();
                        txtImagen.Clear();
                        txtNombre.Clear();
                        txtStock.Clear();
                        listarArticulos(conexion.conexion, txtNombre.Text, txtDescripcion.Text);                    
                    }

                    conexion.cerrarConexion();
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexion.abrirConexion() == true)
                {
                    listarArticulos(conexion.conexion, txtNombre.Text, txtDescripcion.Text);
                    conexion.cerrarConexion();
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.SelectedRows.Count == 1)
                {
                    int idArticulo = Convert.ToInt32(dgvArticulos.CurrentRow.Cells[0].Value);
                    //con la llave recogida voy a la base de datos
                    if (conexion.abrirConexion() == true)
                    {
                        articuloSeleccionado = Clases.Articulo.obtenerArticulo(conexion.conexion, idArticulo);
                        txtIdArticulo.Text = articuloSeleccionado.idarticulo.ToString();
                        txtIdCategoria.Text = articuloSeleccionado.idcategoria.ToString();
                        txtCodigo.Text = articuloSeleccionado.codigo;
                        txtNombre.Text = articuloSeleccionado.nombre;
                        txtStock.Text = articuloSeleccionado.stock.ToString();
                        txtDescripcion.Text = articuloSeleccionado.descripcion;
                        txtImagen.Text = articuloSeleccionado.imagen;
                        txtCondicion.Text = articuloSeleccionado.condicion.ToString();
                    }

                    if (conexion.cerrarConexion() == true)
                    {

                    }
                }

                else
                {
                    MessageBox.Show("Debe seleccionar un registro.");
                }
            }
            catch
            {

            }
        }

       
    }
}
