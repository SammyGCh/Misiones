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
                    MySqlCommand comando3 = new MySqlCommand(string.Format(
                    "Select idCuenta, nombreUsuario, idFotoCuentaUsuario ,Genero_idGenero from Cuenta where idCuenta='{0}'", salida), Conexion.ObtenerConexion());
                    MySqlDataReader reader3 = comando3.ExecuteReader();

                    while (reader3.Read())
                    {
                        cuenta = new Cuenta(reader3.GetInt32(0), reader3.GetString(1), reader3.GetInt32(2), reader3.GetInt32(3));
                    }

                    MySqlCommand comando4 = new MySqlCommand(string.Format(
                    "Select correo from Correo where Cuenta_idCuenta='{0}'", salida), Conexion.ObtenerConexion());
                    MySqlDataReader reader4 = comando4.ExecuteReader();
                    while (reader4.Read())
                    {
                        correo = reader4.GetString(0);
                    }

                    MySqlCommand comando5 = new MySqlCommand(string.Format(
                    "Select contrasena from Contrasena where Cuenta_idCuenta='{0}'", salida), Conexion.ObtenerConexion());
                    MySqlDataReader reader5 = comando5.ExecuteReader();
                    while (reader5.Read())
                    {
                        contrasena = reader5.GetString(0);
                    }

                    MySqlCommand comando6 = new MySqlCommand(string.Format(
                    "Select telefono from Telefono where Cuenta_idCuenta='{0}'", salida), Conexion.ObtenerConexion());
                    MySqlDataReader reader6 = comando6.ExecuteReader();
                    while (reader6.Read())
                    {
                        telefono = reader6.GetString(0);
                    }

                    cuentaC = new CuentaCompleta(salida, cuenta.getNombreUsuario(), correo, contrasena, telefono, cuenta.getIdFotoCuentaUsuario(), cuenta.getGenero_idGenero());

                    return cuentaC;

                }
            }
            catch(Exception e)
            {
                return cuentaC;
            }
            return cuentaC;
        }

        public int ModificarUsuario(int idCuenta, string nombreUsuario, string correo, string contrasena, string telefono, int idFotoCuentaUsuario, int Genero_idGenero)
        {
            int retorno=0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
               "Update Cuenta set nombreUsuario='{0}', idFotoCuentaUsuario='{1}',Genero_idGenero='{2}' where idCuenta='{3}'", nombreUsuario, idFotoCuentaUsuario, Genero_idGenero, idCuenta), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();

                MySqlCommand comando1 = new MySqlCommand(string.Format(
                    "Update Correo set correo='{0}' where Cuenta_idCuenta='{1}'", correo, idCuenta), Conexion.ObtenerConexion());
                retorno = comando1.ExecuteNonQuery();

                MySqlCommand comando2 = new MySqlCommand(string.Format(
                    "Update Contrasena set contrasena='{0}' where Cuenta_idCuenta='{1}'", contrasena, idCuenta), Conexion.ObtenerConexion());
                retorno = comando2.ExecuteNonQuery();

                MySqlCommand comando3 = new MySqlCommand(string.Format(
                    "Update Telefono set telefono='{0}' where Cuenta_idCuenta='{1}'", telefono, idCuenta), Conexion.ObtenerConexion());
                retorno = comando3.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return retorno;
            }

            return retorno;
        }

        public int RegistrarUsuario(string nombreUsuario, string correo, string contrasena, string telefono, int idFotoCuentaUsuario, int Genero_idGenero)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
                "Insert into Cuenta (nombreUsuario,idFotoCuentaUsuario,Genero_idGenero) values ('{0}','{1}','{2}')", nombreUsuario, idFotoCuentaUsuario, Genero_idGenero), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();

                MySqlCommand comando2 = new MySqlCommand(string.Format(
                   "Select idCuenta from Cuenta where nombreUsuario='{0}'", nombreUsuario), Conexion.ObtenerConexion());
                MySqlDataReader reader2 = comando2.ExecuteReader();
                while (reader2.Read())
                {
                    idCuenta = reader2.GetInt32(0);
                }

                MySqlCommand comando3 = new MySqlCommand(string.Format(
                    "Insert into Correo (correo,Cuenta_idCuenta) values ('{0}','{1}')", correo, idCuenta), Conexion.ObtenerConexion());
                retorno = comando3.ExecuteNonQuery();

                MySqlCommand comando4 = new MySqlCommand(string.Format(
                   "Insert into Contrasena (contrasena,Cuenta_idCuenta) values ('{0}','{1}')", contrasena, idCuenta), Conexion.ObtenerConexion());
                retorno = comando4.ExecuteNonQuery();

                MySqlCommand comando5 = new MySqlCommand(string.Format(
                  "Insert into Telefono (telefono,Cuenta_idCuenta) values ('{0}','{1}')", telefono, idCuenta), Conexion.ObtenerConexion());
                retorno = comando5.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return retorno;
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
