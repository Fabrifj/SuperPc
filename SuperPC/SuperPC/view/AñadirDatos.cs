using SuperPC.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace SuperPC.view
{
    public partial class AñadirDatos : Form
    {
        // variables VENTA_PRODUCTO
        public string CODIGO_VENTA { get; set; }
        string ID_PRODUCTO;
        string CANTIDAD;
        public string ID_CLIENTE { get; set; }

        //

        public string Dato1 { get; set; }
        public string Dato2 { get; set; }
       



    string titulo;

        private string[] campos;
        private DataTable data;

        List<string> categorias;
        List<string> primaryKey;

        Consultas controllSQL;
        public AñadirDatos(string titulo, Consultas controllSQL)
        {
            InitializeComponent();
            this.titulo = titulo;
            lblTitulo.Text = titulo;
            this.controllSQL = controllSQL;
            

        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (titulo == "CLIENTE")
            {
                ID_CLIENTE = txtId.Text;
                campos = new string[] { "NOMBRE_CLIENTE", "CARNET"};
                data = controllSQL.select_Simple_Limitado(titulo,"ID_CLIENTE", ID_CLIENTE, campos);
                Dato1 = data.Rows[0]["NOMBRE_CLIENTE"].ToString();
                Dato2 = data.Rows[0]["CARNET"].ToString();
                

                lblDato1.Text = Dato1;
                dgv_Productos.DataSource = data;
            } 

            if (titulo == "PRODUCTO")
            {
                ID_PRODUCTO = txtId.Text;
                lblDato1.Text = ID_PRODUCTO;

                int total = 0;
                string valores = "ID_PRODUCTO, MARCA, CATEGORIA.DESCRIPCION, PRECIO, STOCK";

                string db = string.Format("SELECT {0}  FROM PRODUCTO INNER JOIN CATEGORIA ON " +
                    "PRODUCTO.CODIGO_CATEGORIA = CATEGORIA.CODIGO_CATEGORIA WHERE ID_PRODUCTO = '{1}'", valores, ID_PRODUCTO);
                CANTIDAD = txtCantidad.Text;
                data = controllSQL.select_Hard_Code(db);
                try
                {
                    total = Convert.ToInt32( data.Rows[0]["PRECIO"].ToString()) * Convert.ToInt32(CANTIDAD);

                    Dato1 =total + "   " + data.Rows[0]["ID_PRODUCTO"].ToString() +"   "+ data.Rows[0]["MARCA"].ToString() + "   " ;
                    Dato1 += data.Rows[0]["DESCRIPCION"].ToString() + "   " + data.Rows[0]["PRECIO"].ToString() + "   " + CANTIDAD;
                    Dato2 = Convert.ToString(total);
                }
                catch (Exception error)
                {
                  
                    MessageBox.Show(error.Message);
                }
                dgv_Productos.DataSource = data;
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            ID_PRODUCTO = string.Format("'{0}'", ID_PRODUCTO);
            
            if (CODIGO_VENTA != "" && CANTIDAD != null)
            {
                string[] values = { CODIGO_VENTA, ID_PRODUCTO, CANTIDAD };

                controllSQL.insertar("VENTA_PRODUCTO", values);
                
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllSQL.insertar_Manual(titulo, false);
            data = controllSQL.select_Simple(titulo);
            dgv_Productos.DataSource = data;
        }

        private void AñadirDatos_Load(object sender, EventArgs e)
        {
            data = controllSQL.select_Simple(titulo);
            dgv_Productos.DataSource = data;
            categorias = new List<string>(); //En esta lista se guarda las descripciones que vayamos a obtener de categoria
            primaryKey = new List<string>(); //En esta sus codigos
            
            if (titulo == "PRODUCTO")
            {
                btnAñadirNuevo.Left = -100;

                data = controllSQL.select_Simple("CATEGORIA");
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string descripcion = data.Rows[i]["DESCRIPCION"].ToString();
                    categorias.Add(descripcion);
                    string key = data.Rows[i]["CODIGO_CATEGORIA"].ToString();//Rows[fila][columna]
                    primaryKey.Add(key);
                }
                txtCantidad.Text = "1";
                comboBox1.DataSource = categorias;
            }
            else
            {
                comboBox1.Enabled = false;
                txtCantidad.Enabled = false;
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex; //Se obtinene el indice del comboBox seleccionado
            campos = new string[] { "ID_PRODUCTO", "MARCA", "DESCRIPCION", "PRECIO", "STOCK" }; //Se definen los campos requeridos
            data = controllSQL.select_Limitante("PRODUCTO", "CATEGORIA", primaryKey[index], campos);

            dgv_Productos.DataSource = data;

        }
    }
}
