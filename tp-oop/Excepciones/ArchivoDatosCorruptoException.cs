namespace tp_oop.Excepciones;

public sealed class ArchivoDatosCorruptoException : Exception
{
    public ArchivoDatosCorruptoException(string message)
        : base(message)
    {
    }
}
