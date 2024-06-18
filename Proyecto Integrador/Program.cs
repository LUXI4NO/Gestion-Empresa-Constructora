﻿using System;
using System.Collections;
namespace Integrador
	
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			//PRIMER GRUPO DE OBREROS
			Obrero Agustin = new Obrero("Agustin", "Bacclean", "44.000.400", 0001, 350000, "Capataz");
			Obrero Lucas = new Obrero("Lucas", "Pradela", "34.300.100", 0002, 350000, "Peon");
			Obrero Jorgito = new Obrero("Jorge", "Johnson", "41.902.900", 888, 350000, "Electricista");
			Obrero Santiago = new Obrero("Santiago", "Lovinson", "45.004.460", 0004, 350000, "Plomero");
			Obrero Raul = new Obrero("Raul", "Bacclean", "38.060.130", 0005, 350000, "Techista");
			
			// Crear el grupo de obreros 1235
			GrupoObreros Grupo1235 = new GrupoObreros(1235);
			
			Grupo1235.AgregarObrero(Agustin);
			Grupo1235.AgregarObrero(Lucas);
			Grupo1235.AgregarObrero(Jorgito);
			Grupo1235.AgregarObrero(Santiago);
			Grupo1235.AgregarObrero(Raul);
			

			//SEGUNDO GRUPO DE OBREROS
			Obrero Pedro = new Obrero("Pedro", "González", "44.000.4400", 0006, 320000, "Carpintero");
			Obrero Javier = new Obrero("Javier", "Martínez", "34.300.200", 0007, 320000, "Albañil");
			Obrero Luis = new Obrero("Luis", "Fernández", "41.902.950", 0008, 320000, "Pintor");
			Obrero Carlos = new Obrero("Carlos", "López", "45.004.470", 0009, 320000, "Electricista");
			Obrero Manuel = new Obrero("Manuel", "Rodríguez", "38.060.150", 0099, 320000, "Plomero");
			
			// Crear el grupo de obreros 1240
			GrupoObreros Grupo1240 = new GrupoObreros(1240);
			
			Grupo1240.AgregarObrero(Pedro);
			Grupo1240.AgregarObrero(Javier);
			Grupo1240.AgregarObrero(Luis);
			Grupo1240.AgregarObrero(Carlos);
			Grupo1240.AgregarObrero(Manuel);
														

			//TERCER GRUPO DE OBREROS (SIN JEFE)
			Obrero Messi = new Obrero("Leo", "Messi", "34.000.4400", 0010, 320000, "Carpintero");
			Obrero Mascherano = new Obrero("Javier", "Masche", "33.343.200", 0011, 320000, "Albañil");
			Obrero CR7 = new Obrero("Cristiano", "Ronaldo", "30.777.777", 0077, 320000, "Pintor");
			Obrero Higuain = new Obrero("Higuain", "Pipita", "25.004.470", 0012, 320000, "Electricista");
			Obrero Tevez = new Obrero("Carlos", "Tevez", "28.060.150", 0013, 320000, "Plomero");
			
			
			// Crear el grupo de obreros 2006
			GrupoObreros Grupo2006 = new GrupoObreros(2006);
			
			Grupo2006.AgregarObrero(Messi);
			Grupo2006.AgregarObrero(Mascherano);
			Grupo2006.AgregarObrero(CR7);
			Grupo2006.AgregarObrero(Higuain);
			Grupo2006.AgregarObrero(Tevez);
			
			
			//Creación de 2 jefes
			JefeObra jefeRamon = new JefeObra("Ramón", "Baccleaning", "37912005", 77300, 350000, "Jefe de Obra", 180000);
			jefeRamon.AsignarGrupo(Grupo1235);
			
			JefeObra jefeJulio = new JefeObra("Julio", "Fernandez", "33511031", 65305, 320000, "Jefe de Obra", 150000);
			jefeJulio.AsignarGrupo(Grupo1240);
						
			//No se crea un tercer jefe para probar el enunciado
			
			
			// Creación de 3 obras
			Obra puenteFcioVarela = new Obra("Jeremy Jackson", "20.152.912", 555, "Remodelacion", 20, 10500250);
			puenteFcioVarela.asignarJefe(jefeRamon);
			
			
			Obra rotonda = new Obra("Fabricio Diaz", "35.184.557", 999, "Remodelacion", 70,2900000);
			rotonda.asignarJefe(jefeJulio);

			
			Obra canchaFulbo = new Obra("Chiqui Tapia", "15.859.151", 206, "Construcción de cancha", 10, 23500250);
			
			
			// ASIGNAR OBRA PUENTE AL GRUPO 1235
			Grupo1235.AsignarObra(puenteFcioVarela);
			
			
			// ASIGNAR OBRA ROTONDA AL GRUPO 1235
			Grupo1240.AsignarObra(rotonda);
			
			
			// ASIGNAR OBRA ROTONDA AL GRUPO 2006
			Grupo2006.AsignarObra(canchaFulbo);
			
			
			// Obras en ejecucion
			ArrayList listaObrasEjecucion = new ArrayList();			
			ArrayList listaObrasFinalizadas = new ArrayList();			
			
			
			// Creacion de la Empresa
			Empresa miEmpresa = new Empresa(listaObrasEjecucion, listaObrasFinalizadas);
			
			miEmpresa.AsignarGrupo(Grupo1235, 1235);
			miEmpresa.AsignarGrupo(Grupo1240, 1240);  // ASIGNACIÓN DE GRUPOS A LA EMPRESA
			miEmpresa.AsignarGrupo(Grupo2006, 2006);
			
			
			miEmpresa.AgregarObraEmpresa(puenteFcioVarela);
			miEmpresa.AgregarObraEmpresa(rotonda);  // ASIGNACIÓN DE OBRAS A LA EMPRESA TENIENDO EN CUENTA
			miEmpresa.AgregarObraEmpresa(canchaFulbo); // SU ESTADO DE AVANCE %.


			bool menuPrincipal = true; // Variable para controlar el bucle del menú principal
			
			while (menuPrincipal)
			{
			    Console.Clear(); // Limpiar la consola en cada iteración del bucle
			    Console.WriteLine("=============================");
			    Console.WriteLine("=== Menu de opciones ===");
			    Console.WriteLine("=============================");
			    Console.WriteLine("1. Contratar un obrero nuevo");
			    Console.WriteLine("2. Eliminar un obrero");
			    Console.WriteLine("3. Contratar a un jefe de obra");
			    Console.WriteLine("4. Dar de baja a un jefe");
			    Console.WriteLine("5. Crear Obra");
			    Console.WriteLine("6. Modificar el estado de avance de una obra");
			    Console.WriteLine("7. Submenú de impresión");
			    Console.WriteLine("0. Salir");
			    Console.WriteLine("=============================");
			    Console.Write("Elija una opción: ");
			
			    try
			    {
			        int menuOpcion = Convert.ToInt32(Console.ReadLine()); // Leer la opción elegida
			
			        switch (menuOpcion)
			        {
			            case 1:
			                Console.WriteLine("\n=== Contratar a un obrero ===\n");
			                try
			                {
			                    miEmpresa.contratarObrero(); // Llamar al método para contratar un obrero
			                }
			                catch (misExcepciones.excepcionCodigoNoExiste u)
			                {
			                    Console.WriteLine(u.Message); // Capturar excepción de código no existente
			                }
			                break;
			
			            case 2:
			                Console.WriteLine("\n=== Eliminar a un obrero ===\n");
			                try
			                {
			                    miEmpresa.despedirObrero(); // Llamar al método para despedir un obrero
			                }
			                catch (misExcepciones.excepcionCodigoNoExiste u)
			                {
			                    Console.WriteLine(u.Message); // Capturar excepción de código no existente
			                }
			                break;
			
			            case 3:
			                Console.WriteLine("\n=== Contratar a un jefe de obra ===\n");
			                try
			                {
			                    miEmpresa.contratarJefe(); // Llamar al método para contratar un jefe de obra
			                }
			                catch (misExcepciones.excepcionCodigoNoExiste u)
			                {
			                    Console.WriteLine(u.Message); // Capturar excepción de código no existente
			                }
			                break;
			
			            case 4:
			                Console.WriteLine("\n=== Dar de baja a un jefe ===\n");
			                try
			                {
			                    miEmpresa.DespedirJefe(); // Llamar al método para despedir un jefe de obra
			                }
			                catch (misExcepciones.excepcionCodigoNoExiste u)
			                {
			                    Console.WriteLine(u.Message); // Capturar excepción de código no existente
			                }
			                break;
			
			            case 5:
			                Console.WriteLine("\n=== Crear Obra ===\n");
			                try
			                {
			                    Obra nuevaObra = miEmpresa.crearObra(); // Llamar al método para crear una nueva obra
			                    Console.Write("Ingresa un código para el grupo asignado: ");
			                    int codigoG = Convert.ToInt32(Console.ReadLine());
			                    GrupoObreros grupoNuevo = new GrupoObreros(codigoG);
			                    miEmpresa.AsignarGrupo(grupoNuevo, codigoG); // Asignar grupo a la obra
			                    miEmpresa.AgregarObraEmpresa(nuevaObra); // Agregar obra a la empresa
			                    grupoNuevo.AsignarObra(nuevaObra); // Asignar obra al grupo
			                }
			                catch (misExcepciones.excepcionCodigoRepetido e)
			                {
			                    Console.WriteLine(e.Message); // Capturar excepción de código repetido
			                }
			                catch (misExcepciones.excepcionAsignarGrupo x)
			                {
			                    Console.WriteLine(x.Message); // Capturar excepción de asignación de grupo inválida
			                }
			                catch (misExcepciones.excepcionEstadoInvalido c)
			                {
			                    Console.WriteLine(c.Message); // Capturar excepción de estado inválido
			                }
			                break;
			
			            case 6:
			                Console.WriteLine("\n=== Modificar estado de avance de una obra ===\n");
			                try
			                {
			                    miEmpresa.ObraModificarEstado(); // Llamar al método para modificar el estado de avance de una obra
			                }
			                catch (misExcepciones.excepcionModificarObra o)
			                {
			                    Console.WriteLine(o.Message); // Capturar excepción de modificación de obra
			                }
			                break;
			
						case 7:

						    // Declaro una variable booleana para controlar la salida del submenú.
						    bool salirSubmenu = false;
						
						    // Dentro del bucle while, muestro el menú y espero la entrada del usuario para realizar la acción correspondiente.
						    while (!salirSubmenu)
						   	{

						        Console.WriteLine("\n=== Submenú de Impresión ===");
						        Console.WriteLine("1. Listado de obreros");
						        Console.WriteLine("2. Listado de obras en ejecución");
						        Console.WriteLine("3. Listado de obras finalizadas");
						        Console.WriteLine("4. Listado de jefes");
						        Console.WriteLine("5. Porcentaje de obras de remodelación sin finalizar");
						        Console.WriteLine("0. Volver al menú principal");
						        Console.WriteLine("=============================");
						        Console.Write("Por favor, seleccione una opción del submenú: ");
								
								
								// MANEJO DE EXCEPCIONES
								
								try{
									Console.Write("Elije una opción: ");
									string opcionSubmenu = Console.ReadLine();
									
									switch (opcionSubmenu) {
										case "1":
											miEmpresa.verTodosLosObreros();
											break;	
										case "2":							
											miEmpresa.listadoObrasEnEjecucion();
											break;
											
										case "3":
											miEmpresa.listadoObrasFinalizadas();
											break;
											
										case "4":
											miEmpresa.verTodosLosJefes();
											break;
											
										case "5":
										    miEmpresa.porcentajeRemodelacion();
											break;									
							            case "0":
							                salirSubmenu = true; 
							                break;			
										default:
											Console.WriteLine("No elegiste ninguna opción");
											break;
									}
									
								}
								catch (FormatException){
									Console.WriteLine("Porfavor, ingresa una letra");
								}
							}

							break;
			
			            case 0:
			                Console.WriteLine("Saliendo del programa...");
			                menuPrincipal = false; // Salir del bucle del menú principal
			                break;
			
			            default:
			                Console.WriteLine("La opción elegida no es válida");
			                break;
			        }
			    }
			    catch (FormatException)
			    {
			        Console.WriteLine("Por favor, ingresa un número");
			    }
			    catch (OverflowException)
			    {
			        Console.WriteLine("Valor fuera del rango");
			    }
			
			    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
			    Console.ReadKey(true); // Esperar a que se presione una tecla antes de continuar con el bucle
			}
		}
    }
}