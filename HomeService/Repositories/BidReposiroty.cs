using HomeService.DAL;
using HomeService.Models.Entities;

namespace HomeService.Repository
{
    public class BidRepository : IBidReposiroty
    {
        private readonly AppDbContext _appDbContext;

        public BidRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddBid(Bid Bid)
        {

                _appDbContext.Bids.Add(Bid);
                _appDbContext.SaveChanges();
        }

        public Bid GetBid(int id)
        {
            return _appDbContext.Bids.FirstOrDefault(c => c.Id == id);
        }



        public List<Bid> BidList()
        {
            var Bid = _appDbContext.Bids.ToList();
            return Bid;
        }

        public void RemoveBid(int id)
        {
            var BidRow = _appDbContext.Bids.FirstOrDefault(x => x.Id == id);
            _appDbContext.Bids.Remove(BidRow);
            _appDbContext.SaveChanges();
        }

        public void UpdateBid(Bid Bid)
        {
            var BidRow = _appDbContext.Bids.FirstOrDefault(x => x.Id == Bid.Id);
            BidRow.Status = Bid.Status;
            BidRow.ExpertSuggestedPrice = Bid.ExpertSuggestedPrice;
            BidRow.LastModifiedAt = Bid.LastModifiedAt;
            _appDbContext.SaveChanges();
        }
    }
}
