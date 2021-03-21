using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosCuentaUsuario.Dominio
{
    
    [DataContract]
    public class CuentaCompleta : Cuenta
    {

        [DataMember]
        public string Correo 
        {
            get;
            set;
        }

        [DataMember]
        public string Contrasena 
        {
            get;
            set;
        }

        [DataMember]
        public string Telefono 
        {
            get;
            set;
        }
    }
}
