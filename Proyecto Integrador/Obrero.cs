using System;

namespace Integrador
{
    public class Obrero
    {
        // Campos privados que representan las propiedades de un obrero
        private string nombre;
        private string apellido;
        private string dni;
        private int legajo;
        private double sueldo;
        private string cargo;

        // Constructor para inicializar un obrero con todos los datos necesarios
        public Obrero(string nombre, string apellido, string dni, int legajo, double sueldo, string cargo)
        {
            // Inicialización de los campos privados con los valores proporcionados
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.legajo = legajo;
            this.sueldo = sueldo;
            this.cargo = cargo;
        }

        // Propiedad Nombre para acceder y modificar el nombre del obrero
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        // Propiedad Apellido para acceder y modificar el apellido del obrero
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        // Propiedad Dni para acceder y modificar el DNI del obrero
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        // Propiedad Legajo para acceder y modificar el legajo del obrero
        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        // Propiedad Sueldo para acceder y modificar el sueldo del obrero
        public double Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }

        // Propiedad Cargo para acceder y modificar el cargo del obrero
        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        
    }
}
