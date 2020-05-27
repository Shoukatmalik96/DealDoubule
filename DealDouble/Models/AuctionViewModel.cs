using DealDouble.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Models
{
    public class AuctionViewModel
    {
        public List<Auction> Auctions { get; set; }
        public Auction auction { get; set; }
    }
}