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

namespace Iglesia
{
    public partial class AgregarEgresos : Form
    {
        private OleDbConnection conexion;
        private string cadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:D:\Jimena\Aplicacion_Fer_Jime\proyectotesis2\iglesia2023-main\iglesia2023-main\Iglesia\bin\Debug\BaseIglesiaproduccion.mdb";
        public AgregarEgresos()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // if (Validacion() == true)
            {
                GuardarBD();

            }

        }

        private void GuardarBD()
        {
            if ((txtTipoEgreso.Text == "" || txtMONTO.Text == "" || txtTotal.Text == "" || txtDetalle.Text == ""))
            {
                MessageBox.Show("Los campos son obligatorios. Por favor completelos");
            }
            else
            {
                DateTime fechaAlta = DateTime.Now;

                // string conexion @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\MELIS\Documents\Baseiglesiaproduccion.mdb";
                OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Jimena\Aplicacion_Fer_Jime\proyectotesis2\iglesia2023-main\iglesia2023-main\Iglesia\bin\Debug\BaseIglesiaproduccion.mdb");
                cn.Open();
                String consulta = "insert into Egresos (ID_EGRESO,ID_TIPOEGRESO, MONTO, TOTAL ,DETALLE, FECHA) values (" + int.Parse(txtTipoEgreso.Text) + ", '" + int.Parse(txtMONTO.Text) + "', '" + int.Parse(txtTotal.Text) + "', '" + txtDetalle.Text + "', '" + dateTimePicker1Fecha.Value + "' )";


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

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            txtTipoEgreso.Text = "";
            txtMONTO.Text = "";
            txtTotal.Text = "";
            txtDetalle.Text = "";
            dateTimePicker1Fecha.Text = "";
        }
    }
    }


