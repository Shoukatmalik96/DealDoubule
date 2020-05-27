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
}