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
        int idGenero;
        [DataMember]
        string genero;

        public Genero(int idGenero, string genero)
        {
            this.idGenero = idGenero;
            this.genero = genero;
           
        }
    }
}
