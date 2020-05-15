namespace projob_lab6.Codings
{
    public class PushCodec : Codec
    {
        public PushCodec(int n) : base(n)
        {
        }

        public override string coding(string word)
        {
            if(n >= 0)
                return word.Substring(word.Length - n) + word.Substring(0, word.Length - n);
            else
            {
                n = -n;
                return word.Substring(n) + word.Substring(0, n);
            }
        }
    }
}
