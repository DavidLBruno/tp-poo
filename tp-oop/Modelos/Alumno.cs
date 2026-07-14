namespace tp_oop.Modelos;

public sealed class Alumno : Usuario
{
    public Alumno(int id, string nombre, string email)
        : base(id, nombre, email)
    {
    }

    public override string ObtenerRol() => "Alumno";
}
