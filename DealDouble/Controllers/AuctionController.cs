using DealDouble.DataServices;
using DealDouble.Models;
using DealDouble.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index(int ? categoryID, string searchTerm , int ?  pageNo, int ? pageSize)
        {
            AuctionViewModel model = new AuctionViewModel();
            pageNo = pageNo ?? 1;
            pageSize = pageSize ?? 2;
            model.pageNo = pageNo;
            model.pageSize = pageSize;
            model.searchTerm = searchTerm;
            model.categoryID = categoryID;

            return View(model);
            
        }

        public ActionResult AuctionListing(int? categoryID, string searchTerm, int? pageNo, int? pageSize)
        {
            AuctionListingViewModel model = new AuctionListingViewModel();
            pageNo = pageNo ?? 1;
            pageSize = pageSize ?? 2;
            model.totalItems = AuctionsServices.Instance.GetAuctionCout();
            model.Auctions = AuctionsServices.Instance.SearchAuction(categoryID, searchTerm, pageNo, pageSize);
            model.Pager = new BaseViewModel.Pager(model.totalItems, pageNo, Convert.ToInt32(pageSize));
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult AddAuction()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddAuction(Auction auction)
        {
            AuctionsServices.Instance.SaveAuctions(auction);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult UpdateAuction(int ID)
        {
            Auction model = new Auction();
            model = AuctionsServices.Instance.GetAuctionByID(ID);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult UpdateAuction(Auction auction)
        {
            AuctionsServices.Instance.UpdateAuctions(auction);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult DeleteAuction(int ID)
        {
            Auction model = new Auction();
            model = AuctionsServices.Instance.GetAuctionByID(ID);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteAuction(Auction auction)
        {
            AuctionsServices.Instance.DeleteAuctions(auction);
            return RedirectToAction("index");
        }
    }
}