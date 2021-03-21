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
        public int IdContrasena { get; set; }
        [DataMember]
        public string contrasena { get; set; }
        [DataMember]
        public int Cuenta_idCuenta { get; set; }
    }
}
