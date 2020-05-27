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

		/// <summary>
		///  Search Auction Implementation 
		/// </summary>
		/// <param name="CategoryID"></param>
		/// <param name="SearchTerm"></param>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public List<Auction> SearchAuction(int ? CategoryID, string SearchTerm , int ? pageNo, int ? pageSize) 
		{
			pageNo = pageNo ?? 1;
			pageSize = pageSize ?? 2;
			List<Auction> auctions = new List<Auction>();

            using (var repo = DataContextHelper.GetPPDataContext())
            {
				var ppsql = PetaPoco.Sql.Builder.Select(@"*").From("Auctions");
                if (CategoryID != null )
                {
					auctions = repo.Fetch<Auction>(ppsql);
				}
                else if (!string.IsNullOrEmpty(SearchTerm))
                {
					ppsql.Where("auction.Title.ToLower() == @0", SearchTerm.ToLower());
					auctions = repo.Fetch<Auction>(ppsql);
				}

				auctions = repo.Fetch<Auction>(ppsql).ToList();
				var skipCount = (pageNo.Value - 1) * pageSize;
				auctions = auctions.Skip(Convert.ToInt32(skipCount)).Take(Convert.ToInt32(pageSize)).ToList();
			}
			return auctions;
		}

		/// <summary>
		/// Get Auction Count from database 
		/// </summary>
		/// <returns></returns>
		public int  GetAuctionCout()
		{
			int auctioncout = 0; 
			using (var repo = DataContextHelper.GetPPDataContext())
			{
				 auctioncout = repo.ExecuteScalar<int>("SELECT COUNT(*) FROM Auctions");
			}
			return auctioncout;
		}
	}
}