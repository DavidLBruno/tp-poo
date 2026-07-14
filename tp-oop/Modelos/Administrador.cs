namespace tp_oop.Modelos;

public sealed class Administrador : Usuario
{
    public Administrador(int id, string nombre, string email)
        : base(id, nombre, email)
    {
    }

    public override string ObtenerRol() => "Administrador";
    public override bool PuedeGestionarLaboratorios() => true;
}
