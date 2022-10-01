using AnalysisConsumer.Analysis;
using AnalysisConsumer.Models;
using AnalysisConsumer.Services;
using ConsumerTests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumerTests.Services
{
    public class SequenceAnalysisTest
    {
        Models models = new Models();

        [Test]
        public void Protein_Should_Be_Deleted_When_Delete_Operation()
        {
            AnalysisDto analysisDto = new AnalysisDto
            {
                Mutations = "del1",
                Sequence = "ABCDE",
                Operations = new List<Operations> 
                { 
                    new Operations { Operation = "DELETE" } 
                }
            };
            
            var result = SequenceAnalysis.InitializeOperation(analysisDto).Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(resultObj[0], Is.EqualTo('-'));
        }

        [Test]
        public void Protein_Should_Be_Replaced_When_Replace_Operation()
        {
            AnalysisDto analysisDto = new AnalysisDto
            {
                Mutations = "A1B",
                Sequence = "ABCDE",
                Operations = new List<Operations>
                {
                    new Operations { Operation = "REPLACE" }
                }
            };

            var result = SequenceAnalysis.InitializeOperation(analysisDto).Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(resultObj[0], Is.EqualTo('B'));
        }

        [Test]
        public void Protein_Should_Be_Inserted_When_Insert_Operation()
        {
            AnalysisDto analysisDto = new AnalysisDto
            {
                Mutations = "ins1X",
                Sequence = "ABCDE",
                Operations = new List<Operations>
                {
                    new Operations { Operation = "INSERT" }
                }
            };

            var result = SequenceAnalysis.InitializeOperation(analysisDto).Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(resultObj[0], Is.EqualTo('X'));
        }

        [Test]
        public void All_Operations_Should_Be_Executed()
        {
            AnalysisDto analysisDto = new AnalysisDto
            {
                Mutations = "A1B, ins2R, del3",
                Sequence = "ABCDE",
                Operations = new List<Operations>
                {
                    new Operations { Operation = "REPLACE" },
                    new Operations { Operation = "INSERT" },
                    new Operations { Operation = "DELETE" }
                }
            };

            var result = SequenceAnalysis.InitializeOperation(analysisDto).Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(resultObj[0], Is.EqualTo('B'));
            Assert.That(resultObj[1], Is.EqualTo('R'));
            Assert.That(resultObj[2], Is.EqualTo('-'));
        }
    }
}
