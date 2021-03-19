using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosCuentaUsuario
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioCuentaUsuario
    {
        [OperationContract]
        CuentaCompleta IniciarSesion(string correo, string contrasena);

        [OperationContract]
        int RegistrarUsuario(string nombreUsuario,string correo, string contrasena, string telefono, int idFotoCuentaUsuario,int Genero_idGenero);

        [OperationContract]
        int ModificarUsuario(int idCuenta, string nombreUsuario, string correo, string contrasena, string telefono, int idFotoCuentaUsuario, int Genero_idGenero);
        [OperationContract]
        int validarExistencia(string nombreUsuario);
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "ServiciosCuentaUsuario.ContractType".
    [DataContract]
    public class Cuenta
    {
        [DataMember]
        int idCuenta;
        [DataMember]
        string nombreUsuario;
        [DataMember]
        int idFotoCuentaUsuario;
        [DataMember]
        int Genero_idGenero;

        public int getIdCuenta()
        {
            return idCuenta;
        }

        public string getNombreUsuario()
        {
            return nombreUsuario;
        }
        public int getIdFotoCuentaUsuario()
        {
            return idFotoCuentaUsuario;
        }
        public int getGenero_idGenero()
        {
            return Genero_idGenero;
        }
        public Cuenta(int idCuenta, string nombreUsuario, int idFotoCuentaUsuario, int genero_idGenero)
        {
            this.idCuenta = idCuenta;
            this.nombreUsuario = nombreUsuario;
            this.idFotoCuentaUsuario = idFotoCuentaUsuario;
            Genero_idGenero = genero_idGenero;
        }
        public Cuenta(int idCuenta, string nombreUsuario, int genero_idGenero)
        {
            this.idCuenta = idCuenta;
            this.nombreUsuario = nombreUsuario;
            Genero_idGenero = genero_idGenero;
        }
    }

    [DataContract]
    public class Contrasena
    {
        [DataMember]
        int idContrasena;
        [DataMember]
        string contrasena;
        [DataMember]
        int Cuenta_idCuenta;

        public Contrasena(int idContrasena, string contrasena, int cuenta_idCuenta)
        {
            this.idContrasena = idContrasena;
            this.contrasena = contrasena;
            Cuenta_idCuenta = cuenta_idCuenta;
        }
    }
    [DataContract]
    public class Correo
    {
        [DataMember]
        int idCorreo;
        [DataMember]
        string correo;
        [DataMember]
        int Cuenta_idCuenta;

        public Correo(int idCorreo, string correo, int cuenta_idCuenta)
        {
            this.idCorreo = idCorreo;
            this.correo = correo;
            Cuenta_idCuenta = cuenta_idCuenta;
        }
    }

    [DataContract]
    public class Telefono
    {
        [DataMember]
        int idTelefono;
        [DataMember]
        string telefono;
        [DataMember]
        int Cuenta_idCuenta;

        public Telefono(int idTelefono, string telefono, int cuenta_idCuenta)
        {
            this.idTelefono = idTelefono;
            this.telefono = telefono;
            Cuenta_idCuenta = cuenta_idCuenta;
        }
    }
    [DataContract]
    public class Genero
    {
        [DataMember]
        int idGenero;
        [DataMember]
        string genero;

        public Genero(int idGenero, string genero)
        {
            this.idGenero = idGenero;
            this.genero = genero;
           
        }
    }

    [DataContract]
    public class MensajeR
    {
        [DataMember]
        Boolean error;

        public MensajeR(bool error)
        {
            this.error = error;
        }
    }

    [DataContract]
    public class CuentaCompleta
    {
        [DataMember]
        int idCuenta;
        [DataMember]
        string nombreUsuario;
        [DataMember]
        string correo;
        [DataMember]
        string contrasena;
        [DataMember]
        string telefono;
        [DataMember]
        int idFotoCuentaUsuario;
        [DataMember]
        int Genero_idGenero;

        public CuentaCompleta(int idCuenta, string nombreUsuario, string correo, string contrasena, string telefono, int idFotoCuentaUsuario, int genero_idGenero)
        {
            this.idCuenta = idCuenta;
            this.nombreUsuario = nombreUsuario;
            this.correo = correo;
            this.contrasena = contrasena;
            this.telefono = telefono;
            this.idFotoCuentaUsuario = idFotoCuentaUsuario;
            Genero_idGenero = genero_idGenero;
        }
    }
}
