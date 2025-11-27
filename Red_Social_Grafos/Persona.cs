using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Social_Grafos
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Persona(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"ID: {Id} - {Nombre}";
        }
    }
}
