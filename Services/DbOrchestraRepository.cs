using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrchestraManagement.DbFirstData;

/// <summary>
/// Program:             Orchestra Management
/// Developer:           James Austin Funderburke
/// Contact Information: jafunderburke77@gmail.com
/// </summary>

namespace OrchestraManagement.Services
{
    /// <summary>
    /// DbOrchestraRepository is extending the IOrchestraRepository here
    /// </summary>
    ///
    public class DbOrchestraRepository : IOrchestraRepository
    {
        /// <summary>
        /// This sets up for injecting the OrchestraDbContext into the 
        /// DbOrchestraRepository constructor
        /// </summary>
        private OrchestraDbContext _db;

        /// <summary>
        /// This is injecting the OrchestraDbContext into the DbOrchestraRepository
        /// </summary>
        /// <param name="db"></param>
        public DbOrchestraRepository(OrchestraDbContext db)
        {
            _db = db;
        }

        #region Orchestra 

        /// <summary>
        /// This Creates an Orchestra by takeing in a orchestra object and checks to make sure it is not null the sets
        /// the Id to zero and adds the object to the database, then saves the changes. If the
        /// the object is null then it returns the view object information unsaved. 
        /// </summary>
        /// <param name="orchestra"></param>
        /// <returns>orchestra</returns>
        public Orchestra CreateOrchestra(Orchestra orchestra)
        {
            if (orchestra != null)
            {
                 orchestra.Id = 0;
                _db.Orchestra.Add(orchestra);
                _db.SaveChanges();
            }

            return orchestra;
        }

        /// <summary>
        /// This Deletes an Orchestra by taking in its id, finding it in the database, then
        /// removing it from the database, then saveing.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOrchestra(int id)
        {
            Orchestra orchestra = _db.Orchestra.Find(id);
            _db.Orchestra.Remove(orchestra);
            _db.SaveChanges();
        }

        /// <summary>
        /// This Finds an Orchestra by bringing in the id of the desired orchestra then eager loading 
        /// all its contents and attached objects and returning them.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Orchestra</returns>
        public Orchestra FindOrchestra(int id)
        {
            return _db.Orchestra.Include(o => o.Musician).ThenInclude(m => m.Instrument).FirstOrDefault(o => o.Id == id);
         
        }

        /// <summary>
        /// Reads All Orchestras from the database and its musicians and returns them.
        /// </summary>
        /// <returns></returns>
        public ICollection<Orchestra> ReadAllOrchestras()
        {
            return _db.Orchestra.Include(o => o.Musician).ToList();
        }

        /// <summary>
        /// Updates an Orchestra that is passed in then cheked to make sure it is not null then it finds the old
        /// orchestra using its Id, makes sure that its not equal to null then replaces all the old properties
        /// with the new ones, and saves it.
        /// </summary>
        /// <param name="orchestra"></param>
        public void UpdateOrchestra(Orchestra orchestra)
        {
            if (orchestra != null)
            {
                var oldOrchestra = FindOrchestra(orchestra.Id);
                if (oldOrchestra != null)
                {
                    oldOrchestra.Id = orchestra.Id;
                    oldOrchestra.Name = orchestra.Name;
                    oldOrchestra.AddressLine1 = orchestra.AddressLine1;
                    oldOrchestra.AddressLine2 = orchestra.AddressLine2;
                    oldOrchestra.City = orchestra.City;
                    oldOrchestra.State = orchestra.State;
                    oldOrchestra.ZipCode = orchestra.ZipCode;
                    oldOrchestra.WebsiteUrl = orchestra.WebsiteUrl;
                    _db.SaveChanges();
                }
            }
        }
        #endregion

        #region Musician

        /// <summary>
        /// This Creates an Musician by takeing in a orchestra object and checks to make sure it is not null the sets
        /// the Id to zero and adds the object to the database, then saves the changes. If the
        /// the object is null then it returns the view object information unsaved. 
        /// </summary>
        /// <param name="musician"></param>
        /// <returns>musician</returns>
        public Musician CreateMusician(Musician musician)
        {
            if (musician != null)
            {
                musician.Id = 0;
                _db.Musician.Add(musician);
                _db.SaveChanges();
            }

            return musician;
        }

        /// <summary>
        /// This Finds an Musician by bringing in the id of the desired musician then eager loading 
        /// all its contents and attached objects and returning them.
        /// </summary>
        /// <param name="musicianId"></param>
        /// <returns>musician</returns>
        public Musician FindMusician(int musicianId)
        {
            Musician musician = _db.Musician.Include(m => m.Orchestra).Include(m => m.Instrument).FirstOrDefault(m => m.Id == musicianId);
            return musician;
        }

        /// <summary>
        /// This Deletes an Musician by taking in its id, finding it and its attached objects in the database, then
        /// removing it from the database, then saveing.
        /// </summary>
        /// <param name="musicianId"></param>
        public void DeleteMusician(int musicianId)
        {
            Musician musician = _db.Musician.Include(m => m.Instrument).FirstOrDefault(m => m.Id == musicianId);
            if (musician != null)
            {
                _db.Musician.Remove(musician);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Updates an Musician that is passed in then checked to make sure it is not null then it finds the old
        /// musician using its Id, makes sure that its not equal to null ,then replaces all the old properties
        /// with the new ones, and saves it.
        /// </summary>
        /// <param name="musician"></param>
        public void UpdateMusician(Musician musician)
        {
            if (musician != null)
            {
                var oldMusician = _db.Musician.FirstOrDefault(r => r.Id == musician.Id);
                if (oldMusician != null)
                {
                    oldMusician.FirstName = musician.FirstName;
                    oldMusician.LastName = musician.LastName;
                    oldMusician.Section = musician.Section;
                    oldMusician.SectionLeader = musician.SectionLeader;
                    _db.SaveChanges();
                }
            }
        }
        #endregion

        #region Instrument

        /// <summary>
        /// This Creates an Instrument by takeing in a instrument object and checks to make sure it is not null the sets
        /// the Id to zero and adds the object to the database, then saves the changes. If the
        /// the object is null then it returns the view object information unsaved. 
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns>instrument</returns>
        public Instrument CreateInstrument(Instrument instrument)
        {
            if (instrument != null)
            {
                Musician musician = _db.Musician.FirstOrDefault(m => m.Id == instrument.MusicianId);

                if (musician != null)
                {
                    instrument.Id = 0;
                    _db.Add(instrument);
                    _db.SaveChanges();
                }
            }

            return instrument;
        }

        /// <summary>
        /// This Deletes an Instrument by taking in its id, finding it by its attached objects in the database, then
        /// removing it from the database, then saveing.
        /// </summary>
        /// <param name="instrumentId"></param>
        public void DeleteInstrument(int instrumentId)
        {
            Instrument instrument = _db.Instrument.Include(i => i.Musician).FirstOrDefault(i => i.Id == instrumentId);
            if (instrument != null)
            {

                _db.Instrument.Remove(instrument);
                _db.SaveChanges();

            }

        }

        /// <summary>
        /// This Finds an Instrument by bringing in the id of the desired instrument then eager loading 
        /// all its contents and attached objects and returning them.
        /// </summary>
        /// <param name="instrumentId"></param>
        /// <returns>instrument</returns>
        public Instrument FindInstrument(int instrumentId)
        {
            Instrument instrument = _db.Instrument.Include(i => i.Musician).FirstOrDefault(i => i.Id == instrumentId);
            return instrument;
        }

        /// <summary>
        /// Updates an Instrument that is passed in then checked to make sure it is not null then it finds the old
        /// instrument using its Id, makes sure that its not equal to null ,then replaces all the old properties
        /// with the new ones, and saves it.
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns>instrument</returns>
        public Instrument UpdateInstrument(Instrument instrument)
        {
            if (instrument != null)
            {
                var oldInst = _db.Instrument.FirstOrDefault(i => i.Id == instrument.Id);

                if (oldInst != null)
                {
                    oldInst.SerialNumber = instrument.SerialNumber;
                    oldInst.Description = instrument.Description;
                    oldInst.MaintenanceDate = instrument.MaintenanceDate;
                    oldInst.Condition = instrument.Condition;
                    _db.SaveChanges();
                }
            }

            return instrument;
        }
        #endregion
    }
}
