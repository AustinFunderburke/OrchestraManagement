using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrchestraManagement.DbFirstData
{
    /// <summary>
    ///         
    /// </summary>
    public partial class Orchestra
    {
        public Orchestra()
        {
            Musician = new HashSet<Musician>();
        }

        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        //[Required]
        [Display(Name = "Adress Ln 1")]
        public string AddressLine1 { get; set; }
        
        [Display(Name = "Adress Ln 2")]
        public string AddressLine2 { get; set; }
        
        public string City { get; set; }

       // [Required]
        //[StringLength(2)]
        public string State { get; set; }

        [Display(Name = "Zip")]
        public string ZipCode { get; set; }

        [Display(Name = "Website Url")]
        public string WebsiteUrl { get; set; }

        public ICollection<Musician> Musician { get; set; }
    }
}
