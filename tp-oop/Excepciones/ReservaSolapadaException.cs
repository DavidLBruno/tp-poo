namespace tp_oop.Excepciones;

public sealed class ReservaSolapadaException : Exception
{
    public ReservaSolapadaException(string message)
        : base(message)
    {
    }
}
