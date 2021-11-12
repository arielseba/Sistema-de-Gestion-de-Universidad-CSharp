using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_2
{
    class CUniversidad
    {
        private ArrayList listadoAlumnos;
        private ArrayList listadoDocentes;
        private ArrayList listadoComisiones;
        
        public CUniversidad()
        {
            this.listadoAlumnos = new ArrayList();
            this.listadoDocentes = new ArrayList();
            this.listadoComisiones = new ArrayList();
        }
        //Metodo para buscar alumno en la universidad
        public CAlumno Busca_Alumno_Universidad(ulong leg)
        {
            foreach (CAlumno aux in this.listadoAlumnos)
            {
                if (aux.getLegajo() == leg)
                {
                    return aux;
                }
            }
            return null;
        }

        //Metodo para registrar alumno en la universidad
        public bool RegistrarAlumnos(ulong leg, string doc, string ape, string nom, string tit)
        {
            CAlumno aux = this.Busca_Alumno_Universidad(leg);
            if (aux == null)
            {
                this.listadoAlumnos.Add(new CAlumno(leg, doc,ape,nom,tit));
                return true;
            }
            return false;

        }

        //Busca docente Universidad
        public CDocente Busca_Docente_Universidad(ulong leg)
        {
            foreach (CDocente aux in this.listadoDocentes)
            {
                if (aux.getLegajo() == leg)
                {
                    return aux;
                }
            }
            return null;
        }

        //Registra docente Universidad
        public bool RegistrarDocente(ulong leg, string doc, string ape, string nom, PCategoria cat)
        {
            CDocente aux = this.Busca_Docente_Universidad(leg);
            if (aux == null)
            {
                this.listadoDocentes.Add(new CDocente(leg, doc, ape, nom, cat));
                return true;
            }
            return false;

        }
        
        //Ordenamiento de Arrays
        public void Ordenar()
        {
            this.listadoAlumnos.Sort();
            this.listadoDocentes.Sort();
            this.listadoComisiones.Sort();
        }

        //Devuelve listado alumnos de la universidad
        public string DatosAlumnos()
        {
           string lista = "";
           foreach (CAlumno aux in this.listadoAlumnos)
           {
              lista += aux.darDatos();
              lista += "\n";
           }
           return lista;
            
        }

        //Devuelve listado de docentes de la Universidad
        public string DatosDocentes()
        {
            string lista = "";
            foreach (CDocente aux in this.listadoDocentes)
            {
                lista += aux.darDatos();
                lista += "\n";
            }
            return lista;

        }
        //Busca si la comision existe en la universidad
        public CComision Busca_Comision_Universidad(string cod)
        {
            foreach (CComision aux in this.listadoComisiones)
            {
                if (aux.getCodigo() == cod)
                {
                    return aux;
                }
            }
            return null;
        }

        //Registra una comision en la universidad
        public bool RegistrarComisiones(string cod, PTurno tur)
        {
            CComision aux = this.Busca_Comision_Universidad(cod);
            if (aux == null)
            {
                this.listadoComisiones.Add(new CComision(cod, tur));
                return true;
            }
            return false;

        }

        //Devuelve los datos de todas las comisiones existentes en la universidad
        public string DatosComisiones()
        {
            string lista = "";
            foreach (CComision aux in this.listadoComisiones)
            {
                lista += aux.DarDatos();
                lista += "\n";
            }
            return lista;

        }

        //Asigna un alumno a una comision
        public bool RegistrarAlumnosComisiones(ulong leg, string cod)
        {
            CAlumno alumno = this.Busca_Alumno_Universidad(leg);

            if (alumno != null)
            {
                CComision comision = this.Busca_Comision_Universidad(cod);
                if(comision!=null)
                {
                    comision.RegistrarAlumnosComision(alumno,leg);
                    return true;
                }
                
            }
            return false;
        }

        //Asigna un docente a una comision
        public bool RegistrarDocentesComisiones(ulong leg, string cod)
        {
            CDocente docente = this.Busca_Docente_Universidad(leg);

            if (docente != null)
            {
                CComision comision = this.Busca_Comision_Universidad(cod);
                if (comision != null)
                {
                    comision.RegistrarDocentesComision(docente, leg);
                    return true;
                }
            }
            return false;
        }

        public bool Remover_Alumno(string cod, ulong leg)
        {
            CComision comision = this.Busca_Comision_Universidad(cod);

            if (comision != null)
            {
                comision.Remover_Alumno(leg);
                return true;
            }
            return false;
        }

        public bool Remover_Alumno(ulong leg) // usamos polimorfismo ya que para eliminar al alumno de la universidad solo necesitamos su legajo.
        {
            this.RemoverTodas_Alumno(leg);
            CAlumno aux = this.Busca_Alumno_Universidad(leg);
            if (aux!= null)
            {
                this.listadoAlumnos.Remove(aux);
                return true;
            }
            return false;

        }

        public bool Remover_Docente(string cod, ulong leg)
        {
            CComision comision = this.Busca_Comision_Universidad(cod);

            if (comision != null)
            {
                comision.Remover_Docente(leg);
                return true;
            }
            return false;
        }

        public bool Remover_Docente(ulong leg) 
        {
            this.RemoverTodas_Docente(leg);
            CDocente aux = this.Busca_Docente_Universidad(leg);
            if (aux != null)
            {
                this.listadoDocentes.Remove(aux);
                return true;
            }
            return false;

        }


        public void RemoverTodas_Alumno(ulong leg) //recorremos todas las comisiones en busca del alumno para sacarlos de todas sin tener que dar todos los codigos, ya que puede estar en mas de una
        {
            CAlumno alum = this.Busca_Alumno_Universidad(leg);
            if (alum != null)
            {
                foreach (CComision comi in this.listadoComisiones)
                {
                    CAlumno alum2 = comi.Busca_Alumno_Comision(leg);
                    if (alum2 != null)
                    {
                        comi.Remover_Alumno(leg);
                    }
                }
            }
            else
            {
                return;
            }
        }

        public void RemoverTodas_Docente(ulong leg) 
        {
            CDocente docente = this.Busca_Docente_Universidad(leg);
             if (docente != null)
             {
                 foreach (CComision comi in this.listadoComisiones)
                 {
                    CDocente docente2 = comi.Busca_Docente_Comision(leg);
                    if (docente2 != null)
                    {
                        comi.Remover_Docente(leg);
                    }
                 }
             }
             else
             {
                return;
             }
        }

        public string Alumno_O_Docente (ulong leg)
        {
            
            CAlumno alum = this.Busca_Alumno_Universidad(leg);
            CDocente docente = this.Busca_Docente_Universidad(leg);
            string datos = "";
            if (alum != null)
            {
                foreach (CComision comi in this.listadoComisiones)
                {
                    CAlumno alum2 = comi.Busca_Alumno_Comision(leg);
                    if (alum2 != null)
                    {
                        datos += comi.DarDatos();
                        datos += "\n";
                    }                 
                }

                return ("El legajo ingresado corresponde a un alumno: \n" + alum.darDatos() + "\n Y se encuentra en las comisiones: \n" + datos);
            }
            
            else if (docente != null)
            {
                foreach (CComision comi in this.listadoComisiones)
                {
                    CDocente docen2 = comi.Busca_Docente_Comision(leg);
                    if (docen2 != null)
                    {
                        datos += comi.DarDatos();
                        datos += "\n";
                    }
                }
                return ("El legajo ingresado corresponde a un docente: \n" + docente.darDatos() + "\nY se encuentra en las comisiones: \n" + datos);
            }
            else
            {
                return ("\nEl legajo no esta registrado en la universidad");
            }
        }




    }
}
