using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PuppyApp.Models {
    public class UserProfile : BaseEntityObject {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Leaves { get; set; }
        public IEnumerable<Pet> Mascots { get; }
        public byte[] Photo { get; set; }
    }
}