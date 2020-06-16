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

        static string rp = "server='localhost';port='3606';userid='root';password='';database='clinica';";

        private void ConectarDB()
        {
            MySqlConnection cn = new MySqlConnection(rp);

            try
            {
                cn.Open();
                MySqlDataReader rd = null;

            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido conectar a la base de datos");
                throw;
            }
        }

    }

    

}
