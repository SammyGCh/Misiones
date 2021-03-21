using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosCuentaUsuario.Dominio
{

    [DataContract]
    public class Telefono
    {
        [DataMember]
        public int IdTelefono { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public int Cuenta_idCuenta { get; set; }
    }
}
