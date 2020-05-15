using projob_lab6.Codings.Decorators;
using System;
using TravelAgencies.Agencies;

namespace projob_lab6.TravelAgencies.FranceTravelAgency
{
    internal class FrancePhoto : Photo
    {

        public FrancePhoto(string widthPx, string heightPx, string name)
        {
            this.widthPx = widthPx;
            this.heightPx = heightPx;
            this.name = name;
            codecDecorator = new ShutterStockCodecDecorator();
        }

        public override void Print()
        {
            Console.WriteLine($"{name} ({codecDecorator.encoding(widthPx)}x{codecDecorator.encoding(heightPx)})");
        }
    }
}
