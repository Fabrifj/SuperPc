using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperPC.conexiones;
using SuperPC.controller;



namespace SuperPC
{
    
    public partial class Agregar : Form
    {
        private string[] campos;
        private string[] valores;
        string titulo;
        private Consultas controllSQL;

        private DataTable data;

        private List<string> categorias;
        private List<string> pk_Categorias;

        private List<string> productos;
        private List<string> pk_Productos;
        private List<string> stock;

        private List<string> proveedores;
        private List<string> pk_Proveedores;

        public Agregar(string titulo, Consultas controllSQL)
        {
            InitializeComponent();
            this.titulo = titulo;
            lblTitulo.Text = titulo;
            this.controllSQL = controllSQL;

        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            int index;
            int index_P;

            index = cmb_Proveedor.SelectedIndex;
            string PK_ID_PROVEEDOR = pk_Proveedores[index];

            index_P = cmb_Producto.SelectedIndex;
            string PK_ID_PRODUCTO = pk_Productos[index_P];

            index = Convert.ToInt32(txt_Cantidad.Text) * Convert.ToInt32(txt_Costo.Text);

            valores = new string[] { "'" + PK_ID_PROVEEDOR + "'", "'" + PK_ID_PRODUCTO + "'", txt_Cantidad.Text, index.ToString() };
            controllSQL.insertar("COMPRA_STOCK", valores);

            index_P = Convert.ToInt32(stock[index_P]) + Convert.ToInt32(txt_Cantidad.Text);
            string update_Stock = string.Format("UPDATE PRODUCTO SET STOCK = {0} " +
                "WHERE ID_PRODUCTO = '{1}'", index_P, PK_ID_PRODUCTO);
            controllSQL.consulta_Hard_Code(update_Stock);

            cargar_Datos_DGV();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            data = controllSQL.select_Simple("CATEGORIA");

            categorias = new List<string>();
            pk_Categorias = new List<string>();

            for(int i = 0; i < data.Rows.Count; i++)
            {
                string descripcion = data.Rows[i]["DESCRIPCION"].ToString();
                categorias.Add(descripcion);

                string key = data.Rows[i]["CODIGO_CATEGORIA"].ToString();
                pk_Categorias.Add(key);
            }

            cmb_Categoria.DataSource = categorias;

            //--------------------------------------------------

            campos = new string[] { "ID_PROVEEDOR", "RAZON_SOCIAL" };
            data = controllSQL.select_Simple("PROVEEDOR", campos);

            proveedores = new List<string>();
            pk_Proveedores = new List<string>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                string descripcion = data.Rows[i]["RAZON_SOCIAL"].ToString();
                proveedores.Add(descripcion);

                string key = data.Rows[i]["ID_PROVEEDOR"].ToString();
                pk_Proveedores.Add(key);
            }

            cmb_Proveedor.DataSource = proveedores;

            cargar_Datos_DGV();
        }

        private void cmb_Categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmb_Categoria.SelectedIndex;

            campos = new string[] { "ID_PRODUCTO", "DESCRIPCION", "MARCA", "STOCK" };
            data = controllSQL.select_Limitante("PRODUCTO", "CATEGORIA", pk_Categorias[index], campos);

            productos = new List<string>();
            pk_Productos = new List<string>();
            stock = new List<string>();

            for(int i = 0; i < data.Rows.Count; i++)
            {
                string producto = data.Rows[i]["MARCA"].ToString() + " " + data.Rows[i]["DESCRIPCION"].ToString();
                productos.Add(producto);

                string key = data.Rows[i]["ID_PRODUCTO"].ToString();
                pk_Productos.Add(key);

                string stck = data.Rows[i]["STOCK"].ToString();
                stock.Add(stck);
            }

            cmb_Producto.DataSource = productos;
        }

        private void cmb_Producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmb_Producto.SelectedIndex;
            campos = new string[] { "COSTO" };
            data = controllSQL.select_Limitante("PRODUCTO", "PRODUCTO","'" + pk_Productos[index] + "'", campos);

            txt_Costo.Text = data.Rows[0][0].ToString();
        }

        private void cargar_Datos_DGV()
        {
            string consulta = "select PROVEEDOR.RAZON_SOCIAL, PRODUCTO.MARCA, PRODUCTO.DESCRIPCION, CANTIDAD_COMPRA," +
                "PRECIO_TOTAL FROM COMPRA_STOCK " +
                "INNER JOIN PROVEEDOR ON PROVEEDOR.ID_PROVEEDOR = COMPRA_STOCK.ID_PROVEEDOR " +
                "INNER JOIN PRODUCTO ON PRODUCTO.ID_PRODUCTO = COMPRA_STOCK.ID_PRODUCTO";
            data = controllSQL.select_Hard_Code(consulta);
            dgv_Pedidos.DataSource = data;
        }
    }
}
