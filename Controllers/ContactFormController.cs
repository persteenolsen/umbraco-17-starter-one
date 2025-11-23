using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging; 
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace MyProject.Controllers;

public class ContactFormController : SurfaceController
{
    public ContactFormController(
        IUmbracoContextAccessor umbracoContextAccessor,
        IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services,
        AppCaches appCaches,
        IProfilingLogger profilingLogger,
        IPublishedUrlProvider publishedUrlProvider) 
        : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {}

    [HttpPost]
    public IActionResult Submit(ContactFormViewModel model)
    {
        
        if (!ModelState.IsValid)
         {
            return CurrentUmbracoPage();
        }

        // Work with form data here ...
        
        // TempData["FormData"] = "TEST";

        TempData["Name"] = model.Name;
        TempData["Email"] = model.Email;
        TempData["Message"] = model.Message;

        /*String nameS = model.Name;
        String emailS = model.Email; 
        String messageS = model.Message;*/

        var paramValue = "valueByController";
        var queryString = QueryString.Create("param", paramValue);
        return RedirectToCurrentUmbracoPage(queryString);

        //return RedirectToCurrentUmbracoPage();
    }
}