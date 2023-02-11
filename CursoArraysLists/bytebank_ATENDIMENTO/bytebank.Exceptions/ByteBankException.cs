namespace bytebank.Exceptions;

[System.Serializable]
public class ByteBankException : System.Exception
{
    public ByteBankException() { }
    public ByteBankException(string message) : base("Aconteceu uma Exceção!" + message) { }
    public ByteBankException(string message, System.Exception inner) : base(message, inner) { }
    protected ByteBankException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
