using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrchestraManagement.DbFirstData
{
    /// <summary>
    ///         
    /// </summary>
    public partial class Musician
    {
        public Musician()
        {
            Instrument = new HashSet<Instrument>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Section { get; set; }
        public bool SectionLeader { get; set; }
        public int OrchestraId { get; set; }

        public Orchestra Orchestra { get; set; }
        public ICollection<Instrument> Instrument { get; set; }
    }
}
