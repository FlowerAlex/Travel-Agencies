using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;
using TravelAgencies.DataAccess;

namespace projob_lab6.TravelAgencies.FranceTravelAgency
{
    class FranceTravelAgency : TravelAgency
	{
        
		public FranceTravelAgency(
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
					if (photMetadata.Longitude >= 0 &&
						photMetadata.Longitude <= 5.4 &&
						photMetadata.Latitude >= 43.6 &&
						photMetadata.Latitude <= 50.0)
					{
						return new FrancePhoto(photMetadata.WidthPx, photMetadata.HeightPx, photMetadata.Name);
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

			return new FranceReview(oyster.UserName, oyster.Review);
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
					if (tripAdvisor.Country == "France")
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

			return new FranceTrip(countOfDays, tripAdvisors, listBookings);
		}
	}
}

