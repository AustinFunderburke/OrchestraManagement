using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrchestraManagement.DbFirstData;
using OrchestraManagement.Models.ViewModels;
using OrchestraManagement.Services;

/// <summary>
/// Program:             Orchestra Management
/// Developer:           James Austin Funderburke
/// Contact Information: jafunderburke77@gmail.com
/// </summary>

namespace OrchestraManagement.Controllers
{
    public class OrchestraController : Controller
    {
        /// <summary>
        /// This is the set up for injecting the IOrchestraRepository into the OrchestraController
        /// </summary>
        private IOrchestraRepository _repo;

        /// <summary>
        /// This injects the IOrchestraRepository into the OrchestraController constructor
        /// </summary>
        public OrchestraController(IOrchestraRepository repo)
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

        /// <summary>
        /// This is the get create and it sends you the create view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            
            return View();
        }

        /// <summary>
        /// This is the post create and it pass's in a View Model, then checks to see if the object is valid
        /// then it gets the instance of orchestra with the view model info thenputs it in the Database, then redirects you to the Orchestra Index.
        /// If there is an issue then it sends back your information int eh view.
        /// </summary>
        /// <param name="orchestraVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(CreateOrchestraVM orchestraVM)
        {
            if (ModelState.IsValid)
            {
                var orchestra = orchestraVM.GetOrchestraInstance();
                _repo.CreateOrchestra(orchestra);
                return RedirectToAction("Index", "Orchestra");
            }

            return View(orchestraVM);
        }

        /// <summary>
        /// This is the get Edit it finds the orchestra in the database with the id thats passed in 
        /// ,then if its checked to see if it is null and if it isthen it sends you back to the
        /// orchestra index, if not then it sends you to the orchestra Edit view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var orchestra = _repo.FindOrchestra(id);
            if (orchestra == null)
            {
                return RedirectToAction("Index");
            }
            return View(orchestra);
        }

        /// <summary>
        /// This is the post Edit. This will pass in the orchestra object and check to see if it is valid
        /// ,if its is then it sends the updated object to the update method and it stores it in the database
        /// and returns you to the orchestra index page. If the object is not valid then it sends back the view with the user information in it.
        /// </summary>
        /// <param name="orchestra"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(Orchestra orchestra)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateOrchestra(orchestra);
                return RedirectToAction("Index");
            }
            return View(orchestra);
        }

        /// <summary>
        /// This is the details method. It takes in an id fro a orchestra and finds the object,
        /// then checks to see if it is null and if it is it sends you back to the orchestra index.
        /// If its not null then it sends the orchestra object information.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var orchestra = _repo.FindOrchestra(id);
            if (orchestra == null)
            {
                return RedirectToAction("Index");
            }
            return View(orchestra);
        }

        /// <summary>
        /// This is the get delete. It takes in an id and finds the orchestra object thenn checks
        /// to see if it is null if it is then it redirects to the Orchestra Index page if not then 
        /// it pass's the information on to the view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var orchestra = _repo.FindOrchestra(id);
            if (orchestra == null)
            {
                return RedirectToAction("Index");
            }
            return View(orchestra);
        }

        /// <summary>
        /// This is the post delete. this takes in an id of the orchestra desired to delete and finds 
        /// it then delets it from the database, then returns yuo to the orchestra index.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteOrchestra(id);
            return RedirectToAction("Index");
        }

    }
}