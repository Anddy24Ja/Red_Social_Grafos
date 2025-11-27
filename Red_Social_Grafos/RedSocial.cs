using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Social_Grafos
{
    public class RedSocial
    {
        private List<Persona> personas;
        private int[,] matrizAdyacencia;
        private int capacidad;

        public RedSocial(int capacidadMaxima)
        {
            capacidad = capacidadMaxima;
            personas = new List<Persona>();
            matrizAdyacencia = new int[capacidad, capacidad];
            InicializarMatriz();
        }

        private void InicializarMatriz()
        {
            for (int i = 0; i < capacidad; i++)
            {
                for (int j = 0; j < capacidad; j++)
                {
                    matrizAdyacencia[i, j] = 0;
                }
            }
        }

        public bool AgregarPersona(string nombre)
        {
            if (personas.Count >= capacidad)
            {
                Console.WriteLine("La red social ha alcanzado su capacidad máxima.");
                return false;
            }

            int nuevoId = personas.Count;
            Persona nuevaPersona = new Persona(nuevoId, nombre);
            personas.Add(nuevaPersona);
            Console.WriteLine($"Persona agregada: {nuevaPersona}");
            return true;
        }

        public bool AgregarAmistad(int idPersona1, int idPersona2)
        {
            if (!ValidarId(idPersona1) || !ValidarId(idPersona2))
            {
                Console.WriteLine("IDs inválidos.");
                return false;
            }

            if (idPersona1 == idPersona2)
            {
                Console.WriteLine("Una persona no puede ser amiga de sí misma.");
                return false;
            }

            // Grafo no dirigido: la amistad es bidireccional
            matrizAdyacencia[idPersona1, idPersona2] = 1;
            matrizAdyacencia[idPersona2, idPersona1] = 1;

            Console.WriteLine($"{personas[idPersona1].Nombre} y {personas[idPersona2].Nombre} ahora son amigos.");
            return true;
        }

        public List<Persona> EncontrarAmigosEnComun(int idPersona1, int idPersona2)
        {
            List<Persona> amigosEnComun = new List<Persona>();

            if (!ValidarId(idPersona1) || !ValidarId(idPersona2))
            {
                Console.WriteLine("IDs inválidos.");
                return amigosEnComun;
            }

            for (int i = 0; i < personas.Count; i++)
            {
                // Si ambos son amigos de la persona i
                if (matrizAdyacencia[idPersona1, i] == 1 && matrizAdyacencia[idPersona2, i] == 1)
                {
                    amigosEnComun.Add(personas[i]);
                }
            }

            return amigosEnComun;
        }

        public List<Persona> ObtenerAmigos(int idPersona)
        {
            List<Persona> amigos = new List<Persona>();

            if (!ValidarId(idPersona))
            {
                Console.WriteLine("ID inválido.");
                return amigos;
            }

            for (int i = 0; i < personas.Count; i++)
            {
                if (matrizAdyacencia[idPersona, i] == 1)
                {
                    amigos.Add(personas[i]);
                }
            }

            return amigos;
        }

        public void MostrarTodasLasPersonas()
        {
            Console.WriteLine("\n=== Lista de Personas en la Red ===");
            if (personas.Count == 0)
            {
                Console.WriteLine("No hay personas en la red social.");
                return;
            }

            foreach (var persona in personas)
            {
                Console.WriteLine(persona);
            }
        }

        public void MostrarMatrizAdyacencia()
        {
            Console.WriteLine("\n=== Matriz de Adyacencia ===");

            // Encabezado
            Console.Write("     ");
            for (int i = 0; i < personas.Count; i++)
            {
                Console.Write($"{i,3} ");
            }
            Console.WriteLine();

            // Matriz
            for (int i = 0; i < personas.Count; i++)
            {
                Console.Write($"{i,3}: ");
                for (int j = 0; j < personas.Count; j++)
                {
                    Console.Write($"{matrizAdyacencia[i, j],3} ");
                }
                Console.WriteLine();
            }
        }

        public void MostrarAmigos(int idPersona)
        {
            if (!ValidarId(idPersona))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var amigos = ObtenerAmigos(idPersona);
            Console.WriteLine($"\nAmigos de {personas[idPersona].Nombre}:");

            if (amigos.Count == 0)
            {
                Console.WriteLine("No tiene amigos aún.");
            }
            else
            {
                foreach (var amigo in amigos)
                {
                    Console.WriteLine($"  - {amigo}");
                }
            }
        }

        private bool ValidarId(int id)
        {
            return id >= 0 && id < personas.Count;
        }

        public int CantidadPersonas => personas.Count;
    }
}
