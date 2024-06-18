using System;

namespace Integrador
{
    public class JefeObra : Obrero
    {
        private double bonificacion;
        private GrupoObreros[] jefeGrupoAsignado;

        // Constructor para inicializar un jefe de obra con los datos necesarios
        public JefeObra(string nombre, string apellido, string dni, int legajo, double sueldo, string cargo, double bonificacion) 
            : base(nombre, apellido, dni, legajo, sueldo, cargo)
        {
            this.bonificacion = bonificacion;
            this.jefeGrupoAsignado = new GrupoObreros[1]; // Inicializamos el array para un solo grupo
        }

        // Propiedad Bonificacion para acceder y modificar la bonificación del jefe de obra
        public double Bonificacion
        {
            get { return bonificacion; }
            set { bonificacion = value; }
        }

        // Propiedad JefeGrupoAsignado para acceder y modificar el grupo asignado al jefe de obra
        public GrupoObreros[] JefeGrupoAsignado
        {
            get { return jefeGrupoAsignado; }
            set { jefeGrupoAsignado = value; }
        }

        // Método para asignar un grupo al jefe de obra
        public void AsignarGrupo(GrupoObreros grupoAsignado)
        {
            jefeGrupoAsignado[0] = grupoAsignado; // Asignamos el grupo al primer elemento del array (asumimos que solo se asigna un grupo)
        }
    }
}
