using System;
using System.Collections.Generic;
using TravelAgencies.Agencies;
using TravelAgencies.DataAccess;

namespace projob_lab6.TravelAgencies.FranceTravelAgency
{
    internal class FranceTrip : Trip
    {

        public FranceTrip(int countOfDays, List<TripAdvisor> tripAdvisors, List<ListNode> listBookings)
        {
            this.countOfDays = countOfDays;
            this.tripAdvisors = tripAdvisors;
            this.listBookings = listBookings;
        }

        public override void Print()
        {
            Console.WriteLine($"Rating: {averageRating()}");
            Console.WriteLine($"Price: {sumPrice()}\n");
            for (int i = 1; i <= countOfDays; i++)
            {
                Console.WriteLine($"Day {i} in France!");
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
