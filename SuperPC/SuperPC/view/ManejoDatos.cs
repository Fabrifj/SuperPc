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
            Agregar agregar = new Agregar(titulo, controllSQL);
            agregar.ShowDialog();

        }

        private void ManejoDatos_Load(object sender, EventArgs e)
        {

        }
    }
}
