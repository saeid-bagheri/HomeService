using HomeService.Models.Entities;

namespace HomeService.Repository
{
    public interface IBidReposiroty
    {
        List<Bid> BidList();
        void AddBid(Bid Bid);
        Bid GetBid(int id);
        void RemoveBid(int id);
        void UpdateBid(Bid Bid);
    }
}
