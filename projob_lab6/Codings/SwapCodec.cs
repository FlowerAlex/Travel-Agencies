namespace projob_lab6.Codings
{
    public class SwapCodec : Codec
    {
        public SwapCodec(int n) : base(n)
        {
        }

        public override string coding(string word)
        {
            char[] charArray = word.ToCharArray();
            for (int i = 0; i + 1 < word.Length; i += 2)
            {
                char tmp = charArray[i];
                charArray[i] = charArray[i + 1];
                charArray[i + 1] = tmp;
            }
            return charArray.ToString();
        }
    }
}
