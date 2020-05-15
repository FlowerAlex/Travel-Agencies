namespace projob_lab6.Codings.Decorators
{
    public abstract class CodecDecorator
    {
        public Codec startCodec,startDecodec;
        public string coding(string word)
        {
            string res = (string)word.Clone();
            Codec tmpCodec = startCodec;
            while (tmpCodec != null)
            {
                res = tmpCodec.coding(res);
                tmpCodec = tmpCodec.getNextCodec();
            }
            return res;
        }
        public string encoding(string word)
        {
            string res = (string)word.Clone();
            Codec tmpCodec = startDecodec;
            while (tmpCodec != null)
            {
                res = tmpCodec.coding(res);
                tmpCodec = tmpCodec.getNextCodec();
            }
            return res;
        }

    }
}
