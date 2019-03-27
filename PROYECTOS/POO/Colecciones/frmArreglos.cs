using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.Colecciones
{
    public partial class frmArreglos : Form
    {
        //Definicion de variables publicas
        Clases.Producto[] productos = new Clases.Producto[5];
        int contador = 0;
        public frmArreglos()
        {
            InitializeComponent();
        }

        private void frmArreglos_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        public void LimpiarDatos() {
            Util.Globales.Limpiar(this);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Clases.Producto producto = new Clases.Producto();
            producto.Codigo = Convert.ToInt32(txtCodigo.Text);
            producto.Nombre = txtNombre.Text;
            producto.Precio = Convert.ToDecimal(txtPrecio.Text);
            producto.IGV = producto.ObtenerIGV();
            producto.PrecioVenta = producto.ObtenerPrecioVenta();
            productos[contador] = producto;
            txtIGV.Text = Convert.ToString(producto.IGV);
            txtPrecioVenta.Text = Convert.ToString(producto.PrecioVenta);
            contador++;
            DGVProductos.DataSource = null;
            DGVProductos.DataSource = productos;
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.Globales.PermiteNumeros(e.KeyChar);
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            foreach (Clases.Producto pro in productos)
            {
                if (pro.Codigo == Convert.ToInt32(txtCodigo.Text))
                {
                    txtNombre.Text = pro.Nombre;
                    txtPrecio.Text = Convert.ToString(pro.Precio);
                    txtIGV.Text = Convert.ToString(pro.IGV);
                    txtPrecioVenta.Text = Convert.ToString(pro.PrecioVenta);

                    return;

                }
            }
                MessageBox.Show("No existe el producto con el codigo" + txtCodigo.Text, 
                    " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
