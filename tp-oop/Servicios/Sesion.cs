using tp_oop.Modelos;

namespace tp_oop.Servicios;

// Guarda el usuario logueado para que los formularios apliquen las reglas por rol.
// Lo setea Program.cs tras el login. No modifica el comportamiento del login.
public static class Sesion
{
    public static Usuario? UsuarioActual { get; set; }
}
