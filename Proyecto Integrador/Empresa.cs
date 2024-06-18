using System;
using System.Collections;

namespace Integrador
{
    public class Empresa
    {
        private ArrayList obrasEnEjecucion;  // Aquí declaramos un ArrayList para almacenar obras en ejecución.
        private ArrayList obrasFinalizadas;  // Este ArrayList será utilizado para almacenar obras finalizadas.
        private ArrayList empresaGruposAsignado;  // Aquí guardaremos los grupos de obreros asignados a la empresa.

        // Constructor de la clase Empresa.
        public Empresa(ArrayList obrasEnEjecucion, ArrayList obrasFinalizadas)
        {
            this.obrasEnEjecucion = obrasEnEjecucion;  // Inicializamos el ArrayList de obras en ejecución con el valor recibido.
            this.obrasFinalizadas = obrasFinalizadas;  // Inicializamos el ArrayList de obras finalizadas con el valor recibido.
            empresaGruposAsignado = new ArrayList();   // Inicializamos el ArrayList de grupos asignados como un nuevo ArrayList vacío.
        }

        // Propiedad para acceder y modificar la lista de obras en ejecución.
        public ArrayList ObrasEnEjecucion
        {
            get { return obrasEnEjecucion; }
            set { obrasEnEjecucion = value; }
        }

        // Propiedad para acceder y modificar la lista de obras finalizadas.
        public ArrayList ObrasFinalizadas
        {
            get { return obrasFinalizadas; }
            set { obrasFinalizadas = value; }
        }

        // Propiedad para acceder y modificar la lista de grupos asignados a la empresa.
        public ArrayList EmpresaGruposAsignado
        {
            get { return empresaGruposAsignado; }
            set { empresaGruposAsignado = value; }
        }

        // Método para asignar un grupo de obreros a la empresa.
        public void AsignarGrupo(GrupoObreros grupo, int codigo)
        {
            foreach (GrupoObreros grupoObrero in empresaGruposAsignado)
            {
                if (grupoObrero.CodigoGrupo == codigo)
                {
                    throw new Exception("Ya existe un grupo con ese código");  // Lanzamos una excepción si ya existe un grupo con el código especificado.
                }
            }
            
            empresaGruposAsignado.Add(grupo);  // Agregamos el grupo a la lista de grupos asignados.
        }


		// Método para contratar un obrero.
		public void contratarObrero()
		{
		    bool salir = false;  // Variable para controlar la salida del ciclo.
		    
		    while(!salir)
		    {
		        Console.Clear();  // Limpiamos la consola para una nueva interacción.
		        
		        Console.WriteLine("- Contratación de Obrero -\n");
		        
		        // Solicitamos y capturamos los datos del obrero
		        Console.Write("Ingrese el nombre: ");
		        string nombre = Console.ReadLine();
		        
		        Console.Write("Ingrese el apellido: ");
		        string apellido = Console.ReadLine();
		        
		        Console.Write("Ingrese el DNI: ");
		        string dni = Console.ReadLine();
		        
		        Console.Write("Ingrese el legajo: ");
		        int legajo = Convert.ToInt32(Console.ReadLine());
		        
		        // Verificamos si el legajo ya está en uso en algún grupo
		        foreach (GrupoObreros grupo in empresaGruposAsignado)
		        {
		            if (!grupo.VerificarLegajo(legajo))
		            {
		                Console.WriteLine("El legajo ingresado ya está en uso. Intente nuevamente.");
		                Console.ReadKey();  // Esperamos a que el usuario presione una tecla para continuar
		                return;  // Salimos del método porque no se puede registrar al obrero
		            }
		        }
		        
		        Console.Write("Ingrese el sueldo: ");
		        double sueldo = Convert.ToDouble(Console.ReadLine());
		        
		        Console.Write("Ingrese el cargo [Capataz, Albañil, Peón, Plomero, Electricista]: ");
		        string cargo = Console.ReadLine();
		        
		        // Creamos un nuevo objeto Obrero con los datos ingresados
		        Obrero obreroContratado = new Obrero(nombre, apellido, dni, legajo, sueldo, cargo);
		        
		        // Mostramos las obras en ejecución y solicitamos el código interno de la obra
		        Console.WriteLine("\nObras en ejecución:");
		        foreach (Obra obra in obrasEnEjecucion)
		        {
		            Console.WriteLine("Código interno: " + obra.CodigoInterno + ", Tipo de obra: " + obra.TipoObra);
		        }
		        
		        Console.Write("\nIngrese el código interno de la obra: ");
		        int codigoInterno = Convert.ToInt32(Console.ReadLine());
		        
		        // Buscamos el grupo que corresponde al código interno de la obra
		        bool obraEncontrada = false;
		        foreach (GrupoObreros grupo in empresaGruposAsignado)
		        {
		            if (grupo.ObraAsignadaGrupo == codigoInterno)
		            {
		                grupo.AgregarObrero(obreroContratado);  // Agregamos al obrero al grupo correspondiente
		                Console.WriteLine("\nSe contrató a " + obreroContratado.Apellido + " " + obreroContratado.Nombre + ", legajo: " + obreroContratado.Legajo + " con éxito.");
		                Console.WriteLine("Formará parte del grupo: " + grupo.CodigoGrupo + ".\n");
		                obraEncontrada = true;
		                break;  // Salimos del bucle porque ya encontramos el grupo correcto
		            }
		        }
		        
		        if (!obraEncontrada)
		        {
		            // Si no se encontró la obra correspondiente al código
		            Console.WriteLine("El código de obra ingresado no existe. Intente nuevamente.");
		            Console.ReadKey();  // Esperamos a que el usuario presione una tecla para continuar
		            continue;  // Volvemos al inicio del bucle para volver a solicitar los datos
		        }
		        
		        // Preguntamos al usuario si desea seguir registrando obreros
		        Console.Write("Para salir, escriba 'Si'; para registrar otro obrero, escriba 'No': ");
		        string opcion = Console.ReadLine();
		        
		        if (opcion.ToLower() == "si")
		        {
		            salir = true;  // Cambiamos la variable a true para salir del bucle while
		        }
		    }
		}
			
		
		// Método para despedir a un obrero de un grupo asignado a una obra en ejecución
		public void despedirObrero()
		{
		    Console.Clear(); // Limpio la consola para una mejor visualización
		
		    Console.WriteLine("- Despedir un Obrero -\n");
		
		    // Muestra las obras en ejecución
		    foreach (Obra obra in obrasEnEjecucion)
		    {
		        Console.WriteLine("Código interno de la obra: " + obra.CodigoInterno + ", " + obra.TipoObra + ".");
		    }
		
		    Console.Write("\nIngresar código: "); // Solicita ingresar el código de la obra
		    int preguntaCodigoInterno = Convert.ToInt32(Console.ReadLine());
		
		    Console.Write("\n- Lista de Obreros -\n"); // Solicita ingresar el código de la obra
		    foreach (GrupoObreros y in empresaGruposAsignado)
		    {
		        if (preguntaCodigoInterno == y.ObraAsignadaGrupo)
		        {
		            y.VerObreros(); // Muestra los obreros asignados a la obra seleccionada
		            Console.WriteLine("\n--------Escriba 0 para volver atrás--------\n");
		            Console.Write("Ingresar legajo del obrero a eliminar: "); // Solicita ingresar el legajo del obrero a eliminar
		            int inputObreroEliminar = Convert.ToInt32(Console.ReadLine());
		            y.EliminarObrero(inputObreroEliminar); // Invoca la función para eliminar el obrero del grupo
		            return;
		        }
		    }
		
		    // Lanza una excepción si no se encuentra ninguna obra con el código ingresado
		    throw new misExcepciones.excepcionCodigoNoExiste("\nEl código ingresado es incorrecto");
		}

		// Método para ver todos los obreros asignados a cada grupo de obreros de la empresa
		public void verTodosLosObreros()
		{
			Console.Clear();
	    	Console.WriteLine("- Listado de Obreros -\n");
			foreach (GrupoObreros grupo in empresaGruposAsignado) 
			{
				Console.WriteLine("\nObra: " + grupo.ObraAsignadaGrupo + ".");
				grupo.VerObreros(); // Invoca la funcion creada en grupoObreros
			}
		}
		

		
		// Método para ver todos los jefes asignados a obras en ejecución
		public void verTodosLosJefes()
		{
			Console.Clear();
	    	Console.WriteLine("- Listado de Jefes -\n");
			Console.WriteLine("\nJefes en obras en ejecucion:");
			foreach (Obra y in obrasEnEjecucion) 
			{
				if (y.ExisteUnJefe() == true)
				{ // Invoca la funcion creada en obra
					y.VerJefeAsignado(); // Invoca la funcion creada en obra
				}
			}			
		}

		
		public void contratarJefe()
		{
		    Console.Clear(); // Limpio la consola para una mejor visualización
		    
		    Console.WriteLine("- Contratar a un Jefe de Obra -\n");
		    
		    // Solicitar y leer el nombre desde la consola
		    Console.Write("Ingrese el nombre: ");
		    string nombre = Console.ReadLine();
		    
		    // Solicitar y leer el apellido desde la consola
		    Console.Write("Ingrese el apellido: ");
		    string apellido = Console.ReadLine();
		    
		    // Solicitar y leer el DNI desde la consola
		    Console.Write("Ingrese el DNI: ");
		    string dni = Console.ReadLine();
		    
		    // Solicitar y leer el legajo desde la consola, convirtiéndolo a entero
		    Console.Write("Ingrese el legajo: ");
		    int legajo = Convert.ToInt32(Console.ReadLine());
		    
		    // Verificar si el legajo ya está asignado en algún grupo de obreros
		    foreach (GrupoObreros grupo in empresaGruposAsignado)
		    {
		        if (!grupo.VerificarLegajo(legajo))
		        {
		            Console.WriteLine("El legajo ingresado ya está asignado en el grupo " + grupo.CodigoGrupo + ".");
		            return; // Salir del método si el legajo ya está asignado
		        }
		    }
		    
		    // Solicitar y leer el sueldo desde la consola, convirtiéndolo a double
		    Console.Write("Ingrese el sueldo: ");
		    double sueldo = Convert.ToDouble(Console.ReadLine());
		    
		    string cargo = "Jefe";
		    
		    // Solicitar y leer la bonificación desde la consola, convirtiéndola a double
		    Console.Write("Ingrese la bonificación: ");
		    double bonificacion = Convert.ToDouble(Console.ReadLine());
		    
	        // Una vez que termino de Crear al Jefe
			bool condicion = true;
			
			while (condicion)
			{
			     Console.WriteLine("\n- Lista de Obras -");
			    foreach (Obra x in obrasEnEjecucion)
			    {
			        Console.WriteLine(x.CodigoInterno + ", " + x.TipoObra + ".");
			    }
			    
			    Console.Write("\nIngresar codigo: ");
			    int preguntaCodigoInterno = Convert.ToInt32(Console.ReadLine());
			    
			    foreach (Obra g in obrasEnEjecucion)
			    {
			        if (preguntaCodigoInterno == g.CodigoInterno)
			        {
			            if (g.ExisteUnJefe() == true)
			            {
			                // Invoca la función creada en obra, que devuelve un bool
			                Console.WriteLine("\nEl grupo ya tiene un jefe asignado");
			                return;
			            }
			            else
			            {
			                Console.WriteLine("\nEl grupo está libre");
			                JefeObra jefeMetodo = new JefeObra(nombre, apellido, dni, legajo, sueldo, cargo, bonificacion);
			                g.asignarJefe(jefeMetodo); // Invoca la función creada en obra
			                Console.WriteLine("\nSe asignó el jefe " + g.NombreJefe + ", con éxito a la obra " + g.TipoObra + ".");
			                
			                foreach (GrupoObreros grupo in empresaGruposAsignado)
			                {
			                    jefeMetodo.AsignarGrupo(grupo); // Invoca la función creada en jefeObra
			                }
			
			                return;
			            }
			        }
			    }
			    throw new misExcepciones.excepcionCodigoNoExiste("El codigo ingresado es incorrecto");
			}
		}

		
		// Método para despedir al jefe de una obra en ejecución
		public void DespedirJefe()
		{
		    Console.WriteLine("------ Lista de obras en ejecución ------");
		    
		    // Mostrar las obras en ejecución y sus códigos internos
		    foreach (Obra obra in obrasEnEjecucion)
		    {
		        Console.WriteLine("Código interno de la obra: " + obra.CodigoInterno + ", Tipo de obra: " + obra.TipoObra);
		    }
		    
		    // Solicitar al usuario ingresar el código interno de la obra
		    Console.Write("Ingresar código interno de la obra: ");
		    int codigoObra = Convert.ToInt32(Console.ReadLine());
		    
		    // Buscar la obra con el código interno ingresado
		    foreach (Obra obra in obrasEnEjecucion)
		    {
		        // Verificar si la obra tiene un jefe asignado
		        if (obra.ExisteUnJefe())
		        {
		            // Si el código interno coincide con el de la obra
		            if (codigoObra == obra.CodigoInterno)
		            {
		                obra.VerJefeAsignado(); // Muestra el jefe asignado
		                obra.EliminarJefe(); // Despide al jefe de la obra
		                Console.WriteLine("Se ha despedido al jefe de la obra " + obra.TipoObra + ".");
		                return; // Salir del método después de despedir al jefe
		            }
		        }
		        else
		        {
		            // Si la obra no tiene un jefe asignado
		            Console.WriteLine("La obra " + obra.TipoObra + " no tiene un jefe asignado.");
		            return; // Salir del método después de informar que no hay jefe
		        }
		    }
		    
		    // Si no se encontró ninguna obra con el código interno ingresado, lanzar una excepción
		    throw new misExcepciones.excepcionCodigoNoExiste("El código ingresado no corresponde a ninguna obra en ejecución.");
		}


		// Método para agregar una obra a la lista correspondiente (en ejecución o finalizadas)
		public void AgregarObraEmpresa(Obra obraParaAgregar)
		{
		    // Verificar si el estado de avance de la obra es menor que 100%
		    if (obraParaAgregar.EstadoDeAvance < 100)
		    {
		        obrasEnEjecucion.Add(obraParaAgregar); // Agregar la obra a la lista de obras en ejecución
		        Console.WriteLine("Obra agregada a la lista de obras en ejecución.");
		    }
		    else
		    {
		        obrasFinalizadas.Add(obraParaAgregar); // Agregar la obra a la lista de obras finalizadas
		        Console.WriteLine("Obra agregada a la lista de obras finalizadas.");
		    }
		}


		
		// Método para mostrar la cantidad de obras en ejecución
		public void CantidadObrasEnEjecucion()
		{
		    int cantidad = obrasEnEjecucion.Count; // Obtengo la cantidad de elementos en la lista obrasEnEjecucion
		    Console.WriteLine("Cantidad de obras en ejecución: " + cantidad);
		}

		// Método para calcular el porcentaje de obras de tipo "REMODELACION" en ejecución
		public void porcentajeRemodelacion()
		{
			Console.Clear();
	    	Console.WriteLine("- Porcentaje de Obras de Remodelación sin Finalizar -\n");
			//	LAS OBRAS EN REMODELACION
			int cantidadRemodelacion = 0;
			foreach (Obra obra in obrasEnEjecucion) 
			{
				if ((obra.TipoObra).ToUpper() == "REMODELACION")
				{
					cantidadRemodelacion ++;
				}
			}                                
			// TODAS LAS OBRAS
			int cantidadObras = 0;
			
			foreach (Obra x in obrasEnEjecucion) 
			{
				cantidadObras ++;
			}			
			
			int cuenta = (cantidadRemodelacion * 100) / cantidadObras;	
			
			Console.WriteLine("El porcentaje de obras en remodelacion sin finalizar es de " + cuenta + "%.");
		}
		
		


		
		// Método para modificar el estado de una obra
		public void ObraModificarEstado()
		{
		  	Console.Clear();
	    	Console.WriteLine("- Modificar Estado de Avance de una Obra -\n");
		    
		    // Mostrar las obras en ejecución
		    foreach (Obra obra in obrasEnEjecucion)
		    {
		        Console.WriteLine("Código interno de la obra: " + obra.CodigoInterno + ", Tipo de obra: " + obra.TipoObra);
		    }
		    
		    // Solicitar al usuario ingresar el código interno de la obra a modificar
		    Console.Write("\nIngresar código interno: ");
		    int codigoInterno = Convert.ToInt32(Console.ReadLine());
		    
		    // Buscar la obra con el código interno ingresado
		    foreach (Obra obra in obrasEnEjecucion)
		    {
		        if (codigoInterno == obra.CodigoInterno)
		        {
		            obra.ModificarEstado(); // Llamar al método ModificarEstado definido en la clase Obra
		            
		            // Si el estado de avance alcanza el 100%, mover la obra a la lista de obras finalizadas
		            if (obra.EstadoDeAvance == 100)
		            {
		                obrasFinalizadas.Add(obra); // Agregar la obra a obrasFinalizadas
		                obrasEnEjecucion.Remove(obra); // Remover la obra de obrasEnEjecucion
		            }
		            
		            return; // Salir del método después de modificar el estado de la obra
		        }
		    }
		    
		    // Si no se encontró ninguna obra con el código interno ingresado, lanzar una excepción
		    throw new misExcepciones.excepcionModificarObra("\nEsa obra no existe");
		}


		// Método para imprimir un listado de obras en ejecución por consola
		public void listadoObrasEnEjecucion()
		{
			Console.Clear();
	    	Console.WriteLine("- Listado de Obras en Ejecución -\n");
		    // Itero sobre cada obra en la lista de obras en ejecución
		    foreach (Obra obra in obrasEnEjecucion)
		    {
		        // Imprimo los detalles de cada obra en ejecución
		        Console.WriteLine(obra.TipoObra + ", código " + obra.CodigoInterno + ", avance " + obra.EstadoDeAvance + "%, propietario: " + obra.NombrePropietario + ", jefe de obra asignado: " + obra.NombreJefe + ".\n");
		    }
		}

		
		// Método para imprimir un listado de obras finalizadas por consola
		public void listadoObrasFinalizadas()
		{
			foreach (Obra x in obrasFinalizadas)
			{
				Console.WriteLine(x.TipoObra + ", codigo " + x.CodigoInterno + ", avance " + x.EstadoDeAvance + "%, propietario: " + x.NombrePropietario + ", jefe de obra asignado: " + x.NombreJefe + ".\n");
			}	
		}

		// Método para crear una nueva instancia de Obra con datos ingresados por consola
		public Obra crearObra()
		{
			Console.Clear();
			Console.WriteLine("- Crear Obra -\n");
		    // Solicito el nombre del propietario
		    Console.Write("Ingresar nombre del propietario: ");
		    string nombrePropietario = Console.ReadLine();
		    
		    // Solicito el DNI del propietario
		    Console.Write("Ingresar DNI del propietario: ");
		    string dniPropietario = Console.ReadLine();
		    
		    // Solicito el código interno de la obra
		    Console.Write("Ingresar código interno: ");
		    int codigoInterno = Convert.ToInt32(Console.ReadLine());
		    
		    // Verifico si el código interno ya existe en la lista de obras en ejecución
		    foreach (Obra obraExistente in obrasEnEjecucion)
		    {
		        if (obraExistente.CodigoInterno == codigoInterno)
		        {
		            // Si el código ya existe, lanzo una excepción personalizada
		            throw new misExcepciones.excepcionCodigoRepetido("\nEse código ya existe.");
		        }
		    }
		    
		    // Solicito el tipo de obra
		    Console.Write("Ingresar tipo de obra: ");
		    string tipoObra = Console.ReadLine();
		    
		    // Solicito el estado de avance de la obra
		    Console.Write("Ingresar estado de avance [0 - 100]: ");
		    double estadoDeAvance = Convert.ToDouble(Console.ReadLine());
		    
		    // Verifico que el estado de avance esté dentro del rango válido
		    if (estadoDeAvance < 0 || estadoDeAvance > 100)
		    {
		        // Si está fuera de rango, lanzo una excepción personalizada
		        throw new misExcepciones.excepcionEstadoInvalido("\nEstado de avance fuera de rango (debe estar entre 0 y 100).");
		    }
		    
		    // Solicito el costo de la obra
		    Console.Write("Ingresar costo: ");
		    double costo = Convert.ToDouble(Console.ReadLine());
		    
		    // Creo y retorno una nueva instancia de Obra con los datos ingresados
		    Obra nuevaObra = new Obra(nombrePropietario, dniPropietario, codigoInterno, tipoObra, estadoDeAvance, costo);
		    return nuevaObra;
		}
	}
}