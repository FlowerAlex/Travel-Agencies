namespace projob_lab6.Codings.Decorators
{
    public class ShutterStockCodecDecorator : CodecDecorator
    {
        public ShutterStockCodecDecorator()
        {
            startCodec = (((new CezarCodec(4))
                .setNextCodec(new FrameCodec(1)))
                .setNextCodec(new PushCodec(-3)))
                .setNextCodec(new ReverseCodec(0));

            startDecodec = (((new ReverseCodec(0))
                .setNextCodec(new PushCodec(3)))
                .setNextCodec(new FrameCodec(-1)))
                .setNextCodec(new CezarCodec(-4));
        }
    }
}
