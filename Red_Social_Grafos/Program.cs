using Red_Social_Grafos;
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== RED SOCIAL - GRAFOS ===\n");

        Console.Write("Ingresa la capacidad máxima de la red social: ");
        int capacidad = int.Parse(Console.ReadLine());

        RedSocial redSocial = new RedSocial(capacidad);
        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarPersona(redSocial);
                    break;
                case "2":
                    AgregarAmistad(redSocial);
                    break;
                case "3":
                    BuscarAmigosEnComun(redSocial);
                    break;
                case "4":
                    MostrarAmigosDePersona(redSocial);
                    break;
                case "5":
                    redSocial.MostrarTodasLasPersonas();
                    break;
                case "6":
                    redSocial.MostrarMatrizAdyacencia();
                    break;
                case "7":
                    continuar = false;
                    Console.WriteLine("\n¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("\nOpción inválida. Intenta de nuevo.");
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Agregar persona");
        Console.WriteLine("2. Agregar amistad");
        Console.WriteLine("3. Buscar amigos en común");
        Console.WriteLine("4. Ver amigos de una persona");
        Console.WriteLine("5. Listar todas las persona");
        Console.WriteLine("6. Mostrar matriz de adyacencia");
        Console.WriteLine("7. Salir");
        Console.Write("\nSelecciona una opción: ");
    }

    static void AgregarPersona(RedSocial red)
    {
        Console.Write("\nIngresa el nombre de la persona: ");
        string nombre = Console.ReadLine();
        red.AgregarPersona(nombre);
    }

    static void AgregarAmistad(RedSocial red)
    {
        if (red.CantidadPersonas < 2)
        {
            Console.WriteLine("\nNecesitas al menos 2 personas en la red para crear amistades.");
            return;
        }

        red.MostrarTodasLasPersonas();

        Console.Write("\nIngresa el ID de la primera persona: ");
        int id1 = int.Parse(Console.ReadLine());

        Console.Write("Ingresa el ID de la segunda persona: ");
        int id2 = int.Parse(Console.ReadLine());

        red.AgregarAmistad(id1, id2);
    }

    static void BuscarAmigosEnComun(RedSocial red)
    {
        if (red.CantidadPersonas < 2)
        {
            Console.WriteLine("\nNecesitas al menos 2 personas en la red.");
            return;
        }

        red.MostrarTodasLasPersonas();

        Console.Write("\nIngresa el ID de la primera persona: ");
        int id1 = int.Parse(Console.ReadLine());

        Console.Write("Ingresa el ID de la segunda persona: ");
        int id2 = int.Parse(Console.ReadLine());

        var amigosEnComun = red.EncontrarAmigosEnComun(id1, id2);

        Console.WriteLine($"\n=== Amigos en Común ===");
        if (amigosEnComun.Count == 0)
        {
            Console.WriteLine("No tienen amigos en común.");
        }
        else
        {
            Console.WriteLine($"Tienen {amigosEnComun.Count} amigo(s) en común:");
            foreach (var amigo in amigosEnComun)
            {
                Console.WriteLine($"  - {amigo}");
            }
        }
    }

    static void MostrarAmigosDePersona(RedSocial red)
    {
        if (red.CantidadPersonas == 0)
        {
            Console.WriteLine("\nNo hay personas en la red.");
            return;
        }

        red.MostrarTodasLasPersonas();

        Console.Write("\nIngresa el ID de la persona: ");
        int id = int.Parse(Console.ReadLine());

        red.MostrarAmigos(id);
    }
}