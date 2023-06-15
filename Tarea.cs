namespace EspacioTareas;
public enum Estado
{
    Pendiete = 0,
    Haciendo = 1,
    Completada = 2
}

// Clase Tarea, con los atributos estado, prioridad, fechaLimite y descripcion
public class Tarea
{


    private String descripcion;
    private int tareaID;
    private int duracion;

    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int TareaID { get => tareaID; set => tareaID = value; }
    public int Duracion { get => duracion; set => duracion = value; }

    //constructora para crear tarea
    public Tarea(int Id, int tiempo, string descrip)
    {
        duracion = tiempo;
        Descripcion = descrip;
        TareaID = Id;
    }

    public String MostrarTarea()
    {
        //Uso las propiedades public
        return "Descripcion: " + Descripcion + " - ID :" + TareaID + " - Duracion:" + Duracion;
    }
}