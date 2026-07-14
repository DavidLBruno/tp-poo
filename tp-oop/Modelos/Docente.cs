namespace tp_oop.Modelos;

public sealed class Docente : Usuario
{
    public Docente(int id, string nombre, string email)
        : base(id, nombre, email)
    {
    }

    public override string ObtenerRol() => "Docente";
}
