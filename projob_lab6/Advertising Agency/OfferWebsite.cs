
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;

namespace projob_lab6.Advertising_Agency
{
    public class OfferWebsite
    {
        List<Offer> offers;

        public OfferWebsite()
        {
            offers = new List<Offer>();
        }
        public void Present()
        {
            foreach(Offer offer in offers)
            {
                if (offer.limitPictureOrReview == 0)
                {
                    offers.Remove(offer);
                }
                else
                {
                    offer.Info();
                    Console.WriteLine();
                    Console.WriteLine();
                }

            }
        }

        public void AddOffer(Offer offer) { offers.Add(offer); }
    }
    public interface AdvertisingAgency
    {
        Offer CreateOffer(ITravelAgency travelAgency, bool temporary);
    }
    public class AdvertisingGraphicAgency : AdvertisingAgency
    {
        int limitPictureOrReview, counter;
        public AdvertisingGraphicAgency(int limitPictureOrReview, int counter)
        {
            this.limitPictureOrReview = limitPictureOrReview;
            this.counter = counter;
        }

        public Offer CreateOffer(ITravelAgency travelAgency, bool temporary = false)
        {
            if (temporary)
            {
                return new GraphicTemporaryOffer(travelAgency,counter, limitPictureOrReview);
            }
            else
            {
                return new GraphicPermanentOffer(travelAgency, limitPictureOrReview);
            }
        }
    }
    public class AdvertisingTextAgency : AdvertisingAgency
    {
        int limitPictureOrReview, counter;
        public AdvertisingTextAgency(int limitPictureOrReview, int counter)
        {
            this.limitPictureOrReview = limitPictureOrReview;
            this.counter = counter;
        }
        public Offer CreateOffer(ITravelAgency travelAgency, bool temporary = false)
        {
            if (temporary)
            {
                return new TextTemporaryOffer(travelAgency, counter, limitPictureOrReview) ;
            }
            else
            {
                return new TextPermanentOffer(travelAgency, limitPictureOrReview);
            }
        }
    }
    public abstract class Offer
    {
        public List<IPhoto> photos;
        public ITrip trip;
        public List<IReview> reviews;
        public int limitPictureOrReview;
        public Offer(ITravelAgency travelAgency, int limitPictureOrReview)
        {
            trip = travelAgency.CreateTrip();
            this.limitPictureOrReview = limitPictureOrReview;
            photos = new List<IPhoto>();
            reviews = new List<IReview>();
            for(int i = 0; i < limitPictureOrReview; i++)
            {
                photos.Add(travelAgency.CreatePhoto());
                reviews.Add(travelAgency.CreateReview());
            }

        }
        public abstract void Info();
    }
    public abstract class GraphicOffer : Offer
    {
        public GraphicOffer(ITravelAgency travelAgency, int limitPictureOrReview) : base(travelAgency,limitPictureOrReview) { }
    }

    public abstract class TextOffer : Offer
    {
        public TextOffer(ITravelAgency travelAgency, int limitPictureOrReview) : base(travelAgency,limitPictureOrReview) { }
    }


    public class GraphicTemporaryOffer : GraphicOffer
    {
        private int counter;
        public GraphicTemporaryOffer(ITravelAgency travelAgency, int counter, int limitPictureOrReview) : base(travelAgency, limitPictureOrReview)
        {
            this.counter = counter;
        }
        public override void Info()
        {
            if(counter > 0)
            {
                trip.Print();
                foreach (IPhoto photo in photos)
                {
                    photo.Print();
                }
                counter--;
            }
        }
    }
    public class GraphicPermanentOffer : GraphicOffer
    {
        public GraphicPermanentOffer(ITravelAgency travelAgency, int limitPictureOrReview) : base(travelAgency, limitPictureOrReview)
        {
        }

        public override void Info()
        {
            trip.Print();
            foreach (IPhoto photo in photos)
            {
                photo.Print();
            }
        }
    }
    public class TextTemporaryOffer : TextOffer
    {
        int counter;
        public TextTemporaryOffer(ITravelAgency travelAgency, int counter, int limitPictureOrReview) : base(travelAgency,limitPictureOrReview)
        {
            this.counter = counter;
        }

        public override void Info()
        {
            if (counter > 0)
            {
                trip.Print();
                foreach (IReview review in reviews)
                {
                    review.Print();
                }
                counter--;
            }
        }
    }
    public class TextPermanentOffer : TextOffer
    {
        public TextPermanentOffer(ITravelAgency travelAgency, int limitPictureOrReview) : base(travelAgency, limitPictureOrReview)
        {
        }
        public override void Info()
        {
            trip.Print();
            foreach (IReview review in reviews)
            {
                review.Print();
            }
        }
    }
}
