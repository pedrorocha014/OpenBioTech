using AnalysisRegister.DataBase;
using AnalysisRegister.Models;

namespace AnalysisRegister.Services
{
    public class Register : IRegister
    {
        private readonly RegisterDbContext _context;

        public Register(RegisterDbContext context)
        {
            _context = context;
        }

        public List<RegisterResult> GetResults()
        {
            return _context.Results.ToList();
        }

        public void RegisterAnalysisResult(Result result)
        {
            var resultDto = new RegisterResult { 
                IsSuccess = result.IsSuccess, 
                Message = result.Message, 
                Operation = result.Operation, 
                Value = result.Value
            };

            _context.Results.Add(resultDto);
            _context.SaveChanges();
        }
    }
}
