using EspacioTareas;
using EspacioPersonas;
using System;
using System.IO;

internal class Program
{
    private static void Main()
    {
        //crea una lista de elementos de clase Tarea
        /*var TareasPendientes = new List<Tarea>();
        var TareasRealizadas = new List<Tarea>();

        DateTime fechaNac = new DateTime(2002, 8, 2);
        var empleado1 = new Persona("Mauricio", "Suarez", fechaNac);

        int CantidadDeTareas, respuesta;

        Console.WriteLine("Ingrese la cantidad de tareas");
        if (int.TryParse(Console.ReadLine(), out CantidadDeTareas))
        {
            CrearTareas(TareasPendientes, CantidadDeTareas);
            Console.WriteLine("Mostrando las tarea pendientes\n");
            MostrarTareas(TareasPendientes);
        }
        //TareasPendientes.count = longitud de la lista

        for (int i = 0; i < CantidadDeTareas; i++)
        {
            Console.WriteLine("Realizo la tarea "+ (i+1) + "?\n1-SI\n2-No");
            if (int.TryParse(Console.ReadLine(), out respuesta))
            {
                if (respuesta == 1)
                {
                    var Tarea = TareasPendientes[i];
                    //Agrego la tarea que se realizo a la lista de realizadas
                    TareasRealizadas.Add(Tarea);    
                    //no puedo eliminar las tareas pendientes aca porque estoy en un for y si se achica la lista saldria un error
                }
            }
        }
        // elimino las tareas pendientes que coincidan con las tareas realizadas
        foreach (var Tarea in TareasRealizadas)
        {
            TareasPendientes.Remove(Tarea);
        }

        Console.WriteLine("==================Mostrando las tarea pendientes=================\n");
        MostrarTareas(TareasPendientes);
        Console.WriteLine("=================================================");
        
        Console.WriteLine("==================Mostrando las tarea realizadas=================\n");
        MostrarTareas(TareasRealizadas);
        Console.WriteLine("=================================================");

        Console.WriteLine("Ingrese la descripcion a buscar en la lista de tareas realizadas");
        string palabra = Console.ReadLine();
        BusquedaTarea(TareasRealizadas, palabra);

        int horasTrabajadas = 0;
        string nombreArchivo = "Sumario.txt";

        foreach (var tarea in TareasRealizadas)
        {
            horasTrabajadas += tarea.Duracion;
        }

        string contenido = empleado1.Nombre + ", " + empleado1.Apellido + "; Horas trabajadas: " + horasTrabajadas;

        if (File.Exists(nombreArchivo))
        {
            // El archivo existe, abrirlo y escribir algo
            using (StreamWriter sw = File.AppendText(nombreArchivo))
            {
                sw.WriteLine(contenido);
            }
        }

        else
        {
            // El archivo no existe, crearlo y escribir algo
            using (StreamWriter sw = File.CreateText(nombreArchivo))
            {
                sw.WriteLine(contenido);
            }
        }*/

        Console.WriteLine("Ingrese la ruta de la carpeta:");
        string folderPath = Console.ReadLine();

        if (Directory.Exists(folderPath))
        {
            string[] archivos = Directory.GetFiles(folderPath); //Obtengo los directorios de esa carpeta

            Console.WriteLine("Listado de archivos:");
            foreach (string dirArchivo in archivos) 
            {
                string NombreArchivo = Path.GetFileName(dirArchivo);
                string extension = Path.GetExtension(dirArchivo);

                Console.WriteLine($"Nombre: {NombreArchivo}, Extensión: {extension}");
            }

            // Guardar en archivo CSV
            string archivoCsv = Path.Combine(folderPath, "index.csv");
            using (StreamWriter writer = new StreamWriter(archivoCsv))
            {
                writer.WriteLine("Indice,Nombre,Extensión");

                for (int i = 0; i < archivos.Length; i++)
                {
                    string fileName = Path.GetFileName(archivos[i]);
                    string extension = Path.GetExtension(archivos[i]);

                    writer.WriteLine($"{i + 1},{fileName},{extension}");
                }
            }

            Console.WriteLine("Se ha generado el archivo index.csv correctamente.");
        }
        else
        {
            Console.WriteLine("La carpeta ingresada no existe.");
        }

        Console.ReadLine();


    }

    //=======================DECLARACION DE FUNCIONES ========================

    //funcion para crear Tareas
    private static void CrearTareas(List<Tarea> ListaDeTareas, int CantidadDeTareas)
    {
        int duracion;
        string descripcion;
        for (int i = 0; i < CantidadDeTareas; i++)
        {

            Console.WriteLine("\nTarea " + (i+1));
            Console.WriteLine("Ingrese una descripcion de la tarea");
            descripcion = Console.ReadLine();
            
            Console.WriteLine("Ingrese la duracion de la tarea");
            if (int.TryParse(Console.ReadLine(), out duracion)) 
            {

                var TareaNueva = new Tarea(i+1, duracion, descripcion);            
                ListaDeTareas.Add(TareaNueva);
                //Construyo la tarea con la constructora y lo agrego a la lista
            }
        }
    }

    // Lista.find() encuentra coincidencias
    //funcion para mostrar tareas
    private static void MostrarTareas(List<Tarea> ListaDeTareas)
    {
        foreach (Tarea TareaX in ListaDeTareas)
        {
            Console.WriteLine(TareaX.MostrarTarea());
        }
    }

    //Funcion que dado un string y una lista busca los elementos de la lista que contengan ese string
    private static void BusquedaTarea(List<Tarea> ListaDeTareas, string palabra)
    {
        bool respuesta = false;
        int i = 0;
        while (!respuesta && (i < ListaDeTareas.Count))
        {
            respuesta = ListaDeTareas[i].Descripcion.Contains(palabra);
            if (respuesta)
            {
                Console.WriteLine("Tarea de ID:"+ ListaDeTareas[i].TareaID + " coincide");
                Console.WriteLine(ListaDeTareas[i].MostrarTarea());
            }
            i++;
        }
    }

    private static void ImprimirPersona(Persona persona)
    {
         System.Console.WriteLine(persona.MostrarDatos());
    }
}

//var archivo = new StreamWriter("texto que se escribira en el archivo")