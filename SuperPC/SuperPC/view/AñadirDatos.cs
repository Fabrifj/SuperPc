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
        // variables enviables
        string id;
        //
        string dato1;
        string dato2;
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
            id=txtId.Text;
            if (titulo == "CLIENTE")
            {
                data = controllSQL.select_Simple_Limitado(titulo, "ID_CLIENTE", id);

                campos = new string[] { "ID_CLIENTE" };
                data = controllSQL.select_Simple_Limitado(titulo,"ID_CLIENTE",id, campos);
                dato1 = data.ToString();
                dgv_Productos.DataSource = data;
            }
            else
            {

            }
    }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar(titulo, controllSQL);
            agregar.ShowDialog();
        }

        private void AñadirDatos_Load(object sender, EventArgs e)
        {
            data = controllSQL.select_Simple(titulo);
            dgv_Productos.DataSource = data;
            categorias = new List<string>(); //En esta lista se guarda las descripciones que vayamos a obtener de categoria
            primaryKey = new List<string>(); //En esta sus codigos

            if (titulo == "PRODUCTO")
            {
                data = controllSQL.select_Simple("CATEGORIA");
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string descripcion = data.Rows[i]["DESCRIPCION"].ToString();
                    categorias.Add(descripcion);
                    string key = data.Rows[i]["CODIGO_CATEGORIA"].ToString();//Rows[fila][columna]
                    primaryKey.Add(key);
                }
                comboBox1.DataSource = categorias;
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
