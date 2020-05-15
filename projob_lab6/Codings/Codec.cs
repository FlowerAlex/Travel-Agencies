using projob_lab6.Codings.Decorators;

namespace projob_lab6.Codings
{
    public abstract class Codec
    {
        protected int n;
        public Codec(int n)
        {
            this.n = n;
            next = null;
        }
        public abstract string coding(string word);
        protected Codec next;
        public Codec setNextCodec(Codec next)
        {
            return this.next = next;
        }
        public Codec getNextCodec()
        {
            return next;
        }
    }
}
