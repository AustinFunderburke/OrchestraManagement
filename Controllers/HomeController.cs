using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrchestraManagement.Models;
using OrchestraManagement.DbFirstData;
using OrchestraManagement.Services;
using OrchestraManagement.Models.ViewModels;

/// <summary>
/// Program:             Orchestra Management
/// Developer:           James Austin Funderburke
/// Contact Information: jafunderburke77@gmail.com
/// </summary>

namespace OrchestraManagement.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This is the set up for injecting the IOrchestraRepository into the Home Controller
        /// </summary>
        private IOrchestraRepository _repo;

        /// <summary>
        /// This injects the IOrchestraRepository into the Home Controller constructor
        /// </summary>
        public HomeController(IOrchestraRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// This reads all the orchestras available in the database using a View Model and with a select
        /// giving the properties designated. this makes a list of the Orchestra in the view.
        /// </summary>
        /// <returns>model</returns>
        public IActionResult Index()
        {
            var model = _repo.ReadAllOrchestras()
               .Select(o => new OrchestraListVM
               {
                   Id = o.Id,
                   Name = o.Name,
                   AddressLine1 = o.AddressLine1,
                   AddressLine2 = o.AddressLine2,
                   City = o.City,
                   State = o.State,
                   ZipCode = o.ZipCode,
                   WebsiteUrl = o.WebsiteUrl,
                   NumMusician = o.Musician.Count()

               });

            return View(model);
        }
        /// <summary>
        /// Standard About method
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";

            return View();
        }
        /// <summary>
        /// Standard Contact method
        /// </summary>
        /// <returns></returns>
        public IActionResult Contact()
        {
            // ViewData["Message"] = "Your contact page.";

            return View();
        }
        /// <summary>
        /// Standard Privacy method
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// This handels any errors 
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
