using Microsoft.Practices.Unity;
using Unity.Mvc4;
using System.Web.Mvc;
using FlickrApp.Repository;

namespace FlickrApp.Controllers
{
    /// <summary>
    /// The home controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
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
        [HttpPost]
        public ActionResult GetImages(string tags)
        {
            return Json(_repository.GetImagesByTags(tags), JsonRequestBehavior.DenyGet);
        }

    }
}
