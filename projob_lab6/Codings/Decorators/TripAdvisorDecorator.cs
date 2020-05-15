namespace projob_lab6.Codings.Decorators
{
    public class TripAdvisorDecorator : CodecDecorator
    {
        public TripAdvisorDecorator()
        {
            startCodec = (((new PushCodec(3))
                .setNextCodec(new FrameCodec(2)))
                .setNextCodec(new SwapCodec(0)))
                .setNextCodec(new PushCodec(3));

            startDecodec = (((new PushCodec(-3))
                .setNextCodec(new SwapCodec(0)))
                .setNextCodec(new FrameCodec(-2)))
                .setNextCodec(new PushCodec(-3));
        }
    }
}
