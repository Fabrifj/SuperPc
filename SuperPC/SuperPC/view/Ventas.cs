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

        // Cadena de texto 
        private string texto;
        private int costo;
        private string nombre = "Nombre del cliente";
        private string nit=  "nit del cliente ";

    


        
        public Ventas(Consultas consultas)
        {
            InitializeComponent();
            this.consultas = consultas;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            lblNit.Text = nit;
            lblNombre.Text = nombre;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AñadirDatos añadirDatos = new AñadirDatos("CLIENTE", consultas); 
            añadirDatos.ShowDialog();
            this.nombre = añadirDatos.Dato1;
            this.nit = añadirDatos.Dato2;

            this.lblNombre.Text = this.nombre;
            this.lblNit.Text = this.nit;
            
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
