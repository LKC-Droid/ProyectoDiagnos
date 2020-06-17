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

namespace Diagnos.Vistas
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        List<CitaMedica> citasAgendadas = new List<CitaMedica>();
        List<Paciente> listaPacientes = new List<Paciente>();
        public Main()
        {
            InitializeComponent();
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
            listas();
            cargarCitas();
        }

        public void listas()
        {
            


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

        public void cargarCitas()
        {
            Conectar cn = new Conectar();
            MySqlDataReader rd2 = cn.ConectarDB("select * from citamedica");

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

        void timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Content = DateTime.Now.ToString("HH:mm");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //Abrir la agenda de las citas ya registradas
            Pacientes.Visibility = Visibility.Hidden;
            Agenda.Visibility = Visibility.Visible;
            menu3.IsExpanded = false;
            menu2.IsExpanded = false;
            menu1.IsExpanded = false;
            menu.IsExpanded = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
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

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Conectar cn = new Conectar();
            cn.InsertarDB("INSERT INTO `usuarios`(`rut`, `pass`) VALUES (123,321)");
            

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                
        }
    }
}
