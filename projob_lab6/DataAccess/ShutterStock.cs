using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.DataAccess
{
	public class PhotMetadata
	{
		public string Name { get; set; }
		public string Camera { get; set; }
		public double[] CameraSettings { get; set; }
		public DateTime Date { get; set; }
		public string WidthPx { get; set; }//Encrypted
		public string HeightPx { get; set; }//Encrypted
		public double Longitude { get; set; }
		public double Latitude { get; set; }
	}
	class ShutterStockDatabase : MyIteratorAggregate<PhotMetadata>
	{
		public PhotMetadata[][][] Photos;

		public MyIterator<PhotMetadata> GetMyEnumerator()
		{
			return new ShutterStockDatabaseIterator(Photos);
		}
	}

	class ShutterStockDatabaseIterator : MyIterator<PhotMetadata>
	{
		int[] indexes;
		PhotMetadata[][][] photos;
		public ShutterStockDatabaseIterator(PhotMetadata[][][] photos)
		{
			this.photos = photos;
			indexes = new int[3] { 0, 0, -1 };
		}

		public PhotMetadata GetNext()
		{
			try
			{
				increaseIndexes(indexes);
				while (
				photos[indexes[0]] == null ||
				photos[indexes[0]].Length == 0 ||
				photos[indexes[0]][indexes[1]] == null ||
				photos[indexes[0]][indexes[1]].Length == 0 ||
				photos[indexes[0]][indexes[1]][indexes[2]] == null
					)
				{
					increaseIndexes(indexes);
				}
			}
			catch
			{
				throw new Exception("Use HasNext method before this");
			}

			return photos[indexes[0]][indexes[1]][indexes[2]];
		}

		public bool HasNext()
		{
			int[] tmpIndexes = { this.indexes[0],this.indexes[1],this.indexes[2]};
			if (!increaseIndexes(tmpIndexes))
			{
				Reset();
				return false;
			}
			while (
				photos[tmpIndexes[0]] == null ||
				photos[tmpIndexes[0]].Length == 0 ||
				photos[tmpIndexes[0]][tmpIndexes[1]] == null ||
				photos[tmpIndexes[0]][tmpIndexes[1]].Length == 0 ||
				photos[tmpIndexes[0]][tmpIndexes[1]][tmpIndexes[2]] == null
				)
			{
				if(!increaseIndexes(tmpIndexes))
				{
					Reset();
					return false;
				}
			}
			return true;
		}
		public void Reset()
		{
			indexes = new int[3] { 0, 0, -1 };
		}
		public bool increaseIndexes(int[] indexes)
		{
			if (photos[indexes[0]] == null ||
				photos[indexes[0]].Length == 0 ||
				photos[indexes[0]][indexes[1]] == null ||
				photos[indexes[0]][indexes[1]].Length == 0)
			{
				return false;
			}
			if (indexes[2] + 1 < photos[indexes[0]][indexes[1]].Length)
			{
				indexes[2]++;
			}
			else
			{
				indexes[2] = 0;
				if (indexes[1] + 1 < photos[indexes[0]].Length)
				{
					indexes[1]++;
				}
				else
				{
					indexes[1] = 0;
					if (indexes[0] + 1 < photos.Length)
					{
						indexes[0]++;
					}
					else
					{
						Reset();
						return false;
					}
				}
			}
			return true;
		}

	}
}
