using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyApp.Models {
    public class Owner {
        public int Id { get; set; }
        public string IDCard { get; set; }
        public string FullName { get; set; }
        /// <summary>
        /// Gets or sets the collection of pets which user profile owns. EF Navigation Property.
        /// </summary>
        public virtual ICollection<Pet> Mascots { get; set; }

        internal void UpdateOwnership() {
            foreach (var mascot in Mascots) {
                mascot.Owner = this;
            }
        }
    }
}
