namespace OBioTech.Models
{
    public class AnalysisResult
    {
        public string Operation { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string Value { get; set; }
    }
}
