namespace tp_oop.Modelos;

public sealed class Laboratorio
{
    public Laboratorio(int id, string nombre, int capacidad, bool disponible = true)
    {
        Id = id;
        Nombre = nombre;
        Capacidad = capacidad;
        Disponible = disponible;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Capacidad { get; set; }
    public bool Disponible { get; set; }
}
