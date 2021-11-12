using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_2
{
    class CComision: IComparable
    {
        private string codigo;
        private PTurno turno;

        private ArrayList listadoAlumnosComisiones;
        private ArrayList listadoDocentesComisiones;
        

        public CComision (string cod, PTurno tur)
        {
            this.codigo = cod;
            this.turno = tur;
            this.listadoAlumnosComisiones = new ArrayList();
            this.listadoDocentesComisiones = new ArrayList();

        }

        public void setCodigo(string cod)
        {
            this.codigo = cod;
        }
        public string getCodigo()
        {
            return this.codigo;
        }
        public void setTurno(PTurno tur)
        {
            this.turno = tur;
        }
        public PTurno getTurno()
        {
            return this.turno;
        }

        public string DarDatos()
        {
            return "\nCODIGO: " + this.codigo + " - TURNO: " + this.turno;
        }
        public int CompareTo(object comision)
        {
            return this.codigo.CompareTo(((CComision)comision).getCodigo());
        }

        public CAlumno Busca_Alumno_Comision(ulong leg)
        {
            foreach (CAlumno aux in this.listadoAlumnosComisiones)
            {
                if (aux.getLegajo() == leg)
                {
                    return aux;
                }
            }
            return null;
        }

        public CDocente Busca_Docente_Comision(ulong leg)
        {
            foreach (CDocente aux in this.listadoDocentesComisiones)
            {
                if (aux.getLegajo() == leg)
                {
                    return aux;
                }
            }
            return null;
        }

        public bool RegistrarAlumnosComision(CAlumno alum,ulong leg)
        {
            CAlumno aux = this.Busca_Alumno_Comision(leg);

            if(aux==null)
            {
                this.listadoAlumnosComisiones.Add(alum);
                return true;
            }
            return false;
               

        }
        public string DatosAlumnosComisiones()
        {
            string lista = "";
            this.DarDatos();
            foreach (CAlumno aux in this.listadoAlumnosComisiones)
            {
               
                lista += aux.darDatos();
                lista += "\n";
            }
            return lista;

        }

        public bool RegistrarDocentesComision(CDocente docente, ulong leg)
        {
            CDocente aux = this.Busca_Docente_Comision(leg);

            if (aux == null)
            {
                this.listadoDocentesComisiones.Add(docente);
                return true;
            }
            return false;


        }
        public string DatosDocentesComisiones()
        {
            string lista = "";
            this.DarDatos();
            foreach (CDocente aux in this.listadoDocentesComisiones)
            {
                
                lista += aux.darDatos();
                lista += "\n";
            }
            return lista;

        }

        public bool Remover_Alumno(ulong leg)
        {
            CAlumno aux = this.Busca_Alumno_Comision(leg);

            if (aux != null)
            {
                this.listadoAlumnosComisiones.Remove(aux);
                return true;
            }
            return false;
        }

        public bool Remover_Docente(ulong leg)
        {
            CDocente aux = this.Busca_Docente_Comision(leg);

            if (aux != null)
            {
                this.listadoDocentesComisiones.Remove(aux);
                return true;
            }
            return false;
        }

       
    }
}
