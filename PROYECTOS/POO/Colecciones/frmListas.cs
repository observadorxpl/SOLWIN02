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
    public partial class frmListas : Form
    {

        List<Clases.Producto> pro = new List<Clases.Producto>();
        public frmListas()
        {
            InitializeComponent();
        }

        private void frmListas_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Util.Globales.Limpiar(this);
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Agregar el producto?",
                "Grabar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Clases.Producto producto = new Clases.Producto();

                producto.Codigo = Convert.ToInt32(txtCodigo.Text);
                producto.Nombre = txtNombre.Text;
                producto.Precio = Convert.ToDecimal(txtPrecio.Text);
                producto.IGV = producto.ObtenerIGV();
                producto.PrecioVenta = producto.ObtenerPrecioVenta();
                txtIGV.Text = Convert.ToString(producto.IGV);
                txtPrecioVenta.Text = Convert.ToString(producto.PrecioVenta);
                pro.Add(producto);
                DGVProductos.DataSource = null;
                DGVProductos.DataSource = pro;
                MessageBox.Show("Registro almacenado con exito",
                    "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            var producto = pro.Where(p => p.Codigo == codigo).SingleOrDefault();

            if (producto != null)
            {
                if ((MessageBox.Show("¿Esta seguro?",
                    "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)){
                    pro.Remove(producto);
                    Util.Globales.Limpiar(this);
                    DGVProductos.DataSource = null;
                    DGVProductos.DataSource = pro;
                }
            }
            else
            {
                MessageBox.Show("No existe el producto",
                    "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            var producto = pro.Where(p => p.Codigo == codigo).SingleOrDefault();

            if (producto != null) {
                txtNombre.Text = producto.Nombre;
                txtPrecio.Text = Convert.ToString(producto.Precio);
                txtIGV.Text = Convert.ToString(producto.IGV);
                txtPrecioVenta.Text = Convert.ToString(producto.PrecioVenta);

            }else
            {
                MessageBox.Show("No existe el producto", 
                    "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
