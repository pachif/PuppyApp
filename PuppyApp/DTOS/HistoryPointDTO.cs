using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PuppyApp.DTOS {
    public class HistoryPointDTO : HistoryGeoJsonDTO {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int IllnessId { get; set; }
        public DateTime When { get; set; }
    }
}