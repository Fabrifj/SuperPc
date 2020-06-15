using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperPC.conexiones;
using SuperPC.view;

namespace SuperPC.controller
{
    public class Consultas
    {
        conexionBD miConexion;

        private string consulta;
        private string campos;
        private string limitar;
        private string primary_Key;

        private string dato_Obtenido;
        private bool cancelar;

        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter datos;

        public Consultas(conexionBD bd)
        {
            this.miConexion = bd;
            dato_Obtenido = "";
            cancelar = false;
        }

        public string Dato_Obtenido { get => dato_Obtenido; set => dato_Obtenido = value; }
        public bool Cancelar { get => cancelar; set => cancelar = value; }

        public DataTable select_Simple(string tabla, string[] columnas = null)
        {
            miConexion.abrir();
            DataTable matriz = new DataTable();
            campos = "";

            try
            {
                //Si columnas no esta vacio se crea un string que contenga todos los strings de columnas
                if (columnas != null)
                    for (int i = 0; i < columnas.Length; i++) campos = agregar(campos, columnas[i]);
                else
                    campos = "*"; //Si esta vacio se coloca un * para seleccionar todos los campos

                consulta = string.Format("SELECT {0} FROM {1}", campos, tabla);
                comando = new SqlCommand(consulta, miConexion.conectarbd);
                datos = new SqlDataAdapter(comando);
                datos.Fill(matriz);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            miConexion.cerrar();
            return matriz;
        }
        public DataTable select_Simple_Limitado(string tabla, string limitante, string limitador,string[] columnas = null)
        {
            miConexion.abrir();
            DataTable matriz = new DataTable();
            campos = "";

            try
            {
                //Si columnas no esta vacio se crea un string que contenga todos los strings de columnas
                if (columnas != null)
                    for (int i = 0; i < columnas.Length; i++) campos = agregar(campos, columnas[i]);
                else
                    campos = "*"; //Si esta vacio se coloca un * para seleccionar todos los campos

                consulta = string.Format("SELECT {0} FROM {1} WHERE {2} = {3} ", campos, tabla, limitante, limitador);
                comando = new SqlCommand(consulta, miConexion.conectarbd);
                datos = new SqlDataAdapter(comando);
                datos.Fill(matriz);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            miConexion.cerrar();
            return matriz;
        }
        public DataTable select_Limitante(string tabla, string tabla_Limitadora, string limitador, string[] columnas = null)
        {
            miConexion.abrir();

            DataTable matriz = new DataTable();
            campos = "";
            limitar = "";
            primary_Key = "";
            try
            {
                //Si columnas no esta vacio se crea un string que contenga todos los strings de columnas
                if (columnas != null)
                    for (int i = 0; i < columnas.Length; i++) campos = agregar(campos, columnas[i]);
                else
                    campos = "*"; //Si esta vacio se coloca un * para seleccionar todos los campos

                primary_Key = obtener_PK(tabla_Limitadora);

                //El limitador tiene que ser un primary key de la tabla limitadora
                limitar = string.Format("WHERE {0} = {1}", primary_Key, limitador);

                consulta = string.Format("SELECT {0} FROM {1} {2}", campos, tabla, limitar);
                comando = new SqlCommand(consulta, miConexion.conectarbd);
                datos = new SqlDataAdapter(comando);
                datos.Fill(matriz);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            miConexion.cerrar();
            return matriz;
        }

        public DataTable select_Hard_Code(string sentencia) //Se pasa como parametro la sentencia directa
        {
            miConexion.abrir();
            DataTable matriz = new DataTable();

            try
            {
                consulta = sentencia;
                comando = new SqlCommand(consulta, miConexion.conectarbd);
                datos = new SqlDataAdapter(comando);
                datos.Fill(matriz);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

            miConexion.cerrar();
            return matriz;
        }

        public void insertar_Manual(string tabla, bool agregar_Primary)
        {
            miConexion.abrir();

            Insertar_Datos insertar;

            string lec;
            string PK = "";

            string inserciones = "";
            bool insertado = false;

            try
            {
                if(!agregar_Primary) //Si es necesario agrgar el primary key igualmente
                    PK = obtener_PK(tabla);//Se obtine el primary key para evitar insertarla porque esta con identity

                //Se obtinene todos los campos de la tabla ingresada
                consulta = string.Format("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('dbo.{0}')", tabla);
                consulta_Lector(consulta);//Se realiza la consulta y se la guarda en el lector

                while (lector.Read()) //Minetras haya valores en el lector
                {
                    lec = lector.GetValue(0).ToString();

                    while (!insertado && lec != PK && !cancelar)//Minetras no inserte el valor o se presione cancelar va a seguir apareciendo la pestaña
                    {
                        insertar = new Insertar_Datos(this, lec); //Se crea un nuevo forms por cada campo obtenido
                        insertar.ShowDialog();
                        if (dato_Obtenido != "")
                        {
                            inserciones = agregar(inserciones, dato_Obtenido); //Se crea un solo string con todas las inserciones
                            insertado = true; //Se define que el valor fue guardado para terminar el bucle
                            dato_Obtenido = ""; //Se resetea el dato_Obtenido para evitar errores
                        }
                    }

                    if (cancelar) break; //Si se presiono el boton cancelar en insertar se rompe el ciclo
                    insertado = false;
                }

                lector.Close(); //Siempre se cierra el lector de datos despues de ejecutarlo

                if (!cancelar) //Si se presiono cancelar no se ejecuta ningun comando
                {
                    consulta = string.Format("INSERT INTO {0} VALUES({1})", tabla, inserciones);
                    comando = new SqlCommand(consulta, miConexion.conectarbd);
                    comando.ExecuteReader();
                }

            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

            cancelar = false; //Se vuelve a setear cancelar como falso para evitar errores
            miConexion.cerrar();
        }

        public void insertar(string tabla, string[] valores)
        {
            miConexion.abrir();

            string inserciones = "";

            for(int i = 0; i < valores.Length; i++)
            {
                inserciones = agregar(inserciones, valores[i]);//Se crea un solo string con todos los valores ingresados
            }

            //Se realiza la consulta
            try
            {
                consulta = string.Format("INSERT INTO {0} VALUES({1})", tabla, inserciones);
                comando = new SqlCommand(consulta, miConexion.conectarbd);
                comando.ExecuteReader();

            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

            miConexion.cerrar();
        }

        public void consulta_Hard_Code(string sentencia) //Se pasa como parametro la sentencia directa
        {
            miConexion.abrir();

            try
            {
                consulta = sentencia;
                comando = new SqlCommand(consulta, miConexion.conectarbd);
                comando.ExecuteReader();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            miConexion.cerrar();
        }

        private void consulta_Lector(string consulta)
        {
            //Funcion usada para ejecutar un comando y guardarlo en el lector
            comando = new SqlCommand(consulta, miConexion.conectarbd);
            lector = comando.ExecuteReader();
        }

        private string agregar(string principal, string agregado)
        {
            if (principal != "")
                principal += ", " + agregado; //Si el string no esta vacio se empezara a formar una cadena de valores separados por una ","
            else principal = agregado; //Si el string esta vacio entoces se anadira primeramente la variable ingresada como agregado

            return principal;
        }

        public string obtener_PK(string tabla)
        {
            string lec = "";

            //Esta consulta obtiene el nombre de la columna que es su primary key de la tabla
            consulta = string.Format("SELECT COLUMN_NAME FROM SuperPC.INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                        "WHERE TABLE_NAME LIKE '{0}' AND CONSTRAINT_NAME LIKE 'PK%'", tabla);
            consulta_Lector(consulta);
            if (lector.Read())
                lec = lector.GetValue(0).ToString();

            lector.Close();

            return lec;
        }
    }
}
