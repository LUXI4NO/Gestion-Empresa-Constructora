using System;

namespace Integrador
{
    public class Obra
    {
        // Campos privados que representan las propiedades de una obra
        private string nombrePropietario;
        private string dniPropietario;
        private int codigoInterno;
        private string tipoObra;
        private double estadoDeAvance;
        private string nombreJefe;
        private int legajoJefe;
        private double costo;

        // Constructor para inicializar una obra con los datos necesarios
        public Obra(string nombrePropietario, string dniPropietario, int codigoInterno, string tipoObra, double estadoDeAvance, double costo)
        {
            // Inicialización de los campos privados con los valores proporcionados
            this.nombrePropietario = nombrePropietario;
            this.dniPropietario = dniPropietario;
            this.codigoInterno = codigoInterno;
            this.tipoObra = tipoObra;
            this.estadoDeAvance = estadoDeAvance;
            this.costo = costo;
        }

        // Propiedad NombrePropietario para acceder y modificar el nombre del propietario de la obra
        public string NombrePropietario
        {
            get { return nombrePropietario; }
            set { nombrePropietario = value; }
        }

        // Propiedad DniPropietario para acceder y modificar el DNI del propietario de la obra
        public string DniPropietario
        {
            get { return dniPropietario; }
            set { dniPropietario = value; }
        }

        // Propiedad CodigoInterno para acceder y modificar el código interno de la obra
        public int CodigoInterno
        {
            get { return codigoInterno; }
            set { codigoInterno = value; }
        }

        // Propiedad TipoObra para acceder y modificar el tipo de obra
        public string TipoObra
        {
            get { return tipoObra; }
            set { tipoObra = value; }
        }

        // Propiedad EstadoDeAvance para acceder y modificar el estado de avance de la obra
        public double EstadoDeAvance
        {
            get { return estadoDeAvance; }
            set { estadoDeAvance = value; }
        }

        // Propiedad NombreJefe para acceder y modificar el nombre del jefe asignado a la obra
        public string NombreJefe
        {
            get { return nombreJefe; }
            set { nombreJefe = value; }
        }

        // Propiedad LegajoJefe para acceder y modificar el legajo del jefe asignado a la obra
        public int LegajoJefe
        {
            get { return legajoJefe; }
            set { legajoJefe = value; }
        }

        // Propiedad Costo para acceder y modificar el costo estimado de la obra
        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        // Método para asignar un jefe de obra
		public void asignarJefe(JefeObra jefe)
		{
			nombreJefe = jefe.Nombre;
			legajoJefe = jefe.Legajo;
		}

        // Método para eliminar al jefe de obra
        public void EliminarJefe()
        {
            nombreJefe = null;
            legajoJefe = 0;
            Console.WriteLine("El jefe fue despedido");
        }

        // Método para mostrar el jefe asignado
        public void VerJefeAsignado()
        {
            Console.WriteLine("Jefe: " + nombreJefe + ".");
            Console.WriteLine("Legajo: " + legajoJefe);
        }

        // Método para consultar si existe un jefe asignado
        public bool ExisteUnJefe()
        {
            return nombreJefe != null;
        }

        // Método para modificar el estado de avance de la obra
        public void ModificarEstado()
        {
            Console.WriteLine("\nEl porcentaje de avance de la obra actual es de: " + estadoDeAvance + "%.");
            Console.Write("\nIngresar valor [0 - 100]: ");
            double modificacion = Convert.ToDouble(Console.ReadLine());
            if (modificacion >= 0 && modificacion <= 100)
            {
                estadoDeAvance = modificacion;
                Console.WriteLine("\nPorcentaje actualizado: " + estadoDeAvance + "%.");
            }
            else
            {
                Console.WriteLine("\nValor fuera del rango.");
            }
        }

        // Método para verificar si un código interno dado coincide con el de la obra
        public bool ExisteCodigo(int codigo)
        {
            return codigoInterno == codigo;
        }
    }
}
