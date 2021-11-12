using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_2
{
    class CDocente:CPersona
    {
        private PCategoria categoria;


        public CDocente(ulong leg, string doc, string ape,string nom, PCategoria cat) : base(leg, doc,ape, nom)
        {
            this.categoria =  cat;
        }
        public void setCategoria(PCategoria cat)
        {
            this.categoria = cat;
        }
        public PCategoria getCategoria()
        {
            return this.categoria;
        }

        public override string darDatos()
        {
            return base.darDatos() + " - CATEGORIA: " + this.categoria;
        }



    }
}
