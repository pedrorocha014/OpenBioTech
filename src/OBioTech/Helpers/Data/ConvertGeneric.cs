namespace OBioTech.Helpers.Data
{
    public static class ConvertGeneric
    {
        public static T GenericToClass<U,T>(U from)
        {
            return (T)Convert.ChangeType(from, typeof(T));
        }
    }
}
