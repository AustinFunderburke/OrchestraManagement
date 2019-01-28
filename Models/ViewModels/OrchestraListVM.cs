using OrchestraManagement.DbFirstData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement.Models.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class OrchestraListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        [DisplayName("Website Url")]
        public string WebsiteUrl { get; set; }
        [DisplayName("Number of Musicians")]
        public int NumMusician { get; set; }
        [DisplayName("Number of Orchestra")]
        public int NumOrchestra { get; set; }
    }
}
