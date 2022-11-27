namespace OBioTech.Services.Analysis
{
    public interface IOperationService
    {
        public T SelectOperation<U,T>(U operationDto);
    }
}