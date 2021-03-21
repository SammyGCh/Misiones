using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosCuentaUsuario.Dominio
{
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "ServiciosCuentaUsuario.ContractType".
    [DataContract]
    public class Cuenta
    {
        [DataMember]
        public int IdCuenta { get; set; }
        [DataMember]
        public string NombreUsuario { get; set; }
        [DataMember]
        public int IdFotoCuentaUsuario { get; set; }
        [DataMember]
        public int Genero_idGenero { get; set; }
    }
}
