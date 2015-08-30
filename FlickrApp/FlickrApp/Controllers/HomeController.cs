using System.Web.Mvc;
using FlickrApp.Repository;

namespace FlickrApp.Controllers
{
    /// <summary>
    /// The home controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: /Home/
        /// </summary>
        /// <returns>Returns an action result containing the view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets images from repository
        /// </summary>
        /// <param name="tags">Tags that should be searched for in the repository</param>
        /// <returns>A Json object containing the images from the repository</returns>
        public ActionResult GetImages(string tags)
        {                              
            var flickrRepository = new FlickrRepository();            

            var response = Json(flickrRepository.GetImagesByTags(tags), JsonRequestBehavior.AllowGet);             

            return response;
        }

    }
}
