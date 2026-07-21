namespace tp_oop.Excepciones;

public sealed class LaboratorioNoDisponibleException : Exception
{
    public LaboratorioNoDisponibleException()
    {
    }

    public LaboratorioNoDisponibleException(string message)
        : base(message)
    {
    }

    public LaboratorioNoDisponibleException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
