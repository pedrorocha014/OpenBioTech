namespace AnalysisDelivery.Helpers
{
    public class OperationsDictionary
    {
        public static IDictionary<string, bool> operationsType = new Dictionary<string, bool>(){
            {"INSERT", true},
            {"DELETE", true},
            {"REPLACE", true}
        };
    }
}
