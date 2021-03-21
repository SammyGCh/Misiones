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
        public int IdCorreo { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public int Cuenta_idCuenta { get; set; }
    }
}
