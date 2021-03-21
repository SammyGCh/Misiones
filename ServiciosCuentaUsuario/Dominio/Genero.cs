using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosCuentaUsuario.Dominio
{
    [DataContract]
    public class Genero
    {
        [DataMember]
        public int IdGenero { get; set; }
        [DataMember]
        public string genero { get; set; }
    }
}
