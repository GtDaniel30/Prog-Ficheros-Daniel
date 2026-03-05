partial class Program
{
    static List<string> listaLocales = new List<string>();
    static string path = "mensajes.txt";
    static void Main()
    {

        // MAIN TASCA 1
        int opcion = 0;
        while (opcion != 7)
        {
            Console.WriteLine("1 añade mensaje local");
            Console.WriteLine("2 lista todos los usuarios");
            Console.WriteLine("3 lee mensaje por usuario");
            Console.WriteLine("4 lee todos los mensajes locales");
            Console.WriteLine("5 pasa mensajes a mensajes.txt");
            Console.WriteLine("6 lee todos los mensajes de archivo");
            Console.WriteLine("7 salir");
            opcion = Convert.ToInt32(Console.ReadLine());
            {
                switch (opcion)
                {
                    case 1:
                        AñadirMensaje();
                        break;
                    case 2:
                        ListarUsuarios();
                        break;
                    case 3:
                        LeerPorUsuario();
                        break;
                    case 4:
                        LeerTodosLocales();
                        break;
                    case 5:
                        GuardarEnArchivo();
                        break;
                    case 6:
                        LeerDeArchivo();
                        break;
                }
            }
        }
        //MAIN TASCA 2
        string archivo = "libros.txt";
        int opcion;

        do
        {
            Console.WriteLine("\n--- MENÚ LIBRERÍA ---");
            Console.WriteLine("1. Añadir libros");
            Console.WriteLine("2. Mostrar libros ordenados por autor");
            Console.WriteLine("3. Salir");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    nuevoLibro(archivo);
                    break;

                case 2:
                    leerLibro(archivo);
                    break;
            }

        } while (opcion != 3);


    }
    //TASCA 1
    static void AñadirMensaje()
    {

        Console.Write("ususario ");
        string usuario = Console.ReadLine();
        Console.Write("asunto ");
        string asunto = Console.ReadLine();
        Console.Write("mensaje ");
        string mensaje = Console.ReadLine();
        listaLocales.Add($"{usuario};{asunto};{mensaje}");
        System.Console.WriteLine("mensaje guardado");
    }
    static void ListarUsuarios()
    {
        foreach (string linea in listaLocales)
        {
            string[] partes = linea.Split(';');
            Console.WriteLine("- " + partes[0]);
        }
    }
    static void LeerPorUsuario()
    {
        Console.Write("nombre usuario?");
        string buscar = Console.ReadLine();
        bool check = false;
        foreach (string linea in listaLocales)
        {
            string[] cadena = linea.Split(';');
            if (cadena[0] == buscar)
            {
                Console.WriteLine($"[{cadena[1]}] -> {cadena[2]}");
                check = true;
            }
        }
        if (!check) Console.WriteLine("Nsin mensajes");
    }
    static void LeerTodosLocales()
    {
        foreach (string item in listaLocales)
        {
            Console.WriteLine(item);
        }
    }
    static void GuardarEnArchivo()
    {
        StreamWriter fichero = new StreamWriter(path, true);
        foreach (string item in listaLocales)
        {
            fichero.WriteLine(item);
        }
        listaLocales.Clear();
        Console.WriteLine("mensajes enviados!");
        fichero.Close();
    }
    static void LeerDeArchivo()
    {

        if (File.Exists(path))
        {
            string[] lineas = File.ReadAllLines(path);
            foreach (string item in lineas)
            {
                Console.WriteLine(item);
            }
        }
        else { Console.WriteLine("no existe el fichero"); }
    }


    // TASCA 2

    private static void nuevoLibro(string archivo)
    {
        List<string> listaLibros = new List<string>();
        string continuar;

        do
        {
            Console.WriteLine("Título?");
            string titulo = Console.ReadLine();

            Console.WriteLine("Autor?");
            string autor = Console.ReadLine();

            Console.WriteLine("ISBN?");
            string isbn = Console.ReadLine();

            listaLibros.Add($"{titulo};{autor};{isbn}");

            Console.WriteLine("¿Añadir otro libro? (s/n)");
            continuar = Console.ReadLine().ToLower();

        } while (continuar == "s");

        StreamWriter libreria = new StreamWriter(archivo, true);

        foreach (string libro in listaLibros)
        {
            libreria.WriteLine(libro);
        }

        libreria.Close();
    }

    private static void leerLibro(string archivo)
    {
        List<string> libros = new List<string>();

        StreamReader libreria = new StreamReader(archivo);

        string linea;

        while ((linea = libreria.ReadLine()) != null)
        {
            libros.Add(linea);
        }

        libreria.Close();

        libros.Sort((a, b) =>
        {
            string autorA = a.Split(';')[1];
            string autorB = b.Split(';')[1];
            return autorA.CompareTo(autorB);
        });

        Console.WriteLine("\n--- LIBROS ORDENADOS POR AUTOR ---");

        foreach (string libro in libros)
        {
            string[] datosLibro = libro.Split(';');

            Console.WriteLine("Título: {0}", datosLibro[0]);
            Console.WriteLine("Autor: {0}", datosLibro[1]);
            Console.WriteLine("ISBN: {0}", datosLibro[2]);
            Console.WriteLine();
        }
    }
}


