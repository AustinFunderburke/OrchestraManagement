using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class InstrumentController : Controller
    {
        /// <summary>
        /// This is the set up for injecting the IOrchestraRepository into the Home Controller
        /// </summary>
        private IOrchestraRepository _repo;

        /// <summary>
        /// This injects the IOrchestraRepository into the InstrumentController constructor
        /// </summary>
        public InstrumentController(IOrchestraRepository repo)
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
        /// This brings in a musician Id finds the musician makes a new 
        /// instrument, attached it to that musician and then sends it tho the view
        /// </summary>
        /// <param name="musicianId"></param>
        /// <returns>vm</returns>
        public IActionResult Create([Bind(Prefix = "id")] int musicianId)
        {


            var vm = new Instrument();
            vm.MusicianId = musicianId;

            var musician = _repo.FindMusician(musicianId);
            ViewData["Musician"] = musician;

            return View(vm);
        }

        /// <summary>
        /// This brings in an instrument object, checks to 
        /// make sure that the object is correct, sends the instrument to CreateInstrument in the
        /// IOrchestraRepository using the DbOrchestraRepository method,
        /// then redirects to the Musician Details page. If ther is an issue it sends 
        /// back theCreate Instument view with the information in it
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateInstrument(instrument);
                return RedirectToAction("Details", "Musician", new { id = instrument.MusicianId });
            }

            return View("Create", instrument);
        }

        /// <summary>
        /// This is the get edit for instrument by passing in the id, finding the insrument using the id, 
        /// see if the object is equal to null if so then redirecting you to the Musician Detils page,
        /// if there is no issue then return the view with the information in it. View date passed 
        /// for the view to use.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var instrument = _repo.FindInstrument(id);
            if (instrument == null)
            {
                return RedirectToAction("Details", "Musician", new { id = instrument.MusicianId });
            }

            var musician = _repo.FindMusician(instrument.MusicianId);
            ViewData["Musician"] = musician;

            return View(instrument);
        }
         
        /// <summary>
        /// This is the post Edit it takes the instrument object and puts it in the 
        /// database and returns you to Musician Details. If there is an error 
        /// it returns the edit view and the information in it.
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateInstrument(instrument);
                return RedirectToAction("Details", "Musician", new { id = instrument.MusicianId });
            }

            return View("Edit", instrument);
        }

        /// <summary>
        /// This is the get delete and it delets an instrument object from the database by looking for intrument by the id that was passed in,
        /// then checking to see if its null, if it is then it sends you back to Musician Details, 
        /// if not then it sends back the view with the instrument in it. The ViewData sends information about the musician to the view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var instrument = _repo.FindInstrument(id);
            if (instrument == null)
            {
                return RedirectToAction("Details", "Musician", new { id = instrument.MusicianId });
            }

            var musician = _repo.FindMusician(instrument.MusicianId);
            ViewData["Musician"] = musician;

            return View(instrument);
        }

        /// <summary>
        /// This is the post delete and it finds the instrument object
        /// in the database and delets it, then sends you back to Musician Details page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var instrument = _repo.FindInstrument(id);

            _repo.DeleteInstrument(id);

            return RedirectToAction("Details", "Musician", new { id = instrument.MusicianId });
        }

    }
}
