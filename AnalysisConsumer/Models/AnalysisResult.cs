using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisConsumer.Models
{
    public class AnalysisResult
    {
        public List<Result> Result { get; set; }
    }

    public class Result
    {
        public string Operation { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string Value { get; set; }
    }
}
