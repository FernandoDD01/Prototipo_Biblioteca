using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace Prototipo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        OracleConnection ora = new OracleConnection("DATA SOURCE = XEPDB1 ;  PASSWORD = PassPrestamo ; USER ID = USR_PRESTAMO");

        private void button1_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM EMPLEADO WHERE NOMBRE = :nombre AND CLAVE = :clave", ora);

            comando.Parameters.Add(":nombre", textBox1.Text);
            comando.Parameters.Add(":clave", textBox2.Text);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                if (lector["ROL"].ToString() == "Admin")
                {
                    MessageBox.Show("Inicio de sesión exitoso!");
                    Inicio v1 = new Inicio();
                    this.Hide(); //se cierra la ventana anterior 

                    v1.Show();
                    ora.Close();
                }
            }
            else{

                MessageBox.Show("Usuario o contraseña incorrecto");
                ora.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
