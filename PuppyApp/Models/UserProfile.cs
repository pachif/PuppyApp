using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PuppyApp.Models {
    /// <summary>
    /// This is user profile information
    /// </summary>
    public class UserProfile : BaseEntityObject {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Leaves { get; set; }
        /// <summary>
        /// Gets or sets the collection of pets which user profile owns. EF Navigation Property.
        /// </summary>
        public virtual ICollection<Pet> Mascots { get; set; }
        /// <summary>
        /// Gets or sets the user profile picture
        /// </summary>
        public byte[] Photo { get; set; }
    }
}