using OrchestraManagement.DbFirstData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement.Models.ViewModels
{
    public class CreateInstrumentVM
    {
     
        [Required]
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? MaintenanceDate { get; set; }
        public string Condition { get; set; }
        public int MusicianId{ get; set; }
        public Musician Musician { get; set; }

        public Instrument GetInstrumentInstance()
        {
            return new Instrument
            {   Id = 0,
                SerialNumber = SerialNumber,
                Description = Description,
                MaintenanceDate = MaintenanceDate,
                Condition = Condition
            };
        }
    }
}
