using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosCuentaUsuario.Dominio
{
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
}
