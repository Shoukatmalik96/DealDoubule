using DealDouble.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.CommonCode.Helpers
{
    public class DataContextHelper
    {
		public static DealDoubleConnectionStringDB GetPPDataContext(bool enableAutoSelect = true)
		{
			return (GetNewDataContext("DealDoubleConnectionString", enableAutoSelect));
		}
		private static DealDoubleConnectionStringDB GetNewDataContext(string connectionStringName, bool enableAuctoSelect)
		{
			DealDoubleConnectionStringDB repository = new DealDoubleConnectionStringDB(connectionStringName);
			repository.EnableAutoSelect = enableAuctoSelect;
			return (repository);
		}
	}
}