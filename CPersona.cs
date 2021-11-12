using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_2
{
    class CPersona:IComparable
    {
        private ulong legajo;
        private string dni;
        private string apellido;
        private string nombre;

        public CPersona() : this(0, "Sin Registro", "Sin Registro", "Sin Registro")
        { }
        public CPersona(ulong leg,string doc, string ape ,string nom)
        {
            this.legajo = leg;
            this.dni = doc;
            this.apellido = ape;
            this.nombre = nom;
        }
        public void setLegajo(ulong leg)
        {
            this.legajo = leg;
        }
        public void setDNI(string doc)
        {
            this.dni = doc;
        }
        public void setApellido(string ape)
        {
            this.apellido = ape;
        }
        public void setNombre(string nom)
        {
            this.nombre = nom;
        }
        public ulong getLegajo()
        {
            return this.legajo;
        }
        public string getDNI()
        {
            return this.dni;
        }
        public string getApellido()
        {
            return this.apellido;
        }
        public string getNombre()
        {
            return this.nombre;
        }

        public virtual string darDatos()
        {
            return "\nLEGAJO: " + this.legajo + " - DNI: " + this.dni + " - NOMBRE: " + this.nombre + " - APELLIDO: " + this.apellido;
        }

        public int CompareTo(object persona)
        {
               return this.legajo.CompareTo(((CPersona)persona).getLegajo());
        }

        //propiedades
        public string Nombre
        {
            set { this.nombre = value; }
            get { return this.nombre; }
        }

        public ulong Legajo
        {
            set { this.legajo = value; }
            get { return this.legajo; }
        }

        public string Apellido
        {
            set { this.apellido = value; }
            get { return this.apellido; }
        }

        public string Dni
        {
            set { this.dni = value; }
            get { return this.dni; }
        }
    }
}
