namespace tp_oop.Excepciones;

public sealed class ReservaSolapadaException : Exception
{
    public ReservaSolapadaException()
    {
    }

    public ReservaSolapadaException(string message)
        : base(message)
    {
    }

    public ReservaSolapadaException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
