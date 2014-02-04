using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lex4allRecording
{
    public class SampleAggregator
    {
        private float maxSample;
        private float minSample;
        private int counter;

        public SampleAggregator()
        {
            maxSample = 0;
            minSample = 0;
            counter = 100;
        }

        public int passSample(float sample) {
            int flag = 0;

            if(sample > maxSample) {
                maxSample = sample;
            } else if(sample < minSample) {
                minSample = sample;
            }

            if (counter == 0)
            {
                flag = 1;
                counter = 100;
            }

            counter = counter-1;
            return flag;
        }

        public float MaxSample
        {
            get { return maxSample; }
            set { maxSample = value; }
        }

        public float MinSample
        {
            get { return minSample; }
            set { minSample = value; }
        }
    }
}
