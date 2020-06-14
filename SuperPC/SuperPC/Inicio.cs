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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
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
