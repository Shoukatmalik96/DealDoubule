using DealDouble.CommonCode.Helpers;
using DealDouble.DataServices;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Services
{
	public class AuctionsServices
	{

		#region Define as Singleton
		private static AuctionsServices _Instance;
		public static AuctionsServices Instance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new AuctionsServices();
				}

				return (_Instance);
			}
		}
		private AuctionsServices()
		{
		}
		#endregion


		public Auction GetAuctionByID(int ID)
        {
			Auction auction = null ;
            using (var repo= DataContextHelper.GetPPDataContext())
            {
				var ppsql = PetaPoco.Sql.Builder.Select(@"*").From("Auctions auciton").Where("AuctionID= @0", ID);
				auction = repo.FirstOrDefault<Auction>(ppsql);
            }
			return (auction);
        }

		public List<Auction> GetAuctions()
		{
			List<Auction> auctions = null;
			using (var repo = DataContextHelper.GetPPDataContext())
			{
				var ppsql = PetaPoco.Sql.Builder.Select(@"*").From("Auctions");
				auctions = repo.Fetch<Auction>(ppsql);
			}
			return (auctions);
		}
		public void SaveAuctions(Auction auction)
		{
			using (var repo = DataContextHelper.GetPPDataContext())
			{
				repo.Insert(auction);
			}
		}
		public void UpdateAuctions(Auction auction)
		{
			using (var repo = DataContextHelper.GetPPDataContext())
			{
				repo.Update(auction);
				
			}

		}
		public void DeleteAuctions(Auction auction)
		{
			using (var repo = DataContextHelper.GetPPDataContext())
			{
				repo.Delete(auction);

			}

		}
	}
}