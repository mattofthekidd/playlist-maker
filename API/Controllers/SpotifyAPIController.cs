using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class SpotifyAPIController : Controller {
    public IActionResult Index() {
        return View();
    }
}
