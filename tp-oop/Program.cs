using tp_oop.Modelos;
using tp_oop.Repositorios;
using tp_oop.Servicios;

namespace tp_oop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var login = new Formularios.FrmLogin();
            if (login.ShowDialog() != DialogResult.OK)
                return;

            Sesion.UsuarioActual = IdentificarUsuario(login.UsuarioIngresado);

            Application.Run(new Formularios.FrmPrincipal());
        }

        // El login pasa siempre con cualquier credencial. Se intenta identificar al
        // usuario por el texto ingresado (match por email); si no coincide, se usa
        // un Administrador para no bloquear el acceso.
        private static Usuario IdentificarUsuario(string textoIngresado)
        {
            using var repoUsuarios = RepositorioFactory.CrearRepositorioUsuarios();
            var usuarios = repoUsuarios.ObtenerTodos().ToList();

            var encontrado = usuarios.FirstOrDefault(u =>
                string.Equals(u.Email, textoIngresado, StringComparison.OrdinalIgnoreCase));

            if (encontrado != null)
                return encontrado;

            return usuarios.OfType<Administrador>().FirstOrDefault()
                   ?? new Administrador(0, "Administrador", "admin@instituto.edu");
        }
    }
}
