using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lex4allRecording
{
    public class SampleEventArgs : EventArgs
    {
        public SampleEventArgs(float sample)
        {
            sample32 = sample;
        }

        public float sample32;

        public float Sample32
        {
            get { return sample32; }
            set { sample32 = value; }
        }

    }
}
