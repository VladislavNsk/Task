using System.IO;
using System.Web.Mvc;

using DocumentsStorage.Models;
using DocumentsStorage.Repositories;
using DocumentsStorage.Services;

namespace DocumentsStorage.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDocumentService _docuemnService;

        public HomeController()
        {
            _docuemnService = new DocumentService(new DocumentRepository());
        }

        public ActionResult Documents()
        {
            var userDocuments = _docuemnService.GetDocuments(User.Identity.Name);
            return View(userDocuments);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Document document)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (Request.Files.Count == 0 || Request.Files["file"] == null)
            {
                ModelState.AddModelError("", "Выбирите файл");
                return View();
            }

            var pathToFolder = Server.MapPath(string.Format("~/Documents/{0}", User.Identity.Name));
            Directory.CreateDirectory(pathToFolder);
            var pathToFile = Path.Combine(pathToFolder, Request.Files["file"].FileName);
            _docuemnService.Create(document, Request.Files["file"].InputStream, pathToFile);

            return RedirectToAction("Create");
        }
    }
}
