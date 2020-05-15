using System;
using System.Collections.Generic;
using TravelAgencies.DataAccess;

namespace TravelAgencies.Agencies
{
    public class PolandTrip : Trip
	{
		public PolandTrip(int countOfDays, List<TripAdvisor> tripAdvisors, List<ListNode> listBokings)
		{
			this.countOfDays = countOfDays;
			this.tripAdvisors = tripAdvisors;
			this.listBookings = listBokings;
		}

		public override void Print()
		{
			Console.WriteLine($"Rating: {averageRating()}");
			Console.WriteLine($"Price: {sumPrice()}\n");
			for (int i = 1; i <= countOfDays; i++)
			{
				Console.WriteLine($"Day {i} in Poland!");
				Console.WriteLine($"Accomodation: {listBookings[i - 1].Name}");
				Console.WriteLine("Attractions:");
				for (int j = 0; j < 3; j++)
				{
					Console.WriteLine($"\t {tripAdvisors[(i - 1) * 3 + j].Name}");
				}
			}
		}
	}
}
