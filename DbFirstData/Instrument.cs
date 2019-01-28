using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrchestraManagement.DbFirstData
{
    /// <summary>
    ///         
    /// </summary>
    public partial class Instrument
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? MaintenanceDate { get; set; } = DateTime.Now;
        public string Condition { get; set; }
        [Required]
        public int MusicianId { get; set; }

        public Musician Musician { get; set; }
    }
}
