using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperPC.controller;



namespace SuperPC
{
    public partial class ManejoDatos : Form
    {
        // auxi consultas 
        private DataTable data;
        private bool pk;

        Consultas controllSQL;
        string titulo;
        public ManejoDatos(string titulo, Consultas controllSQL)
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
            if(titulo == "PRODUCTO")
                controllSQL.insertar_Manual(titulo, true);
            else controllSQL.insertar_Manual(titulo, false);

        }

        private void ManejoDatos_Load(object sender, EventArgs e)
        {
            data = controllSQL.select_Simple(titulo);

            dgv_Datos.DataSource = data;
        }
    }
}
