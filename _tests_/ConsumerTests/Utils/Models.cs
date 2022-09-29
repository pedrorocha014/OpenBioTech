using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerTests.Utils
{
    public class Models
    {
        public List<char> sequence { get => GetSequence(); }

        private List<char> GetSequence()
        {
            return new List<char> { 'M', 'F', 'V' };
        }
    }
}
