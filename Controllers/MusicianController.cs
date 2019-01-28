using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrchestraManagement.DbFirstData;
using OrchestraManagement.Services;

/// <summary>
/// Program:             Orchestra Management
/// Developer:           James Austin Funderburke
/// Contact Information: jafunderburke77@gmail.com
/// </summary>

namespace OrchestraManagement.Controllers
{
    
    public class MusicianController : Controller
    {
        /// <summary>
        /// This is the set up for injecting the IOrchestraRepository into the MusicianController
        /// </summary>
        private IOrchestraRepository _repo;

        /// <summary>
        /// This injects the IOrchestraRepository into the MusicianController constructor
        /// </summary>
        public MusicianController(IOrchestraRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// This reades all the Orchestras
        /// </summary>
        /// <returns>model</returns>
        public IActionResult Index()
        {
            var model = _repo.ReadAllOrchestras();
            return View(model);
        }

        // <summary>
        /// This is the get create and it sends you the create view by passing in the orchestra id associated to the musician being created.
        /// Then it creates a new msician objectthen attaches it to the orchestra, then returns the view. View data is for orchestra information in the view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create([Bind(Prefix = "id")]int orchestraId)
        {
            var musician = new Musician();
            musician.OrchestraId = orchestraId;

            var orchestra = _repo.FindOrchestra(orchestraId);
            ViewData["Orchestra"] = orchestra;

            return View();
        }

        /// <summary>
        /// This is the post create and it pass's in a View Model, then checks to see if the object is valid
        /// then it gets the instance of musician with the view model info thenputs it in the Database, then redirects you to the Orchestra Index.
        /// If there is an issue then it sends back your information int eh view.
        /// </summary>
        /// <param name="musician"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Musician musician)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateMusician(musician);
                return RedirectToAction("Details", "Orchestra", new { id = musician.OrchestraId });
            }

            return View(musician);
        }

        /// <summary>
        /// This is the get Edit it finds the musician in the database with the id thats passed in,
        /// then if its checked to see if it is null and if it is then it sends you back to the
        /// orchestra index, if not then it sends you to the musician Edit view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var musician = _repo.FindMusician(id);
            var orchestra = _repo.FindOrchestra(musician.OrchestraId);

            if (musician == null)
            {
                return RedirectToAction("Details", "Orchestra", new { id = musician.OrchestraId });
            }
            ViewData["Orchestra"] = orchestra;
            return View(musician);
        }

        /// <summary>
        /// This is the post Edit. This will pass in the musician object and check to see if it is valid,
        /// if its is then it sends the updated object to the update method and it stores it in the database
        /// and returns you to the orchestra Details page. If the object is not valid then it sends back the view with the user information in it.
        /// </summary>
        /// <param name="musician"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Musician musician)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateMusician(musician);
                return RedirectToAction("Details", "Orchestra", new { id = musician.OrchestraId });
            }

            return View("Edit", musician);
        }

        /// <summary>
        /// This is the get delete. It takes in an id and finds the musician object then checks
        /// to see if it is null if it is then it redirects to the Details Index page if not then 
        /// it pass's the information on to the view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var musician = _repo.FindMusician(id);
            if (musician == null)
            {
                return RedirectToAction("Details", "Orchestra", new { id = musician.Orchestra.Id });
            }
            return View(musician);
        }

        /// <summary>
        /// This is the post delete. this takes in an id of the musician desired to delete and finds 
        /// it then delets it from the database, then returns yuo to the orchestra Details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var musician = _repo.FindMusician(id);

            _repo.DeleteMusician(id);

            return RedirectToAction("Details", "Orchestra", new { id = musician.Orchestra.Id });
        }

        /// <summary>
        /// This is the details method. It takes in an id for a musician and finds the object,
        /// then checks to see if it is null and if it is it sends you back to the orchestra Details.
        /// If its not null then it sends the musician object information.
        /// </summary>
        /// <param name="musicianId"></param>
        /// <returns>musician view</returns>
        public IActionResult Details([Bind(Prefix = "id")]int musicianId)
        {
            Musician musician = _repo.FindMusician(musicianId);
            if (musician == null)
            {
                return RedirectToAction("Index", "Orchestra");
            }

            return View(musician);
        }
    }
}