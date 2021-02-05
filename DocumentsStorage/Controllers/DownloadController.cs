using System.Web.Mvc;

namespace DocumentsStorage.Controllers
{
    public class DownloadController : Controller
    {
        public FileResult Download(string path)
        {
            return File(path, "application/force- download", path.Substring(path.LastIndexOf('\\') + 1));
        }
    }
}
