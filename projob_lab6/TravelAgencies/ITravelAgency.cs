using projob_lab6.Codings.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;

namespace TravelAgencies.Agencies
{

	// for different agencies 
	public interface ITravelAgency
	{
		ITrip CreateTrip();
		IPhoto CreatePhoto();
		IReview CreateReview();
	}

	public abstract class TravelAgency : ITravelAgency
	{
		public MyIterator<ListNode> bookingDatabaseIterator;
		public MyIterator<BSTNode> oysterDatabaseIterator;
		public MyIterator<PhotMetadata> shutterStockDatabaseIterator;
		public MyIterator<TripAdvisor> tripAdvisorDatabaseIterator;
		public abstract IPhoto CreatePhoto();

		public abstract IReview CreateReview();

		public abstract ITrip CreateTrip();

	}

	public interface ITrip
	{
		void Print();
	}
	public abstract class Trip : ITrip
	{
		public int countOfDays;
		public List<TripAdvisor> tripAdvisors;
		public List<ListNode> listBookings;
		public double averageRating()
		{
			CodecDecorator codecDecorator = new TripAdvisorDecorator();
			double sum = 0;
			foreach (TripAdvisor tripAdvisor in tripAdvisors)
			{
				sum += int.Parse(codecDecorator.encoding(tripAdvisor.Rating));
			}
			foreach (ListNode listNode in listBookings)
			{
				sum += int.Parse(codecDecorator.encoding(listNode.Rating));
			}
			return sum / (countOfDays * 4);
		}
		public double sumPrice()
		{
			CodecDecorator codecDecorator = new TripAdvisorDecorator();
			double sum = 0;
			foreach(TripAdvisor tripAdvisor in tripAdvisors)
			{
				sum += int.Parse(codecDecorator.encoding(tripAdvisor.Price));
			}
			foreach (ListNode listNode in listBookings)
			{
				sum += int.Parse(codecDecorator.encoding(listNode.Price));
			}
			return sum;
		}
		public abstract void Print();
	}

	public interface IPhoto
	{
		void Print();
	}
	public abstract class Photo : IPhoto
	{
		public string widthPx;
		public string heightPx;
		public string name;
		public CodecDecorator codecDecorator;
		public string encryptedWidthOrHeightPx(string text)
		{
			return codecDecorator.encoding(text);
		}
		public abstract void Print();
	}
	public interface IReview
	{
		void Print();
	}
	public abstract class Review : IReview
	{
		public string userName;
		public string review;
		public abstract void Print();
	}

}
