using Amarok.Bootstrap.Domain.Repository;
using System.Web.Mvc;

namespace Amarok.Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        private IFeatureRepository featureRepository;

        public HomeController(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Seja bem vindo!";
            ViewBag.ActiveFeatures = this.featureRepository.ActiveFeatures();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
