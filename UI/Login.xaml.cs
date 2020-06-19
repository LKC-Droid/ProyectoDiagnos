using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Diagnos.Vistas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            fecha.Content = DateTime.Now.ToString("dddd dd");
            fecha2.Content = DateTime.Now.ToString("MMMMM");
            Año.Content = DateTime.Now.ToString("yyyy");
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
            rutId.Focus();
        }

        static string rp = "server=localhost; port=3306; userid=root; password=; database=clinica;";

        private void IniciarSesión()
        {
            MySqlConnection cn = new MySqlConnection(rp);

            try
            {
                cn.Open();
                MySqlDataReader rd = null;
                MySqlCommand cm = new MySqlCommand("SELECT * FROM `especialista` WHERE rut='"+ rutId.Text+ "' AND contrasena='"+pass.Password+"'", cn);
                rd = cm.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string user = rd.GetString(0);
                        string ps = rd.GetString(8);

                        Verificar(user, ps);
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectas");
                    pass.Password = "";
                }
                

            }
            catch (Exception e)
            {
                MessageBox.Show("No se ha podido conectar a la base de datos: "+e);
                throw;
            }
        }

        private void Verificar(String user, String ps)
        {
                if (rutId.Text == user & pass.Password == ps)
                {
                this.Hide();
                Main NuevaVentana = new Main(user);
                NuevaVentana.Show();
                }
                else
                {
                MessageBox.Show("Usuario o contraseña incorrectas"+user+ps);
                pass.Password = "";
            
                }

        }

        void timer_Tick(object sender, EventArgs e)
        {
            Hora.Content = DateTime.Now.ToString("HH:mm tt");
        }
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IniciarSesión();
        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                
                Button_Click(sender, e);
            }
        }

    }

}
