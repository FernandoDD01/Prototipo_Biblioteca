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
    public partial class Libros : Form
    {
        public Libros()
        {
            InitializeComponent();
        }
        
        int cont = 0;
        int id_fila;
        
        private void Actualizar_vista() {
            OracleConnection ora = new OracleConnection("DATA SOURCE = XEPDB1 ;  PASSWORD = PassPrestamo ; USER ID = USR_PRESTAMO");
            ora.Open();
            OracleCommand comando = new OracleCommand("Vista_libros", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            ora.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            OracleConnection ora = new OracleConnection("DATA SOURCE = XEPDB1 ;  PASSWORD = PassPrestamo ; USER ID = USR_PRESTAMO");
            cont++;
            Actualizar_vista();

            //Agrega los item a los Combobox (lista Genero)
            if (cont == 1) {
                ora.Open();
                OracleCommand comando2 = new OracleCommand("Select ID,Genero from genero", ora);
            OracleDataReader registro = comando2.ExecuteReader();
            
            while(registro.Read())
            {
                CBGenero.Items.Add(registro["Genero"].ToString());
            }
            registro.Close();

            //
            //Agrega los item a los Combobox (lista Editorial)
            OracleCommand comando3 = new OracleCommand("Select ID,Editorial from editorial", ora);
            OracleDataReader registro2 = comando3.ExecuteReader();

            while (registro2.Read())
            {
                CBEditorial.Items.Add(registro2["Editorial"].ToString());
            }
            registro2.Close();

            //
            //Agrega los item a los Combobox (lista Idioma)
            OracleCommand comando4 = new OracleCommand("Select ID,Idioma from idioma", ora);
            OracleDataReader registro3 = comando4.ExecuteReader();

            while (registro3.Read())
            {
                CBIdioma.Items.Add(registro3["Idioma"].ToString());
            }
            registro3.Close();

            //
            }
            ora.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = XEPDB1 ;  PASSWORD = PassPrestamo ; USER ID = USR_PRESTAMO");
            int IndiceG = 0, IndiceE = 0, IndiceI = 0;
            try
            {
                ora.Open();
                List<String> relacionG = new List<string>();
                List<String> relacionE = new List<string>();
                List<String> relacionI = new List<string>();

                //Crea la relacion entre el nombre del campo con el ID
                OracleCommand comando2 = new OracleCommand("Select ID,Genero from genero", ora);
                OracleDataReader registro = comando2.ExecuteReader();

                while (registro.Read())
                {
                    relacionG.Add(registro["Genero"].ToString());
                }

                registro.Close();
                for (IndiceG = 0; relacionG[IndiceG] != CBGenero.SelectedItem.ToString(); )
                {
                    IndiceG++;
                }
                //
                //Crea la relacion entre el nombre del campo con el ID
                OracleCommand comando3 = new OracleCommand("Select ID,Editorial from Editorial", ora);
                OracleDataReader registro2 = comando3.ExecuteReader();

                while (registro2.Read())
                {
                    relacionE.Add(registro2["Editorial"].ToString());
                }

                registro2.Close();
                for (IndiceE = 0; relacionE[IndiceE] != CBEditorial.SelectedItem.ToString(); )
                {
                    IndiceE++;
                }
                //
                //Crea la relacion entre el nombre del campo con el ID
                OracleCommand comando4 = new OracleCommand("Select ID,Idioma from idioma", ora);
                OracleDataReader registro3 = comando4.ExecuteReader();

                while (registro3.Read())
                {
                    relacionI.Add(registro3["Idioma"].ToString());
                }

                registro3.Close();
                for (IndiceI = 0; relacionI[IndiceI] != CBIdioma.SelectedItem.ToString(); )
                {
                    IndiceI++;
                }
                //
                OracleCommand comando = new OracleCommand("insert_libro", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("nom_lib", OracleType.VarChar).Value = textBox1.Text;
                comando.Parameters.Add("nom_aut", OracleType.VarChar).Value = textBox2.Text;
                comando.Parameters.Add("ape_aut", OracleType.VarChar).Value = textBox3.Text;
                comando.Parameters.Add("an", OracleType.Number).Value = textBox4.Text;
                comando.Parameters.Add("gen", OracleType.Number).Value = IndiceG + 1;
                comando.Parameters.Add("edito", OracleType.VarChar).Value = IndiceE + 1;
                comando.Parameters.Add("idiom", OracleType.VarChar).Value = IndiceI + 1;
                comando.ExecuteNonQuery();
                MessageBox.Show("Libro insertado");

            }
            catch (Exception)
            {
                MessageBox.Show("Algo salio mal");
            }
            ora.Close();
            Actualizar_vista();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = XEPDB1 ;  PASSWORD = PassPrestamo ; USER ID = USR_PRESTAMO");
            int IndiceG = 0, IndiceE = 0, IndiceI = 0;
            try
            {
                ora.Open();
                List<String> relacionG = new List<string>();
                List<String> relacionE = new List<string>();
                List<String> relacionI = new List<string>();
                //relacionG[0] = "Fernando";
                //Console.WriteLine(relacionG[0]);
                //Crea la relacion entre el nombre del campo con el ID
                OracleCommand comando2 = new OracleCommand("Select ID,Genero from genero", ora);
                OracleDataReader registro = comando2.ExecuteReader();
                Console.WriteLine(IndiceG + 1);
                Console.WriteLine(IndiceE + 1);
                Console.WriteLine(IndiceI + 1);
                

                while (registro.Read())
                {
                    relacionG.Add(registro["Genero"].ToString());
                }
                Console.WriteLine(relacionG[0]);
                registro.Close();
                for (IndiceG = 0; relacionG[IndiceG] != CBGenero.SelectedItem.ToString(); )
                {
                    IndiceG++;
                }
                Console.WriteLine(relacionG[IndiceG]);
                //
                //Crea la relacion entre el nombre del campo con el ID
                OracleCommand comando3 = new OracleCommand("Select ID,Editorial from Editorial", ora);
                OracleDataReader registro2 = comando3.ExecuteReader();

                while (registro2.Read())
                {
                    relacionE.Add(registro2["Editorial"].ToString());
                }

                registro2.Close();
                for (IndiceE = 0; relacionE[IndiceE] != CBEditorial.SelectedItem.ToString(); )
                {
                    IndiceE++;
                }
                //
                //Crea la relacion entre el nombre del campo con el ID
                OracleCommand comando4 = new OracleCommand("Select ID,Idioma from idioma", ora);
                OracleDataReader registro3 = comando4.ExecuteReader();

                while (registro3.Read())
                {
                    relacionI.Add(registro3["Idioma"].ToString());
                }

                registro3.Close();
                for (IndiceI = 0; relacionI[IndiceI] != CBIdioma.SelectedItem.ToString(); )
                {
                    IndiceI++;
                }
                //
                Console.WriteLine(relacionI[IndiceI]);

                //Manda el ID de la fila a los textBox
                
                OracleCommand comando = new OracleCommand("editar_libro", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("newid_libro", OracleType.Number).Value = id_fila;
                comando.Parameters.Add("newid_autor", OracleType.Number).Value = id_fila - 1;
                comando.Parameters.Add("nom_lib2", OracleType.VarChar).Value = textBox1.Text;
                comando.Parameters.Add("nom_aut2", OracleType.VarChar).Value = textBox2.Text;
                comando.Parameters.Add("ape_aut2", OracleType.VarChar).Value = textBox3.Text;
                comando.Parameters.Add("an2", OracleType.Number).Value = textBox4.Text;
                comando.Parameters.Add("gen2", OracleType.Number).Value = IndiceG + 1;
                comando.Parameters.Add("edito2", OracleType.VarChar).Value = IndiceE + 1;
                comando.Parameters.Add("idiom2", OracleType.VarChar).Value = IndiceI + 1;
                comando.ExecuteNonQuery();
                MessageBox.Show("Libro Actualizado");

            }
            catch (Exception)
            {
                MessageBox.Show("Algo salio mal");
            }
            ora.Close();
            Actualizar_vista();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = XEPDB1 ;  PASSWORD = PassPrestamo ; USER ID = USR_PRESTAMO");
            ora.Open();
            OracleCommand comando = new OracleCommand("eliminar_libro", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("id_libro2", OracleType.Number).Value = id_fila;
            comando.Parameters.Add("id_autor2", OracleType.Number).Value = id_fila - 1;
            comando.ExecuteNonQuery();
            MessageBox.Show("Libro Eliminado");
            ora.Close();
            Actualizar_vista();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 id_fila = Convert.ToInt32( this.dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception)
            {

                MessageBox.Show("No selecciono correctamente");
            }
        }
    }
}
