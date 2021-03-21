using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace ServiciosCuentaUsuario
{
   
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ServicioCuentaUsuario : IServicioCuentaUsuario
    {
        int salida;
        int salida2;
        Cuenta cuenta;
        int idCuenta;
        string telefono;
        CuentaCompleta cuentaC;

        public CuentaCompleta IniciarSesion(string correo, string contrasena)
        {
            cuentaC = null;

            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
                "Select Cuenta_idCuenta from Contrasena where contrasena='{0}'", contrasena), Conexion.ObtenerConexion());
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    salida = reader.GetInt32(0);
                }

                MySqlCommand comando2 = new MySqlCommand(string.Format(
                    "Select Cuenta_idCuenta from Correo where correo='{0}'", correo), Conexion.ObtenerConexion());
                MySqlDataReader reader2 = comando2.ExecuteReader();
                while (reader2.Read())
                {
                    salida2 = reader2.GetInt32(0);
                }

                if (salida == salida2)
                {
                    cuentaC = ObtenerCuenta(salida);
                }
            }
            catch(Exception e)
            {

            }

            return cuentaC;
        }

        public Cuenta ObtenerCuenta(int idCuenta) 
        {
            cuenta = null;
            MySqlCommand comando3 = new MySqlCommand(string.Format(
                    "Select idCuenta, nombreUsuario, idFotoCuentaUsuario ,Genero_idGenero from Cuenta where idCuenta='{0}'", idCuenta), Conexion.ObtenerConexion());
            MySqlDataReader reader3 = comando3.ExecuteReader();

            while (reader3.Read())
            {
                cuenta = new CuentaCompleta 
                {
                  IdCuenta = reader3.GetInt32(0),
                  NombreUsuario = reader3.GetString(1),
                  IdFotoCuentaUsuario = reader3.GetInt32(2),
                  Genero_idGenero = reader3.GetInt32(3))
                };
            }

            cuenta.Correo = ObtenerCorreoDeCuenta(idCuenta);
            cuenta.Contrasena = ObtenerContrasenaDeCuenta(idCuenta);
            cuenta.Telefono = ObtenerTelefonoDeCuenta(idCuenta);

            return cuenta;
        }

        public string ObtenerCorreoDeCuenta(int idCuenta)
        {
            string correo = "";

            MySqlCommand comando4 = new MySqlCommand(string.Format(
            "Select correo from Correo where Cuenta_idCuenta='{0}'", idCuenta), Conexion.ObtenerConexion());
            MySqlDataReader reader4 = comando4.ExecuteReader();
            while (reader4.Read())
            {
                correo = reader4.GetString(0);
            }

            return correo;
        }

        public string ObtenerContrasenaDeCuenta(int idCuenta)
        {
            string contrasena = "";
            MySqlCommand comando5 = new MySqlCommand(string.Format(
            "Select contrasena from Contrasena where Cuenta_idCuenta='{0}'", idCuenta), Conexion.ObtenerConexion());
            MySqlDataReader reader5 = comando5.ExecuteReader();
            while (reader5.Read())
            {
                contrasena = reader5.GetString(0);
            }

            return contrasena;
        }

        public string ObtenerTelefonoDeCuenta(int idCuenta)
        {
            string telefono = "";

            MySqlCommand comando6 = new MySqlCommand(string.Format(
            "Select telefono from Telefono where Cuenta_idCuenta='{0}'", idCuenta), Conexion.ObtenerConexion());
            MySqlDataReader reader6 = comando6.ExecuteReader();
            while (reader6.Read())
            {
                telefono = reader6.GetString(0);
            }

            return telefono;
        }

        public int ModificarUsuario(CuentaCompleta cuenta)
        {
            int retorno=0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
               "Update Cuenta set nombreUsuario='{0}', idFotoCuentaUsuario='{1}',Genero_idGenero='{2}' where idCuenta='{3}'", cuenta.NombreUsuario, cuenta.IdFotoCuentaUsuario, cuenta.Genero_idGenero, cuenta.IdCuenta), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();

                MySqlCommand comando1 = new MySqlCommand(string.Format(
                    "Update Correo set correo='{0}' where Cuenta_idCuenta='{1}'", cuenta.Correo, cuenta.IdCuenta), Conexion.ObtenerConexion());
                retorno = comando1.ExecuteNonQuery();

                MySqlCommand comando2 = new MySqlCommand(string.Format(
                    "Update Contrasena set contrasena='{0}' where Cuenta_idCuenta='{1}'", cuenta.Contrasena, cuenta.IdCuenta), Conexion.ObtenerConexion());
                retorno = comando2.ExecuteNonQuery();

                MySqlCommand comando3 = new MySqlCommand(string.Format(
                    "Update Telefono set telefono='{0}' where Cuenta_idCuenta='{1}'", cuenta.Telefono, cuenta.IdCuenta), Conexion.ObtenerConexion());
                retorno = comando3.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return retorno;
        }

        public int RegistrarUsuario(CuentaCompleta cuenta)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
                "Insert into Cuenta (nombreUsuario,idFotoCuentaUsuario,Genero_idGenero) values ('{0}','{1}','{2}')", cuenta.NombreUsuario, cuenta.IdFotoCuentaUsuario, cuenta.Genero_idGenero), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();

                MySqlCommand comando2 = new MySqlCommand(string.Format(
                   "Select idCuenta from Cuenta where nombreUsuario='{0}'", cuenta.NombreUsuario), Conexion.ObtenerConexion());
                MySqlDataReader reader2 = comando2.ExecuteReader();
                while (reader2.Read())
                {
                    idCuenta = reader2.GetInt32(0);
                }

                MySqlCommand comando3 = new MySqlCommand(string.Format(
                    "Insert into Correo (correo,Cuenta_idCuenta) values ('{0}','{1}')", cuenta.Correo, cuenta.IdCuenta), Conexion.ObtenerConexion());
                retorno = comando3.ExecuteNonQuery();

                MySqlCommand comando4 = new MySqlCommand(string.Format(
                   "Insert into Contrasena (contrasena,Cuenta_idCuenta) values ('{0}','{1}')", cuenta.Contrasena, cuenta.IdCuenta), Conexion.ObtenerConexion());
                retorno = comando4.ExecuteNonQuery();

                MySqlCommand comando5 = new MySqlCommand(string.Format(
                  "Insert into Telefono (telefono,Cuenta_idCuenta) values ('{0}','{1}')", cuenta.Telefono, cuenta.IdCuenta), Conexion.ObtenerConexion());
                retorno = comando5.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return retorno;
        }

        public int validarExistencia(string nombreUsuario)
        {
            int retorno=0;
            MySqlCommand comando2 = new MySqlCommand(string.Format(
               "Select nombreUsuario from Cuenta where nombreUsuario='{0}'", nombreUsuario), Conexion.ObtenerConexion());
            MySqlDataReader reader2 = comando2.ExecuteReader();
            while (reader2.Read())
            {
                if (nombreUsuario.Equals(reader2.GetString(0)))
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }
            }

            return retorno;
        }
    }
}
