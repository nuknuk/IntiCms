using System;
using System.Linq;
using System.Web.Mvc;

using IntiCms.Interfaces;
using IntiCms.ValueObjects;

namespace IntiCms.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntryAdapter _EntryAdapter;

        public HomeController()
        {
            _EntryAdapter = EntryService.Instance.Adapter;
        }

        public ActionResult Index(string id)
        {
            var result = new Entry[0];
            
            string tag = id ?? "news";
            
            result = _EntryAdapter.All().Where(e => !(DateTime.UtcNow > e.VisibleOn) && e.Tags.Contains(tag)).ToArray();

            return View(result);
        }
    }
}