using DealDouble.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Models
{
    public class AuctionViewModel:BaseViewModel
    {
        
        public Auction auction { get; set; }
        public int ? pageNo { get; set; }
        public int ? pageSize { get; set; }
        public string searchTerm { get; set; }
        public int ? categoryID { get; set; }
    }

    public class AuctionListingViewModel : BaseViewModel
    {
        public List<Auction> Auctions { get; set; }
        public Auction auction { get; set; }
        public Pager Pager { get; set; }
        public int totalItems { get; set; }
    }

    public class AuctionsEntityViewModel 
    {
       public int AuctionID { get; set; }
       public string Title { get; set; }
       public string AuctionPictures { get; set; }
       public string Description { get; set; }
       public decimal? ActualAmount { get; set; }
       public DateTime? StartingDate { get; set; }
       public DateTime? EndingDate { get; set; }

    }
}