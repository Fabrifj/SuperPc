using SuperPC.controller;
using SuperPC.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SuperPC
{
    public partial class Ventas : Form
    {
        Consultas consultas;

        
        public Ventas(Consultas consultas)
        {
            InitializeComponent();
            this.consultas = consultas;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AñadirDatos añadirDatos = new AñadirDatos("CLIENTE", consultas);
            lblNombre.Text= añadirDatos.Dato1;
            añadirDatos.ShowDialog();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            AñadirDatos añadirDatos = new AñadirDatos("PRODUCTO", consultas);
            añadirDatos.ShowDialog();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
