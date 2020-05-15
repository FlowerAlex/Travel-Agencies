namespace projob_lab6.Codings
{
    public class ReverseCodec : Codec
    {
        public ReverseCodec(int n) : base(n)
        {
        }

        public override string coding(string word)
        {
            char[] tmp = word.ToCharArray();
            string res = "";
            for(int i = tmp.Length - 1; i >=0; i--)
            {
                res += tmp[i];
            }
            return res;
        }
    }
}
