using System;

namespace PARCIAL_2
{
    class CControladora
    {
        static void Main()
        {
            string legajo, apellido, nombre, dni, titulo,C;
          
            ulong leg;
            char opcion;
            CUniversidad Universidad = new CUniversidad();
            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);
                
                switch (opcion)
                {

                    case 'A': //Registrar un Docente en la Universidad.
                        legajo = CInterfaz.PedirDato("Legajo del Docente ");
                        apellido = CInterfaz.PedirDato("Apellido del Docente ");
                        nombre = CInterfaz.PedirDato("Nombre del Docente ");
                        dni = CInterfaz.PedirDato("DNI del Docente ");
                        C = (CInterfaz.PedirDato("[T] Profesor Titular - [A] Profesor Adjunto - [J] Jefe de Trabajos Practios - [P] Ayudante de Trabajos Practicos"));
                        PCategoria cat;
                        if (C.ToUpper() == "T") cat = PCategoria.ProfesorTitular;
                        else if (C.ToUpper() == "A") cat = PCategoria.ProfesorAdjunto;
                        else if (C.ToUpper() == "J") cat = PCategoria.JefeDeTrabajosPracticos;
                        else cat = PCategoria.AyudanteDeTrabajosPracticos;
                        leg = Convert.ToUInt64(legajo);

                        if (Universidad.RegistrarDocente(leg, dni, apellido, nombre, cat))
                        {
                            CInterfaz.MostrarInfo("Docente registrado con éxito");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("El Docente no fue registrado. Vuelva a intentarlo");
                        }
                        break;

                                        
                    case 'B': //Listar Docentes de la Universidad.
                        Universidad.Ordenar();
                        CInterfaz.MostrarInfo(Universidad.DatosDocentes());
                        break;


                    case 'C'://Registrar Alumno en Universidad.
                        legajo= CInterfaz.PedirDato("Legajo del Alumno ");
                        apellido = CInterfaz.PedirDato("Apellido del Alumno ");
                        nombre = CInterfaz.PedirDato("Nombre del Alumno ");
                        dni = CInterfaz.PedirDato("DNI del Alumno ");
                        titulo = CInterfaz.PedirDato("Titulo del Alumno ");
                        leg = Convert.ToUInt64(legajo);
                        
                        if (Universidad.RegistrarAlumnos(leg, dni, apellido, nombre, titulo)) 
                        {
                            CInterfaz.MostrarInfo("Alumno registrado con éxito");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("El Alumno no fue registrado. Vuelva a intentarlo");
                        }
                        break;


                    case 'D'://Listar Alumnos de la Universidad.
                        Universidad.Ordenar();
                        CInterfaz.MostrarInfo(Universidad.DatosAlumnos());
                        break;


                    case 'E'://Registrar Comisiones de la Universidad
                        string codigo = CInterfaz.PedirDato("Codigo de la Comision ");
                        C = (CInterfaz.PedirDato("[M] Turno Mañana - [T] Turno Tarde - [N] Turno Noche"));
                        PTurno turno;
                        if (C.ToUpper() == "M") turno = PTurno.Mañana;
                        else if (C.ToUpper() == "T") turno = PTurno.Tarde;
                        else turno = PTurno.Noche;

                        if (Universidad.RegistrarComisiones(codigo,turno))
                        {
                            CInterfaz.MostrarInfo("Comision registrada con éxito");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("La Comision no fue registrada. Vuelva a intentarlo");
                        }
                        break;


                    case 'F'://Listar Comisiones de la Universidad.
                        Universidad.Ordenar();
                        CInterfaz.MostrarInfo(Universidad.DatosComisiones());
                        break;


                    case 'G'://Asignar un Alumno a una Comision.
                        codigo = CInterfaz.PedirDato("Codigo de la Comision ");
                        legajo = CInterfaz.PedirDato("Legajo del Alumno ");
                        leg = Convert.ToUInt64(legajo);
                        if (Universidad.RegistrarAlumnosComisiones(leg,codigo)== true)
                        {
                            CInterfaz.MostrarInfo("Alumno asignado ");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("No se pudo asignar ");
                        }                      
                        break;

                    
                    case 'H'://Asignar un Docente a una Comision.
                        codigo = CInterfaz.PedirDato("Codigo de la Comision ");
                        legajo = CInterfaz.PedirDato("Legajo del Docente ");
                        leg = Convert.ToUInt64(legajo);
                        if (Universidad.RegistrarDocentesComisiones(leg, codigo) == true)
                        {
                            CInterfaz.MostrarInfo("Docente asignado");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("No se pudo asignar");
                        }
                        break;


                    case 'I'://Remover un Alumno de una Comision
                        codigo = CInterfaz.PedirDato("Codigo de la comision ");
                        legajo = CInterfaz.PedirDato("Legajo del alumno a Eliminar ");
                        leg = Convert.ToUInt64(legajo);


                        if (Universidad.Remover_Alumno(codigo, leg) == true)
                        {
                            CInterfaz.MostrarInfo("El alumno fue removido de la comision");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("No se pudo remover al alumno");
                        }                      
                        break;


                    case 'J'://Remover un Docente de una Comision
                        codigo = CInterfaz.PedirDato("Codigo de la comision ");
                        legajo = CInterfaz.PedirDato("Legajo del docente a Eliminar ");
                        leg = Convert.ToUInt64(legajo);

                        if (Universidad.Remover_Docente(codigo, leg) == true)
                        {
                            CInterfaz.MostrarInfo("El Docente fue removido de la comision");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("No se pudo remover al Docente");
                        }
                        break;

                        
                    case 'K': //Remover un Alumno de la Universidad.                  
                        legajo = CInterfaz.PedirDato("Legajo del Alumno a Eliminar ");
                        leg = Convert.ToUInt64(legajo);
                         
                        if (Universidad.Remover_Alumno(leg))
                        {
                            CInterfaz.MostrarInfo("El Alumno fue Removido de la Universidad");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("No se pudo remover al alumno de la Universidad");
                        }
                        break;


                    case 'L': //Remover un Docente de la Universidad.
                        legajo = CInterfaz.PedirDato("Legajo del Docente a Eliminar ");
                        leg = Convert.ToUInt64(legajo);

                        if (Universidad.Remover_Docente(leg))
                        {
                            CInterfaz.MostrarInfo("El Docente fue Removido de la Universidad");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("No se pudo remover al Docente de la Universidad");
                        }
                        break;


                    case 'M'://Listar Docentes de Comision.
                        codigo = CInterfaz.PedirDato("Ingrese el codigo de la comision a buscar:");

                        if (Universidad.Busca_Comision_Universidad(codigo) != null)
                        {
                            CComision comi = Universidad.Busca_Comision_Universidad(codigo);
                            CInterfaz.MostrarInfo("Datos de la comision: " + comi.DarDatos() + "\n Datos de los docentes: " + comi.DatosDocentesComisiones());
                        }
                        break;


                    case 'N': //Listar Alumnos de Comision.
                        codigo = CInterfaz.PedirDato("Ingrese el codigo de la comision a buscar ");

                        if (Universidad.Busca_Comision_Universidad(codigo) != null)
                        {
                            CComision comi = Universidad.Busca_Comision_Universidad(codigo);
                            CInterfaz.MostrarInfo("Datos de la comision: " + comi.DarDatos() + "\n Datos de los alumnos: " + comi.DatosAlumnosComisiones());
                        }
                        break;


                    case 'O': //Dar datos por legajo
                        legajo = CInterfaz.PedirDato("Ingrese el legajo a buscar ");
                        leg = Convert.ToUInt64(legajo);

                        CInterfaz.MostrarInfo(Universidad.Alumno_O_Docente(leg));

                        break;
                    
                }
            } while (opcion != 'S');
        }
    }
}
