using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuppyApp.DTOS {
    public class UserProfileDTO {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal AddressLatitude { get; set; }
        public decimal AddressLongitude { get; set; }
        public string Photo { get; set; }
    }
}