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
using System.Collections.Generic;




namespace SuperPC
{
   

    public partial class Registro : Form
    {
        // auxi consultas 
        private DataTable data;
        


        Consultas controllSQL;
        public Registro(Consultas controllSQL)
        {
            InitializeComponent();
            this.controllSQL = controllSQL;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            data = controllSQL.select_Simple("VENTA");

            dgv_Ventas.DataSource = data;



            
        }

        
    }
}
