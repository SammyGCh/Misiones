using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosCuentaUsuario.Dominio
{
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
}
