using System;
using System.Collections.Generic;
using TravelAgencies.DataAccess;

namespace TravelAgencies.Agencies
{
	public class PolandTravelAgency : TravelAgency
	{

		public PolandTravelAgency(
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
					if(photMetadata.Longitude >= 14.4 &&
						photMetadata.Longitude <= 23.5 &&
						photMetadata.Latitude >=49.8 &&
						photMetadata.Latitude <= 54.2)
					{
						return new PolandPhoto(photMetadata.WidthPx,photMetadata.HeightPx,photMetadata.Name);
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

			return new PolandReview(oyster.UserName, oyster.Review);
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
					if (tripAdvisor.Country == "Poland")
					{
						counterAtractions--;
						tripAdvisors.Add(tripAdvisor);
						continue;
					}
				}
			}

			List<ListNode> listBokings = new List<ListNode>();
			while (counterBookings != 0)
			{
				ListNode listNode;
				if (bookingDatabaseIterator.HasNext())
				{

					listNode = bookingDatabaseIterator.GetNext();
					counterBookings--;
					listBokings.Add(listNode);
				}
			}

			return new PolandTrip(countOfDays,tripAdvisors,listBokings);
		}
	}

}
