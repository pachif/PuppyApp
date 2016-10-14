using System;
using System.ComponentModel.DataAnnotations;

namespace PuppyApp.Models {
    public class Pet : BaseEntityObject {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime BirthDate { get; internal set; }
        [Required]
        public string Specie { get; set; }
        public byte[] Photo { get; set; }
        // Foreign Key
        public int OwnerId { get; set; }
        // Navigation Prop
        public virtual Owner Owner { get; set; }
    }
}