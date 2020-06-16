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
using System.Collections.Generic;




namespace SuperPC
{
   

    public partial class Registro : Form
    {
        // auxi consultas 
        private DataTable data;
        private string titulo;
        


        Consultas controllSQL;
        public Registro(Consultas controllSQL,string titulo)
        {
            InitializeComponent();
            this.controllSQL = controllSQL;
            this.titulo = titulo;
            lblTitulo.Text = titulo;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            data = controllSQL.select_Simple(titulo);

            dgv_Ventas.DataSource = data;



            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            data = controllSQL.select_Simple_Limitado("VENTA_PRODUCTO","CODIGO_VENTA",ID);

            dgv_Ventas.DataSource = data;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            data = controllSQL.select_Simple(titulo);

            dgv_Ventas.DataSource = data;
        }
    }
}
