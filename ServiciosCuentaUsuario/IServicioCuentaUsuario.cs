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
        int RegistrarUsuario(CuentaCompleta cuenta);

        [OperationContract]
        int ModificarUsuario(CuentaCompleta cuenta);
        [OperationContract]
        int validarExistencia(string nombreUsuario);
    }
}
