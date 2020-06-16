using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ProyectoDiagnos.Utils
{

    class Conectar
    {

        static string rp = "server=localhost; port=3306; userid=root; password=; database=clinica;";

        public MySqlDataReader ConectarDB(String query)
        {
            MySqlConnection cn = new MySqlConnection(rp);

            try
            {
                cn.Open();
                MySqlDataReader rd = null;
                MySqlCommand cm = new MySqlCommand(query, cn);
                rd = cm.ExecuteReader();
                return rd;

            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido conectar a la base de datos");
                throw;
            }
        }

    }

    

}
