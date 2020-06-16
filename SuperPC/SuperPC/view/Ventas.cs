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
        Consultas controllSQL;
        private DataTable data;

        private string CODIGO_VENTA;

        // Cadena de texto 
        private string resumen;
        private int costo;
        private string nombre = "Nombre del cliente";
        private string id_cliente ;
        private string nit=  "nit del cliente ";

    


        
        public Ventas(Consultas consultas)
        {
            InitializeComponent();
            lblNit.Text = nit;
            lblNombre.Text = nombre;
            this.controllSQL = consultas;


        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            
            string db = string.Format("select MAX(CODIGO_VENTA) AS CODIGO FROM VENTA;");
            data = controllSQL.select_Hard_Code(db);
            try
            {
                CODIGO_VENTA = Convert.ToString(Convert.ToInt32( data.Rows[0]["CODIGO"].ToString()) +1);
                lblCodigo.Text = " Numero de venta " + CODIGO_VENTA;

            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AñadirDatos añadirDatos = new AñadirDatos("CLIENTE", controllSQL);
            añadirDatos.CODIGO_VENTA = "";
            añadirDatos.ShowDialog();

            this.nombre = añadirDatos.Dato1;
            this.nit = añadirDatos.Dato2;
            this.id_cliente = añadirDatos.ID_CLIENTE;

            this.lblNombre.Text = this.nombre;
            this.lblNit.Text = this.nit;


            resumen += this.nombre +"         " +this.nit + Environment.NewLine;
            txtbVentas.Text = resumen;


            
            
            string fecha = Convert.ToString(System.DateTime.Today.Month) +"/" + Convert.ToString(System.DateTime.Today.Day)
                + "/" + Convert.ToString(System.DateTime.Today.Year);
            lblNit.Text = fecha;
            string[] values = {"'" + fecha + "'", "1", id_cliente };
            
            
            
           
            string consulta = string.Format("insert into VENTA values({0})",values);
            controllSQL.insertar("VENTA", values);
            

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            AñadirDatos añadirDatos = new AñadirDatos("PRODUCTO", controllSQL);
            añadirDatos.CODIGO_VENTA = CODIGO_VENTA;
            añadirDatos.ShowDialog();

            resumen += añadirDatos.Dato1 + Environment.NewLine;
            costo += Convert.ToInt32(añadirDatos.Dato2);
            txtbVentas.Text = resumen;

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            // modificar el precio final 
            string consulta = string.Format("UPDATE VENTA SET TOTAL = {0} WHERE CODIGO_VENTA = {1} ", costo,CODIGO_VENTA);
            controllSQL.consulta_Hard_Code(consulta);
            this.Close();
        }
    }
}
