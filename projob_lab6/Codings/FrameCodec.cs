using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projob_lab6.Codings
{
    public class FrameCodec : Codec
    {
        public FrameCodec(int n) : base(n)
        {
        }

        public override string coding(string word)
        {
            if (n >= 0)
            {
                string start = "", end = "";
                for (int i = 1; i <= n; i++)
                {
                    start += i;
                    end += n - i + 1;
                }
                return start + word + end;
            }
            else
            {
                n = -n;
                return word.Substring(n - 1, word.Length - 2 * n);
            }

        }
    }
}
