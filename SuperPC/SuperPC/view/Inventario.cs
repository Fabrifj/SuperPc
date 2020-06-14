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
using SuperPC.controller;



namespace SuperPC
{
    public partial class Inventario : Form
    {
        Consultas controllSQL;
        public Inventario(Consultas controllSQL)
        {
            InitializeComponent();
            this.controllSQL = controllSQL;
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            ManejoDatos manejoDatos = new ManejoDatos("Produto", controllSQL);
            manejoDatos.ShowDialog();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            Compra compra = new Compra(controllSQL);
            compra.ShowDialog();

        }

        private void btnProvedor_Click(object sender, EventArgs e)
        {
            ManejoDatos manejoDatos = new ManejoDatos("Provedor", controllSQL);
            manejoDatos.ShowDialog();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {

        }
    }
}
