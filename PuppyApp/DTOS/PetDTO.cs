using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuppyApp.DTOS {
    public class PetDTO {
        public int PetId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] Photo { get; set; }
        public string Specie { get; set; }
    }
}