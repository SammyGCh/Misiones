using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosCuentaUsuario.Dominio
{
    
    [DataContract]
    public class CuentaCompleta
    {
        [DataMember]
        int idCuenta;
        [DataMember]
        string nombreUsuario;
        [DataMember]
        string correo;
        [DataMember]
        string contrasena;
        [DataMember]
        string telefono;
        [DataMember]
        int idFotoCuentaUsuario;
        [DataMember]
        int Genero_idGenero;

        public int IdCuenta 
        {
            get {return this.idCuenta;}
            set {this.idCuenta = value;}
        }

        public string NombreUsuario 
        {
            get {return this.nombreUsuario;}
            set {this.nombreUsuario = value;}
        }

        public int Correo 
        {
            get {return this.correo;}
            set {this.correo = value;}
        }

        public int Contrasena 
        {
            get {return this.contrasena;}
            set {this.contrasena = value;}
        }

        public int Telefono 
        {
            get {return this.telefono;}
            set {this.telefono = value;}
        }

        public int IdFotoCuentaUsuario 
        {
            get {return this.idFotoCuentaUsuario;}
            set {this.idFotoCuentaUsuario = value;}
        }

        public int Genero_idGenero 
        {
            get {return this.Genero_idGenero;}
            set {this.Genero_idGenero = value;}
        }

        public CuentaCompleta(int idCuenta, string nombreUsuario, string correo, string contrasena, string telefono)
        {
            this.idCuenta = idCuenta;
            this.nombreUsuario = nombreUsuario;
            this.correo = correo;
            this.contrasena = contrasena;
            this.telefono = telefono;
        }
    }
}
