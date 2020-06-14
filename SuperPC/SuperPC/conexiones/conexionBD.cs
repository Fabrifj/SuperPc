using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SuperPC.conexiones
{
    public class conexionBD
    {
        private string cadena;

        //Data Source=DESKTOP-BC8ISUO; Initial Catalog=Militares; Integrated Security=True
        public SqlConnection conectarbd = new SqlConnection();

        public conexionBD(string dir, string bd, string security)
        {
            this.cadena = String.Format("Data Source= {0}; Initial Catalog= {1}; Integrated Security= {2}", dir, bd, security);
            conectarbd.ConnectionString = cadena;
        }

        public void abrir(System.Windows.Forms.Label lblConexion)
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("Se conecto Correctamente");
                lblConexion.Text = "Se conecto Correctamente";

            }
            catch
            {
                Console.WriteLine("Error al abrir BD");
                lblConexion.Text = "Error al abrir BD";
            }
        }
        public void cerrar()
        {
            conectarbd.Close();
        }

    }
}
