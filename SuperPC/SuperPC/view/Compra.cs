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



namespace SuperPC.view
{
    public partial class Compra : Form
    {
        Consultas controllSQL;
        public Compra(Consultas controllSQL)
        {
            InitializeComponent();
            this.controllSQL = controllSQL;
        }

        private void Compra_Load(object sender, EventArgs e)
        {

        }
    }
}
