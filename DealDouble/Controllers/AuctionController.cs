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
        public ActionResult Index()
        {
            AuctionViewModel model = new AuctionViewModel();
            model.Auctions = AuctionsServices.Instance.GetAuctions();
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            else
            {
                return View(model);
            }
            
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