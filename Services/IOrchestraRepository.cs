using OrchestraManagement.DbFirstData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Program:             Orchestra Management
/// Developer:           James Austin Funderburke
/// Contact Information: jafunderburke77@gmail.com
/// </summary>

namespace OrchestraManagement.Services
{
    /// <summary>
    /// This is the interface repository made to inject the DbOrchestraRepository into other classes.
    /// More description of what theses do are in the DbOrchestraRepository.
    /// </summary>
    public interface IOrchestraRepository
    {
        Orchestra CreateOrchestra(Orchestra orchestra);
        void DeleteOrchestra(int id);
        Orchestra FindOrchestra(int id);
        ICollection<Orchestra> ReadAllOrchestras();
        void UpdateOrchestra(Orchestra orchestra);

        Musician CreateMusician(Musician musician);
        void DeleteMusician(int musicianId);
        Musician FindMusician(int musicianId);
        void UpdateMusician(Musician musician);

        Instrument CreateInstrument(Instrument instrument);
        void DeleteInstrument(int instrumentId);
        Instrument FindInstrument(int instrumentId);
        Instrument UpdateInstrument(Instrument instrument);
    }
}
