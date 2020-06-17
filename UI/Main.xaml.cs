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
        public Main()
        {
            InitializeComponent();
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
            lista();
        }

        public void lista()
        {
            List<CitaMedica> citasAgendadas = new List<CitaMedica>();
            List<Paciente> listaPacientes = new List<Paciente>();
            Paciente p = new Paciente("Aquiles","pinto","casas","14.262.926-8");
            Paciente p2 = new Paciente("Elvis", "tek", "delgado", "12.265.741.-5");
            Paciente p3 = new Paciente("Armando", "Estaban", "Quito", "10.178.885-k");
            DateTime tm = new DateTime(2020,05,12,14,25,00);
            DateTime tm2 = DateTime.Now;
            CitaMedica ct = new CitaMedica(1, tm, p, "Yellow");
            CitaMedica ct2 = new CitaMedica(2, tm2, p2, "Green");

            citasAgendadas.Add(ct);
            citasAgendadas.Add(ct2);

            listaPacientes.Add(p);
            listaPacientes.Add(p2);
            listaPacientes.Add(p3);

            ListadePacientes.ItemsSource = listaPacientes;
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
            

            lista();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                
        }
    }
}
