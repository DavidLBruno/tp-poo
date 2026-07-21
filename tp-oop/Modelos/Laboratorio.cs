namespace tp_oop.Modelos;

public sealed class Laboratorio
{
    private string _nombre = string.Empty;
    private int _capacidad;

    public Laboratorio(int id, string nombre, string ubicacion, int capacidad, string equipamiento, bool disponible = true)
    {
        Id = id;
        Nombre = nombre;
        Ubicacion = ubicacion;
        Capacidad = capacidad;
        Equipamiento = equipamiento;
        Disponible = disponible;
    }

    public int Id { get; set; }

    public string Nombre
    {
        get => _nombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre del laboratorio no puede estar vacío.");
            _nombre = value;
        }
    }

    public string Ubicacion { get; set; }

    public int Capacidad
    {
        get => _capacidad;
        set
        {
            if (value <= 0)
                throw new ArgumentException("La capacidad debe ser mayor a cero.");
            _capacidad = value;
        }
    }

    public string Equipamiento { get; set; }
    public bool Disponible { get; set; }
}
