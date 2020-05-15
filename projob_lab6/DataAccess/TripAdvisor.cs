using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.DataAccess
{
	public class TripAdvisor
	{
		public TripAdvisor(Guid id, string name, string price, string rating, string country)
		{
			Id = id;
			Name = name;
			Price = price;
			Rating = rating;
			Country = country;
		}
		public Guid Id;
		public string Name { get; set; }
		public string Price { get; set; }//Encrypted
		public string Rating { get; set; }//Encrypted
		public string Country { get; set; }

	}
	public class TripAdvisorDatabase : MyIteratorAggregate<TripAdvisor>
	{
		public Guid[] Ids;
		public Dictionary<Guid, string>[] Names { get; set; }
		public Dictionary<Guid, string> Prices { get; set; }//Encrypted
		public Dictionary<Guid, string> Ratings { get; set; }//Encrypted
		public Dictionary<Guid, string> Countries { get; set; }

		public MyIterator<TripAdvisor> GetMyEnumerator()
		{
			return new TripAdvisorDatabaseIterator(this);
		}
	}

	public class TripAdvisorDatabaseIterator : MyIterator<TripAdvisor>
	{
		TripAdvisorDatabase database;
		int actualIndexGuid;

		public TripAdvisorDatabaseIterator(TripAdvisorDatabase database)
		{
			this.database = database;
			actualIndexGuid = -1;
		}

		public TripAdvisor GetNext()
		{
			
			while (true)
			{
				if(++actualIndexGuid >= database.Ids.Length)
				{
					throw new Exception("Use HasNext method before this");
				}
				string name = null;
				ArrayIterator<Dictionary<Guid, string>> NamesIterator = new ArrayIterator<Dictionary<Guid, string>>(database.Names);
				while (NamesIterator.HasNext())
				{
					if (NamesIterator.GetNext().TryGetValue(database.Ids[actualIndexGuid], out name))
					{
						break;
					}
				}
				if (name == null) continue;
				string price;
				if (!database.Prices.TryGetValue(database.Ids[actualIndexGuid], out price))
				{
					continue;
				}
				string rating;
				if (!database.Ratings.TryGetValue(database.Ids[actualIndexGuid], out rating))
				{
					continue;
				}
				string country;
				if (!database.Countries.TryGetValue(database.Ids[actualIndexGuid], out country))
				{
					continue;
				}
				return new TripAdvisor(database.Ids[actualIndexGuid], name,price,rating,country);
			}
			
		}

		public bool HasNext()
		{
			int tmpActualIndexGuid = actualIndexGuid;
			while (++tmpActualIndexGuid < database.Ids.Length)
			{
				string name = null;
				ArrayIterator<Dictionary<Guid, string>> NamesIterator = new ArrayIterator<Dictionary<Guid, string>>(database.Names);
				while (NamesIterator.HasNext())
				{
					if (NamesIterator.GetNext().TryGetValue(database.Ids[tmpActualIndexGuid], out name))
					{
						break;
					}
				}
				if (name == null) continue;
				string price;
				if (!database.Prices.TryGetValue(database.Ids[tmpActualIndexGuid], out price))
				{
					continue;
				}
				string rating;
				if (!database.Ratings.TryGetValue(database.Ids[tmpActualIndexGuid], out rating))
				{
					continue;
				}
				string country;
				if (!database.Countries.TryGetValue(database.Ids[tmpActualIndexGuid], out country))
				{
					continue;
				}
				return true;
			}
			Reset();
			return false;
		}

		public void Reset()
		{
			actualIndexGuid = -1;
		}
	}
	
}
