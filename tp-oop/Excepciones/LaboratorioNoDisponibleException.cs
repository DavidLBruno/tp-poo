namespace tp_oop.Excepciones;

public sealed class LaboratorioNoDisponibleException : Exception
{
    public LaboratorioNoDisponibleException(string message)
        : base(message)
    {
    }
}
