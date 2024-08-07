using Microsoft.AspNetCore.Mvc;
using System.IO;


public class HomeController : Controller
{
    private static readonly string AngularDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "browser");

    [HttpGet("{pageName?}")]
    public IActionResult RenderPage(string pageName)
    {
        if (string.IsNullOrEmpty(pageName))
        {
            pageName = "index.html"; // Default to index.html if no pageName is provided
        }

        var pagePath = Path.Combine(AngularDirectory, pageName);

        if (System.IO.File.Exists(pagePath))
        {
            return PhysicalFile(pagePath, "text/html");
        }
        else
        {
            // Serve index.html if the requested file does not exist
            pagePath = Path.Combine(AngularDirectory, "index.html");
            if (System.IO.File.Exists(pagePath))
            {
                return PhysicalFile(pagePath, "text/html");
            }
            else
            {
                return NotFound("The requested page does not exist.");
            }
        }
    }
}