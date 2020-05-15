using projob_lab6.Advertising_Agency;
using projob_lab6.TravelAgencies.FranceTravelAgency;
using projob_lab6.TravelAgencies.ItalyTravelAgency;
using System;
using TravelAgencies.Agencies;
using TravelAgencies.DataAccess;

namespace TravelAgencies
{
	class Program
	{
		static void Main(string[] args) { new Program().Run(); }

		private const int WebsitePermanentOfferCount = 2;
		private const int WebsiteTemporaryOfferCount = 3;
		private Random rd = new Random(257);


		public void Run()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			(
				BookingDatabase accomodationData, 
				TripAdvisorDatabase tripsData, 
				ShutterStockDatabase photosData, 
				OysterDatabase reviewData
			) = Init.Init.Run();


			OfferWebsite offerWebsite;

			AdvertisingAgency[] advertisingAgencies =
			{
				new AdvertisingTextAgency(2,2),
				new AdvertisingTextAgency(1,2),
				new AdvertisingGraphicAgency(3,1),
				new AdvertisingGraphicAgency(4,3)
			};

			ITravelAgency[] travelAgencies =
			{
				new PolandTravelAgency(accomodationData,reviewData,photosData,tripsData),
				new ItalyTravelAgency(accomodationData,reviewData,photosData,tripsData),
				new FranceTravelAgency(accomodationData,reviewData,photosData,tripsData)
			};

            while (true)
            {
				Console.Clear();


				offerWebsite = new OfferWebsite();
				AdvertisingAgency tmpAdvertisingAgency;
				ITravelAgency tmpTravelAgency;

				for(int i = 0; i < WebsitePermanentOfferCount; i++)
				{
					tmpAdvertisingAgency = advertisingAgencies[rd.Next() % advertisingAgencies.Length];
					tmpTravelAgency = travelAgencies[rd.Next() % travelAgencies.Length];
					offerWebsite.AddOffer(tmpAdvertisingAgency.CreateOffer(tmpTravelAgency, false));
				}

				for(int i = 0; i < WebsiteTemporaryOfferCount; i++)
				{
					tmpAdvertisingAgency = advertisingAgencies[rd.Next() % advertisingAgencies.Length];
					tmpTravelAgency = travelAgencies[rd.Next() % travelAgencies.Length];
					offerWebsite.AddOffer(tmpAdvertisingAgency.CreateOffer(tmpTravelAgency, true));
				}

				offerWebsite.Present();
                offerWebsite.Present();
                offerWebsite.Present();


                if (HandleInput()) break;
			}
		}
		bool HandleInput()
		{
			var key = Console.ReadKey(true);
			return key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q;
		}
    }
}

