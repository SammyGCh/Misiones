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
        int idCuenta;
        [DataMember]
        string nombreUsuario;
        [DataMember]
        int idFotoCuentaUsuario;
        [DataMember]
        int Genero_idGenero;

        public int getIdCuenta()
        {
            return idCuenta;
        }

        public string getNombreUsuario()
        {
            return nombreUsuario;
        }
        public int getIdFotoCuentaUsuario()
        {
            return idFotoCuentaUsuario;
        }
        public int getGenero_idGenero()
        {
            return Genero_idGenero;
        }
        public Cuenta(int idCuenta, string nombreUsuario, int idFotoCuentaUsuario, int genero_idGenero)
        {
            this.idCuenta = idCuenta;
            this.nombreUsuario = nombreUsuario;
            this.idFotoCuentaUsuario = idFotoCuentaUsuario;
            Genero_idGenero = genero_idGenero;
        }
        
        public Cuenta(int idCuenta, string nombreUsuario, int genero_idGenero)
        {
            this.idCuenta = idCuenta;
            this.nombreUsuario = nombreUsuario;
            Genero_idGenero = genero_idGenero;
        }
    }
}
