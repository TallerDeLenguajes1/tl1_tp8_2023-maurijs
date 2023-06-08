using EspacioTareas;
using EspacioPersonas;
using System;

internal class Program
{
    private static void Main()
    {
        //crea una lista de elementos de clase Tarea
        var TareasPendientes = new List<Tarea>();
        var TareasRealizadas = new List<Tarea>();
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
            Console.WriteLine("Realizo la tarea "+ i + "?\n1-SI\n2-No");
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

        Console.WriteLine("Mostrando las tarea pendientes\n");
        MostrarTareas(TareasPendientes);
        
        Console.WriteLine("Mostrando las tarea realizadas\n");
        MostrarTareas(TareasRealizadas);

        Console.WriteLine("Ingrese la descripcion a buscar");
        string palabra = Console.ReadLine();
        BusquedaTarea(TareasRealizadas, palabra);

    }


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
        Console.WriteLine("===================================================");
        foreach (Tarea TareaX in ListaDeTareas)
        {
            Console.WriteLine(TareaX.MostrarTarea());
        }
        Console.WriteLine("=================================================");
    }

    private static void BusquedaTarea(List<Tarea> ListaDeTareas, string palabra)
    {
        bool respuesta = false;
        int i = 0;
        while (!respuesta && (i < ListaDeTareas.Count))
        {
            respuesta = ListaDeTareas[i].Descripcion.Contains(palabra);
            if (respuesta)
            {
                Console.WriteLine("Tarea de ID:"+ListaDeTareas[i].TareaID + " coincide");
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