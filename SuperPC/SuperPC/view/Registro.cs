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
            string consulta = "SELECT CLIENTE.NOMBRE_CLIENTE, CLIENTE.TELEFONO, FECHA, TOTAL FROM VENTA " +
                "INNER JOIN CLIENTE ON CLIENTE.ID_CLIENTE = VENTA.ID_CLIENTE";
            data = controllSQL.select_Hard_Code(consulta);

            dgv_Ventas.DataSource = data;
            
        }

        
    }
}
