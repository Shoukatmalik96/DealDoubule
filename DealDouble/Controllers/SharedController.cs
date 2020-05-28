using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Controllers
{
    public class SharedController : Controller
    {
        
		[HttpPost]
		public JsonResult UploadImage()
		{
			JsonResult result = new JsonResult();
			List<object> picturesJSON = new List<object>();

			var picture = Request.Files[0];
			var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);
			var path = Server.MapPath("~/Content/images/") + fileName;
			picture.SaveAs(path);

			picturesJSON.Add(new { pictureURL = fileName });
			result.Data = picturesJSON;

			return result;
		}
	}
}