using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Text;


namespace Iglesia
{
    public partial class AgregarIngresos : Form
    {
        //conexion conexionDB = new conexion();       

        int idTipoIngreso;
        private OleDbConnection conexion;
        private string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\MELIS\Documents\Baseiglesiaproduccion.mdb";
        
        private Dictionary<string, int> tiposIngresoDictionary = new Dictionary<string, int>();
        public AgregarIngresos()
        {
            InitializeComponent();
            
            CargarDatosComboboxIngresos();
        }

        private void button1Guardar_Click(object sender, EventArgs e)
        {
            
            {
                GuardarBD();

            }

        }

        
        private void CargarDatosComboboxIngresos()
        {
            string consulta = "SELECT Id_tipoIngreso, tipo_ingreso FROM TipoIngreso";
            using (OleDbConnection conexion = new OleDbConnection(connectionString))
            {
                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    try
                    {
                        conexion.Open();
                        OleDbDataReader reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            int idTipoIngreso = Convert.ToInt32(reader["Id_tipoIngreso"]);
                            string tipoIngreso = reader["tipo_ingreso"].ToString();
                            comboBox1TipoIngreso.Items.Add(tipoIngreso);
                            tiposIngresoDictionary.Add(tipoIngreso, idTipoIngreso); // Guarda el Id_tipoIngreso en el diccionario
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos: " + ex.Message);
                    }
                    finally
                    {
                        if (conexion.State == ConnectionState.Open)
                        {
                            conexion.Close();
                        }
                    }
                }
            }
        }

        private void GuardarBD()
        {
            if ((txtMONTO.Text == "" || txtTotal.Text == "" || txtDetalle.Text == ""))
            {
                MessageBox.Show("Los campos son obligatorios. Por favor completelos");
            }
            else
            {
                DateTime fechaAlta = DateTime.Now;

                OleDbConnection cn = new OleDbConnection(connectionString);
                 
                cn.Open();
                String consulta = "insert into Ingresos ( id_tipoIngreso, MONTO, TOTAL ,DETALLE, FECHA) values ('"+ idTipoIngreso +"','"+ int.Parse(txtMONTO.Text) + "', '" + int.Parse(txtTotal.Text) + "', '" + txtDetalle.Text + "', '" + dateTimePicker1.Value + "' )";


                OleDbCommand comando1 = new OleDbCommand(consulta, cn);


                int cantidad = comando1.ExecuteNonQuery();


                if (cantidad < 1)
                {
                    MessageBox.Show("Ocurrió un problema");
                }
                else
                {
                    MessageBox.Show("Se guardó con éxito!!!");
                }
            }

        }

        private void button3Limpiar_Click(object sender, EventArgs e)
        {
            //txtTipoIngreso.Text = "";
            txtMONTO.Text = "";
            txtTotal.Text = "";
            txtDetalle.Text = "";
            dateTimePicker1.Text = "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoIngresoSeleccionado = comboBox1TipoIngreso.SelectedItem.ToString();
            idTipoIngreso = tiposIngresoDictionary[tipoIngresoSeleccionado];
            MessageBox.Show($"El Id_tipoIngreso seleccionado es: {idTipoIngreso}");

        }
        private void MostrarTipoIngreso(string TipoIngreso)
        {
            string consulta = "SELECT id_tipoIngreso FROM Ministerios WHERE id_tipoIngreso = @NombreMinisterio";

            using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@id_tipoIngreso", TipoIngreso);

                try
                {
                    conexion.Open();
                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        //txtTipoIngreso.Text = resultado.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el ID del Tipo Ingreso: " + ex.Message);
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
        }
    }
}

    