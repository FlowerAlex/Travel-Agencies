using projob_lab6.Codings.Decorators;
using System;

namespace TravelAgencies.Agencies
{
	public class PolandPhoto : Photo
	{
		public PolandPhoto(string widthPx, string heightPx, string name)
		{
			this.widthPx = widthPx;
			this.heightPx = heightPx;
			this.name = name;
			codecDecorator = new ShutterStockCodecDecorator();
		}

		public override void Print()
		{
			Console.WriteLine($"{name} ({codecDecorator.encoding(widthPx)}x{codecDecorator.encoding(heightPx)})".Replace('s','ś').Replace('c','ć'));
		}
	}
}
