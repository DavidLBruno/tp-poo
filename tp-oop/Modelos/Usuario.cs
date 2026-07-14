namespace tp_oop.Modelos;

public abstract class Usuario
{
    protected Usuario(int id, string nombre, string email)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }

    public virtual string ObtenerRol() => "Usuario";
    public virtual bool PuedeGestionarLaboratorios() => false;
}
