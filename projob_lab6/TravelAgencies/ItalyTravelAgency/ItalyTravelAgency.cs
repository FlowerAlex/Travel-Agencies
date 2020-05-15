using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;
using TravelAgencies.DataAccess;

namespace projob_lab6.TravelAgencies.ItalyTravelAgency
{
    class ItalyTravelAgency : TravelAgency
	{ 
		public ItalyTravelAgency(
			MyIteratorAggregate<ListNode> bookingDatabase,
			MyIteratorAggregate<BSTNode> oysterDatabase,
			MyIteratorAggregate<PhotMetadata> shutterStockDatabase,
			MyIteratorAggregate<TripAdvisor> tripAdvisorDatabase
			)
		{
			bookingDatabaseIterator = bookingDatabase.GetMyEnumerator();
			oysterDatabaseIterator = oysterDatabase.GetMyEnumerator();
			shutterStockDatabaseIterator = shutterStockDatabase.GetMyEnumerator();
			tripAdvisorDatabaseIterator = tripAdvisorDatabase.GetMyEnumerator();
		}
		public override IPhoto CreatePhoto()
		{
			PhotMetadata photMetadata;

			while (true)
			{
				if (shutterStockDatabaseIterator.HasNext())
				{
					photMetadata = shutterStockDatabaseIterator.GetNext();
					if (photMetadata.Longitude >= 8.8 &&
						photMetadata.Longitude <= 15.2 &&
						photMetadata.Latitude >= 37.7 &&
						photMetadata.Latitude <= 44.0)
					{
						return new ItalyPhoto(photMetadata.WidthPx, photMetadata.HeightPx, photMetadata.Name);
					}
				}
			}
		}

		public override IReview CreateReview()
		{
			BSTNode oyster;
			if (oysterDatabaseIterator.HasNext())
			{
				oyster = oysterDatabaseIterator.GetNext();
			}
			else
			{
				oysterDatabaseIterator.HasNext();
				oyster = oysterDatabaseIterator.GetNext();
			}

			return new ItalyReview(oyster.UserName, oyster.Review);
		}

		public override ITrip CreateTrip()
		{
			Random rand = new Random();
			int countOfDays = rand.Next(1, 5);
			int counterAtractions = countOfDays * 3;
			int counterBookings = countOfDays;
			List<TripAdvisor> tripAdvisors = new List<TripAdvisor>();

			while (counterAtractions != 0)
			{
				TripAdvisor tripAdvisor;
				if (tripAdvisorDatabaseIterator.HasNext())
				{
					tripAdvisor = tripAdvisorDatabaseIterator.GetNext();
					if (tripAdvisor.Country == "Italy")
					{
						counterAtractions--;
						tripAdvisors.Add(tripAdvisor);
						continue;
					}
				}
			}

			List<ListNode> listBookings = new List<ListNode>();
			while (counterBookings != 0)
			{
				ListNode listNode;
				if (bookingDatabaseIterator.HasNext())
				{

					listNode = bookingDatabaseIterator.GetNext();
					counterBookings--;
					listBookings.Add(listNode);
				}
			}

			return new ItalyTrip(countOfDays, tripAdvisors, listBookings);
		}
	}
}
