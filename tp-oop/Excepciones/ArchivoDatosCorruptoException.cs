namespace tp_oop.Excepciones;

public sealed class ArchivoDatosCorruptoException : Exception
{
    public ArchivoDatosCorruptoException()
    {
    }

    public ArchivoDatosCorruptoException(string message)
        : base(message)
    {
    }

    public ArchivoDatosCorruptoException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
