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

namespace SuperPC
{
    public partial class Inicio : Form
    {
        // Llaves Para la base de datos 
        string direccion = "DESKTOP-BC8ISUO";
        string bd = "Militares";
        string security = "True";
        

       

        public Inicio()
        {
            InitializeComponent();
            conexionBD miConexion = new conexionBD(direccion, bd, security);
            //miConexion.abrir(lblConexion);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        // Botonoes 
        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
        }
        private void btnRegsitro_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
        }
    }
}
