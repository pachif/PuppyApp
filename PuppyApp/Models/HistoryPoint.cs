using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PuppyApp.Models {
    public class HistoryPoint : BaseEntityObject {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime When { get; set; }
        [Required]
        public Location Location { get; set; }
        [Required]
        public int PetId { get; set; }
        public virtual Pet Mascot { get; set; }

        public int IllnessId { get; set; }
        public virtual Desease Illness { get; set; }
    }
}