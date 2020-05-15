using System;
using TravelAgencies.Agencies;

namespace projob_lab6.TravelAgencies.ItalyTravelAgency
{
    internal class ItalyReview : Review
    {
        public ItalyReview(string userName, string review)
        {
            this.userName = userName;
            this.review = review;
        }

        public override void Print()
        {
            Console.Write($"Review user: ");
            Console.WriteLine("Della_" + userName);
            Console.WriteLine(review);
        }
    }
}
