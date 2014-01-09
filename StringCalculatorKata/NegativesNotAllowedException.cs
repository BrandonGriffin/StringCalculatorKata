namespace System
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(String message) : base(message)
        { }
    }
}
