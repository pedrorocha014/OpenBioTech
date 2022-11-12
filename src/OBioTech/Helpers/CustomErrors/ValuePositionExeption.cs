namespace OBioTech.Helpers.CustomErrors
{
    [Serializable]
    public class ValuePositionExeption: Exception
    {
        public ValuePositionExeption()
        { }

        public ValuePositionExeption(string message)
            : base(message)
        { }

        public ValuePositionExeption(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
