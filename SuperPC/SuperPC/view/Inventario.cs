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
            ManejoDatos manejoDatos = new ManejoDatos("PRODUCTO", controllSQL);
            manejoDatos.ShowDialog();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar("AGREGAR PEDIDOS", controllSQL);
            agregar.ShowDialog();
        }

        private void btnProvedor_Click(object sender, EventArgs e)
        {
            ManejoDatos manejoDatos = new ManejoDatos("PROVEEDOR", controllSQL);
            manejoDatos.ShowDialog();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            
        }
    }
}
