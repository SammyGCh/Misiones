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
        int idTelefono;
        [DataMember]
        string telefono;
        [DataMember]
        int Cuenta_idCuenta;

        public Telefono(int idTelefono, string telefono, int cuenta_idCuenta)
        {
            this.idTelefono = idTelefono;
            this.telefono = telefono;
            Cuenta_idCuenta = cuenta_idCuenta;
        }
    }
}
