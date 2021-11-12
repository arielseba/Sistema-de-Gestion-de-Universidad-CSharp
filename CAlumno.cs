using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_2
{
    class CAlumno:CPersona
    {
        private string titulo;


        public CAlumno(ulong leg, string doc, string ape, string nom, string tit) : base(leg, doc, ape, nom)
        {
            this.titulo = tit;
        }
        public void setTitulo(string tit)
        {
            this.titulo = tit;
        }
        public string getTitulo()
        {
            return this.titulo;
        }

        public override string darDatos()
        {
            return base.darDatos() + " - TITULO: " + this.titulo;
        }
    }
}
