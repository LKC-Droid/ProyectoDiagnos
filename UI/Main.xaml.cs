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
using ProyectoDiagnos.Modelos.DTO;
using MySql.Data.MySqlClient;
using ProyectoDiagnos.Utils;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using Diagnos.Modelos.DTO;

namespace Diagnos.Vistas
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        List<CitaMedica> citasAgendadas = new List<CitaMedica>();
        List<Paciente> listaPacientesCitas = new List<Paciente>();
        List<Paciente> listaPacientes = new List<Paciente>();
        List<Especialista> listaEspecialistas = new List<Especialista>();
        public Main(string usuario,string tipo)
        {
            InitializeComponent();
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
            listas();
            TipoDeUsuario(usuario, tipo);
            CargarCombobox();
            cargarEsp();
        }

        /// <summary>
        /// Métodos para el proyecto
        /// </summary>

        private void TipoDeUsuario(string usuario, string tipo)
        {
            if (tipo == "Esp")
            {
                cargarCitas(usuario);
                Conectar cn = new Conectar();
                MySqlDataReader rd = cn.ConectarDB("SELECT * FROM `especialista` WHERE rut='" + usuario + "'");

                while (rd.Read())
                {
                    NombreDoctor.Content = rd.GetString(1) + " " + rd.GetString(2);
                }
            }
            else
            {
                cargarCitas2();
                Conectar cn = new Conectar();
                MySqlDataReader rd = cn.ConectarDB("SELECT * FROM `administrativo` WHERE rut='" + usuario + "'");

                while (rd.Read())
                {
                    NombreDoctor.Content = rd.GetString(1) + " " + rd.GetString(2);
                }
            }
        }

        private void cargarCitas2()
        {
            ListadeCitas.ItemsSource = null;
            citasAgendadas.Clear();
            Conectar cn = new Conectar();
            MySqlDataReader rd2 = cn.ConectarDB("select * from citamedica");

            if (rd2.HasRows)
            {
                while (rd2.Read())
                {
                    for (int i = 0; i < rd2.FieldCount; i++)
                    {
                        Paciente p = new Paciente();
                        MySqlDataReader rd = cn.ConectarDB("select * from paciente WHERE rut='" + rd2.GetString(2) + "'");

                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                for (int k = 0; k < rd.FieldCount; k++)
                                {
                                    p = new Paciente(rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(0), rd.GetDateTime(4));
                                    break;
                                }
                            }
                        }
                        CitaMedica cm = new CitaMedica(rd2.GetInt32(0), rd2.GetDateTime(1), rd2.GetString(2), rd2.GetString(3), rd2.GetString(4), p);
                        citasAgendadas.Add(cm);
                        break;
                    }
                }
            }
            ListadeCitas.ItemsSource = citasAgendadas;
        }

        public void listas()
        {
            ListadePacientes.ItemsSource = null;
            ListadePacientes.Items.Clear();
            listaPacientes.Clear();
           
            Conectar cn = new Conectar();
            MySqlDataReader rd = cn.ConectarDB("select * from paciente");

            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    for (int i = 0; i < rd.FieldCount; i++)
                    {
                        Paciente p = new Paciente(rd.GetString(1),rd.GetString(2),rd.GetString(3),rd.GetString(0),rd.GetDateTime(4));
                        listaPacientes.Add(p);
                        break;
                    }
                }
            }

            ListadePacientes.ItemsSource = listaPacientes;

        }

        public void cargarCitas(string rut_esp)
        {
            ListadeCitas.ItemsSource = null;
            citasAgendadas.Clear();
            Conectar cn = new Conectar();
            MySqlDataReader rd2 = cn.ConectarDB("select * from citamedica WHERE especialista_rut='"+rut_esp+"'");

            if (rd2.HasRows)
            {
                while (rd2.Read())
                {
                    for (int i = 0; i < rd2.FieldCount; i++)
                    {
                        Paciente p = new Paciente();
                        MySqlDataReader rd = cn.ConectarDB("select * from paciente WHERE rut='"+ rd2.GetString(2)+"'");

                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                for (int k = 0; k < rd.FieldCount; k++)
                                {
                                    p = new Paciente(rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(0), rd.GetDateTime(4));
                                    break;
                                }
                            }
                        }
                        CitaMedica cm = new CitaMedica(rd2.GetInt32(0), rd2.GetDateTime(1), rd2.GetString(2), rd2.GetString(3), rd2.GetString(4), p);
                       citasAgendadas.Add(cm);
                        break;
                    }
                }
            }

            
            ListadeCitas.ItemsSource = citasAgendadas;
        }

        private void CargarCombobox()
        {
            for (int i = 7; i < 23; i++)
            {
                ComboHora.Items.Add(i);
            }

            for (int i = 0; i < 12; i++)
            {
                ComboMin.Items.Add(i*5);
            }

            ComboHora.SelectedIndex = 0;
            ComboMin.SelectedIndex = 0;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Content = DateTime.Now.ToString("HH:mm");
        }
        //##############################################################################################################################################

        //Menu principal
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //Abrir la agenda de las citas ya registradas
            AñadirPaciente.Visibility = Visibility.Hidden;
            Pacientes.Visibility = Visibility.Hidden;
            Agenda.Visibility = Visibility.Visible;
            Registro_de_cita.Visibility = Visibility.Hidden;
            Citas.Visibility = Visibility.Visible;
            menu3.IsExpanded = false;
            menu2.IsExpanded = false;
            menu1.IsExpanded = false;
            menu.IsExpanded = false;
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Abrir formulario de registro para pacientes
            menu3.IsExpanded = false;
            menu2.IsExpanded = false;
            menu1.IsExpanded = false;
            menu.IsExpanded = false;

            Agenda.Visibility = Visibility.Hidden;
            Pacientes.Visibility = Visibility.Visible;
            AñadirPaciente.Visibility = Visibility.Visible;
            ListaDePacientes.Visibility = Visibility.Hidden;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Abrir lista de pacientes

            menu3.IsExpanded = false;
            menu2.IsExpanded = false;
            menu1.IsExpanded = false;
            menu.IsExpanded = false;

            AñadirPaciente.Visibility = Visibility.Hidden;
            Agenda.Visibility = Visibility.Hidden;
            Pacientes.Visibility = Visibility.Visible;
            ListaDePacientes.Visibility = Visibility.Visible;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Pacientes.Visibility = Visibility.Hidden;
            Agenda.Visibility = Visibility.Visible;
            menu3.IsExpanded = false;
            menu2.IsExpanded = false;
            menu1.IsExpanded = false;
            menu.IsExpanded = false;
            
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Conectar cn = new Conectar();
            cn.InsertarDB("INSERT INTO `usuarios`(`rut`, `pass`) VALUES (123,321)");
            

        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login NuevaVentana = new Login();
            NuevaVentana.Show();
        }

        //###################################################################################

        //Menú pacientes
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                
        }

        private void RegistrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            Conectar cn = new Conectar();
            try
            {
                string date = IgFechaNac.SelectedDate.Value.ToString("yyyy-MM-dd");
                MySqlDataReader rd = cn.ConectarDB("INSERT INTO `paciente`(`rut`, `nombre`, `apellidopaterno`, `apellidomaterno`, `fechanac`, `telefono`) VALUES ('"+IgRut.Text+"','"+IgNombre.Text+"','"+IgAP.Text+"','"+IgAM.Text+"','"+date+"','"+IgTelefono.Text+"')");
                MessageBox.Show("Se ha agregado correctamente al paciente");

                AñadirPaciente.Visibility = Visibility.Hidden;
                Agenda.Visibility = Visibility.Hidden;
                Pacientes.Visibility = Visibility.Visible;
                ListaDePacientes.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
                throw;
            }
            
        }

        private void ActualizarLista_Click(object sender, RoutedEventArgs e)
        {
            listas();
        }

        private void ListadePacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9' || c > '-' || c > '.')
                    return false;
            }

            return true;
        }

        private void EliminarPaciente_Click(object sender, RoutedEventArgs e)
        {
            string user = ListadePacientes.SelectedItem.ToString();
            string rut = System.Text.RegularExpressions.Regex.Replace(user, "[^0-9-.]", "");

            Conectar cn = new Conectar();
            try
            {
                DialogResult result = new DialogResult();

                result = MessageBox.Show("¿Desea eliminar al paciente?", "Eliminar Paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    cn.ConectarDB("DELETE FROM `paciente` WHERE rut='" + rut+"'");
                    MessageBox.Show("Se ha eliminado el paciente correctamente", "Exito!");
                    listas();
                    AñadirPaciente.Visibility = Visibility.Hidden;
                    Agenda.Visibility = Visibility.Hidden;
                    Pacientes.Visibility = Visibility.Visible;
                    ListaDePacientes.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }

        }

      //######################################################################################

        //Menú de citas

        private void BotonNuevaCita_Click_1(object sender, RoutedEventArgs e)
        {
            AñadirPaciente.Visibility = Visibility.Hidden;
            Agenda.Visibility = Visibility.Visible;
            Registro_de_cita.Visibility = Visibility.Visible;
            Citas.Visibility = Visibility.Hidden;
            
        }


        private void CitaBuscarPaciente_KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            listaPacientesCitas.Clear();
            string buscar = CitaBuscarPaciente.Text;
                Conectar cn = new Conectar();
                MySqlDataReader rd = cn.ConectarDB("SELECT * FROM `paciente` WHERE CONCAT_WS(' ', nombre, apellidopaterno) LIKE '%" + buscar + "%' OR rut LIKE '%" + buscar + "%' ORDER BY nombre");
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        for (int i = 0; i < rd.FieldCount; i++)
                        {
                            Paciente p = new Paciente(rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(0), rd.GetDateTime(4));
                            listaPacientesCitas.Add(p);
                            break;
                        }
                    }
                }

            if (listaPacientesCitas.Count == 0)
            {
                
            }
            else
            {
                SelPaciente.ItemsSource = null;
                SelPaciente.ItemsSource = listaPacientesCitas;
            }
                      
            
        }

        private void cargarEsp()
        {
            Conectar cn = new Conectar();
            MySqlDataReader rd = cn.ConectarDB("SELECT * FROM `especialista`");

            while (rd.Read())
            {
                for (int i = 0; i < rd.FieldCount; i++)
                {
                    Especialista esp = new Especialista(rd.GetString(0), rd.GetString(1), rd.GetString(2));
                    listaEspecialistas.Add(esp);
                    break;
                }
            }
            SelPaciente_Copy.ItemsSource = listaEspecialistas;
        }

        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            listaPacientes.Clear();
            string buscar = BuscarPaciente.Text;
            Conectar cn = new Conectar();
            MySqlDataReader rd = cn.ConectarDB("SELECT * FROM `paciente` WHERE CONCAT_WS(' ', nombre, apellidopaterno) LIKE '%" + buscar + "%' OR rut LIKE '%" + buscar + "%' ORDER BY nombre");
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    for (int i = 0; i < rd.FieldCount; i++)
                    {
                        Paciente p = new Paciente(rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(0), rd.GetDateTime(4));
                        listaPacientes.Add(p);
                        break;
                    }
                }
            }

            if (listaPacientes.Count == 0)
            {

            }
            else
            {
                ListadePacientes.ItemsSource = null;
                ListadePacientes.ItemsSource = listaPacientes;
            }
        }
        


        private void RegistrarCita_Click(object sender, RoutedEventArgs e)
        {
            string userpac = PacienteEscogido.Content.ToString();
            string rutpac = System.Text.RegularExpressions.Regex.Replace(userpac, "[^0-9-.]", "");

            string useresp = EspecialistaEscogido.Content.ToString();
            string rutesp = System.Text.RegularExpressions.Regex.Replace(useresp, "[^0-9-.]", "");

            string fecha = FechaCita.SelectedDate.Value.ToString("yyyy-MM-dd") + " " + ComboHora.SelectedItem.ToString() + ":" + ComboMin.SelectedItem.ToString() + ":" + "00";

            Conectar cn = new Conectar();
            try
            {
            MySqlDataReader rd = cn.ConectarDB("INSERT INTO `citamedica`(`fechacita`, `paciente_rut`, `administrativo_rut`, `especialista_rut`) VALUES ('"+fecha+"','"+rutpac+"','123-4','"+rutesp+"')");
                MessageBox.Show("Se ha agregado la cita correctamente","Exito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        private void SeleccionarPacienteCita(object sender, RoutedEventArgs e)
        {
            string user = SelPaciente.SelectedItem.ToString();
            string rutpac = System.Text.RegularExpressions.Regex.Replace(user, "[^0-9-.]", "");
            PacienteEscogido.Content = "Se ha seleccionado: "+user;
            

        }

        private void SeleccionarEspCita(object sender, RoutedEventArgs e)
        {
            string user = SelPaciente_Copy.SelectedItem.ToString();
            string rutesp = System.Text.RegularExpressions.Regex.Replace(user, "[^0-9-.]", "");
            EspecialistaEscogido.Content = "Se ha seleccionado: " + user;
            
        }
    }
}
