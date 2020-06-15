using SuperPC.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperPC.view
{
    public partial class Insertar_Datos : Form
    {
        private Consultas consulta;
        public Insertar_Datos(Consultas consulta, string columna)
        {
            InitializeComponent();
            this.consulta = consulta;
            lbl_Columna.Text = columna;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            consulta.Dato_Obtenido = txt_Dato_Obtenido.Text;
            this.Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            consulta.Cancelar = true;
            this.Close();
        }
    }
}
