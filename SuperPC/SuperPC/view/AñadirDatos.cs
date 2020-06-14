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
        string titulo;
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

        }
    }
}
