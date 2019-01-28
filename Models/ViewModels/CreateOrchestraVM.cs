using OrchestraManagement.DbFirstData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement.Models.ViewModels
{
    public class CreateOrchestraVM
    {
        public string Name { get; set; }
        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }
        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        [DisplayName("Website Url")]
        public string WebsiteUrl { get; set; }

        public Orchestra GetOrchestraInstance()
        {
            return new Orchestra
            {
                Id = 0, Name = Name,
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                City = City,
                State = State,
                ZipCode = ZipCode,
                WebsiteUrl = WebsiteUrl
            };
        }
    }
}
