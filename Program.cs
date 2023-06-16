using EspacioTareas;
using EspacioPersonas;
using LectorCSV;
using System;
using System.IO;

internal class Program
{
    private static void Main()
    {


        Console.WriteLine("Ingrese la ruta de la carpeta:");
        string rutaCarpeta =@"C:\Users\mauri\OneDrive\Documentos\Facultad\3ero\Arquitectura y organizacion de computadoras";
        string rutaActual = @"C:\Users\mauri\OneDrive\Documentos\Facultad\3ero\TDL1\TP\tp8\tl1_tp8_2023-maurijs\";
        string nombreArchivoCsv = "index.csv";
       
       //Compruebo que el directorio exista
        if (Directory.Exists(rutaCarpeta))
        {
            //Obtengo los directorios de esa carpeta en un arreglo
            string[] archivos = Directory.GetFiles(rutaCarpeta); 

            Console.WriteLine("Listado de archivos:");
            foreach (string dirArchivo in archivos)
            {
                string NombreArchivo = Path.GetFileName(dirArchivo);
                string extension = Path.GetExtension(dirArchivo);

                Console.WriteLine($"Nombre: {NombreArchivo}, Extensión: {extension}");
            }

            // Guardar en archivo CSV
            // Asi el archivo se cree en esta carpeta del tp
            string PathArchivoCsv = Path.Combine(rutaActual, nombreArchivoCsv); //Combino las direcciones
            using (StreamWriter writer = new StreamWriter(PathArchivoCsv))
            {
                //Titulos de cada columna
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

        //La funcion toma como argumento la direccion y nombre del archivo, y su delimitador, y devuelve una lista donde cada
        //elemento es una linea del archivo de texto, sin el delimitador
        // HelperCsv no se instancia ya que es una clase constante
        var Lista = HelperCsv.LeerCsv(rutaActual, nombreArchivoCsv, ',');

        Console.WriteLine("Lista creada, la mostramos:");
        foreach (string[] fila in Lista)
        {
            Console.WriteLine(fila[0] + " - " + fila[1] + " - " + fila[2]);
        
        }

        Console.ReadLine();
    }
}
