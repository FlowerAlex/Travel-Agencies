using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projob_lab6.Codings.Decorators
{
    class BookingCodecDecorator : CodecDecorator
    {
        public BookingCodecDecorator()
        {
            startCodec = (((new FrameCodec(2))
                .setNextCodec(new ReverseCodec(0)))
                .setNextCodec(new CezarCodec(-1)))
                .setNextCodec(new SwapCodec(0));
            startDecodec = (((new SwapCodec(0))
                .setNextCodec(new CezarCodec(1)))
                .setNextCodec(new ReverseCodec(0)))
                .setNextCodec(new FrameCodec(-2));
        }


    }
}

