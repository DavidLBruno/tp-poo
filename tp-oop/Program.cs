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
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Formularios.FrmPrincipal());
            }
        }
    }
}