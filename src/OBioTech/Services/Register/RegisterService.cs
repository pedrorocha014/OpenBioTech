using AnalysisRegister.DataBase;
using OBioTech.Models;

namespace OBioTech.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly RegisterDbContext _context;

        public RegisterService(RegisterDbContext context)
        {
            _context = context;
        }

        public List<RegisterResult> GetResults()
        {
            return _context.Results.ToList();
        }

        public void RegisterAnalysisResult(AnalysisResult analysisResult)
        {
            var resultDto = new RegisterResult
            {
                IsSuccess = analysisResult.IsSuccess,
                Message = analysisResult.Message,
                Operation = analysisResult.Operation,
                Value = analysisResult.Value
            };

            _context.Results.Add(resultDto);
            _context.SaveChanges();
        }
    }
}
