using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ServiciosCuentaUsuario
{
    class Conexion
    {
        public static MySqlConnection ObtenerConexion()
        {

            MySqlConnection conectar = new MySqlConnection("server=localhost; database=whats_cuentasdeusuario; Uid=root; pwd=Jogabonito20");

            conectar.Open();

            return conectar;
        }
    }
}
