using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EpiServer_Setup.Models.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EpiServer_Setup.Controllers
{
    public class AboutUsPageTypeController : PageController<AboutUsPageType>
    {
        public ActionResult Index(AboutUsPageType currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }
    }
}