using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisConsumer.Models
{
    public class AnalysisDto
    {
        public string Sequence { get; set; }
        public string Mutations { get; set; }
        public List<Operations> Operations { get; set; }
    }

    public class Operations
    {
        public string Operation { get; set; }
        public string Values { get; set; }
    }
}
