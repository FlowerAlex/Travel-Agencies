using System;

namespace TravelAgencies.Agencies
{
    public class PolandReview : Review
	{
		public PolandReview(string userName, string review)
		{
			this.userName = userName;
			this.review = review;
		}

		public override void Print()
		{
			Console.Write($"Review user: ");
			Console.WriteLine(userName.Replace('e', 'ę').Replace('a', 'ą'));
			Console.WriteLine(review.Replace('e', 'ę').Replace('a', 'ą'));
		}
	}
}
