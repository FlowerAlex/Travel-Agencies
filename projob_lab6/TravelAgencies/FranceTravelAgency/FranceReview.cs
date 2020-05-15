using System;
using TravelAgencies.Agencies;

namespace projob_lab6.TravelAgencies.FranceTravelAgency
{
    internal class FranceReview : Review
    {
        public FranceReview(string userName, string review)
        {
            this.userName = userName;
            this.review = review;
        }

        public override void Print()
        {
            Console.Write($"Review user: ");
            Console.WriteLine(userName);
            string[] newReview = review.Split(' ');
            for (int i = 0; i < newReview.Length; i++)
            {
                if (newReview[i].Length < 4) newReview[i] = "la";
            }
            Console.WriteLine(string.Join(" ",newReview));
        }
    }
}
