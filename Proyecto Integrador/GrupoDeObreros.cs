using System;
using System.Collections;

namespace Integrador
{
    public class GrupoObreros
    {
        private int codigoGrupo;
        private ArrayList listaObreros;
        private int obraAsignadaGrupo;

        // Constructor para inicializar un grupo de obreros con su código correspondiente
        public GrupoObreros(int codigoGrupo)
        {
            this.codigoGrupo = codigoGrupo;
            listaObreros = new ArrayList();
            this.obraAsignadaGrupo = 0; // Inicializamos sin ninguna obra asignada
        }

        // Propiedad para acceder y modificar el código del grupo
        public int CodigoGrupo
        {
            get { return codigoGrupo; }
            set { codigoGrupo = value; }
        }

        // Propiedad para acceder a la lista de obreros en el grupo
        public ArrayList ListaObreros
        {
            get { return listaObreros; }
            set { listaObreros = value; }
        }

        // Propiedad para acceder y modificar el código de la obra asignada al grupo
        public int ObraAsignadaGrupo
        {
            get { return obraAsignadaGrupo; }
            set { obraAsignadaGrupo = value; }
        }

        // Método para agregar un obrero al grupo
        public void AgregarObrero(Obrero obrero)
        {
            listaObreros.Add(obrero);
        }

        // Método para eliminar un obrero del grupo por su legajo
        public void EliminarObrero(int legajo)
        {
            foreach (Obrero obrero in listaObreros)
            {
                if (obrero.Legajo == legajo)
                {
                    listaObreros.Remove(obrero);
                    Console.WriteLine("\nObrero " + obrero.Nombre + " eliminado correctamente.");
                    return;
                }
            }
            Console.WriteLine("\nNo se encontró ningún obrero con el legajo " + legajo + ".");
        }

        // Método para visualizar la información de un obrero por su legajo
        public void VisualizarObrero(int legajo)
        {
            foreach (Obrero obrero in listaObreros)
            {
                if (obrero.Legajo == legajo)
                {
                    Console.WriteLine("Nombre: " + obrero.Nombre);
                    Console.WriteLine("Apellido: " + obrero.Apellido);
                    Console.WriteLine("DNI: " + obrero.Dni);
                    Console.WriteLine("Legajo: " + obrero.Legajo);
                    Console.WriteLine("Sueldo: " + obrero.Sueldo);
                    Console.WriteLine("Cargo: " + obrero.Cargo);
                    return;
                }
            }
            Console.WriteLine("No se encontró ningún obrero con el legajo " + legajo + ".");
        }

        // Método para obtener la cantidad de obreros en el grupo
        public void CantidadObreros()
        {
            Console.WriteLine("La cantidad de obreros es: " + listaObreros.Count);
        }

        // Método para listar los apellidos y nombres de los obreros en el grupo
        public void VerObreros()
        {
            foreach (Obrero obrero in listaObreros)
            {
                Console.WriteLine(obrero.Apellido + " " + obrero.Nombre + ", legajo: " + obrero.Legajo + ".");
            }
        }

        // Método para verificar si un legajo está ocupado en el grupo
        public bool VerificarLegajo(int legajo)
        {
            foreach (Obrero obrero in listaObreros)
            {
                if (obrero.Legajo == legajo)
                {
                    Console.WriteLine("El legajo está ocupado");
                    return false;
                }
            }
            return true;
        }

        // Método para asignar una obra al grupo
        public void AsignarObra(Obra obraParaAsignar)
        {
            obraAsignadaGrupo = obraParaAsignar.CodigoInterno;
        }
    }
}
