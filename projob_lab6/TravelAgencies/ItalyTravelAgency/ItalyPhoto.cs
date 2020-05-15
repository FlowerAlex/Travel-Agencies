using projob_lab6.Codings;
using projob_lab6.Codings.Decorators;
using System;
using TravelAgencies.Agencies;

namespace projob_lab6.TravelAgencies.ItalyTravelAgency
{
    internal class ItalyPhoto : Photo
    {

        public ItalyPhoto(string widthPx, string heightPx, string name)
        {
            this.widthPx = widthPx;
            this.heightPx = heightPx;
            this.name = name;
            codecDecorator = new ShutterStockCodecDecorator();
        }

        public override void Print()
        {
            
            Console.WriteLine($"Dello_{name} ({codecDecorator.encoding(widthPx)}x{codecDecorator.encoding(heightPx)})");

        }
    }
}
