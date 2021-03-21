using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosCuentaUsuario.Dominio
{

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
}
