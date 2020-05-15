using System;

namespace projob_lab6.Codings
{
    public class CezarCodec : Codec
    {
        public CezarCodec(int n) : base(n)
        {
        }


        public override string coding(string word)
        {
            if(n >= 0)
            {
                char[] res = word.ToCharArray();
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = (char)(Math.Abs((57 - res[i]) + n % 10) % 10 + 48);
                }
                return res.ToString();
            }
            else
            {
                n = -n;
                char[] res = word.ToCharArray();
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = (char)(Math.Abs((57 - res[i]) - n % 10) % 10 + 48);
                }
                return res.ToString();
            }

        }
    }
}

