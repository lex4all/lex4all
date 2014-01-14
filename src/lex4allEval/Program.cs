using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech;

namespace lex4allEval
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Generates a lexion from the given training files for each Yoruba word.
        /// </summary>
        /// <param name="TrainDict">Keys are words, values are lists of audio file names</param>
        static void Train(Dictionary<String,List<String>> TrainDict)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs recognition and computes accuracy on the given testing files for each Yoruba word.
        /// </summary>
        /// <param name="TestDict">Keys are words, values are lists of audio file names</param>
        static void Test(Dictionary<String, List<String>> TestDict)
        {
            throw new NotImplementedException();
        }

    }
}
