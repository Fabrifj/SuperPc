using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SuperPC.conexiones;
using SuperPC.controller;

namespace SuperPC
{
    public partial class Inicio : Form
    {
        // Llaves Para la base de datos 
        string direccion = ".";
        string bd = "SuperPC";
        string security = "True";

        Consultas controllSQL;

        public Inicio()
        {
            InitializeComponent();
            // Creamos conexion 
            conexionBD miConexion = new conexionBD(direccion, bd, security);

            //Creamos Consultas
            this.controllSQL = new Consultas(miConexion);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Botonoes 
        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas(this.controllSQL);
            ventas.ShowDialog();
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario(this.controllSQL);
            inventario.ShowDialog();
        }
        private void btnRegsitro_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro(this.controllSQL);
            registro.ShowDialog();
        }
    }
}
