using System.ComponentModel.DataAnnotations.Schema;

namespace PuppyApp.Models {
    [ComplexType]
    public class Location {

        public Location() {
            // In order to let code first entity framework
        }

        public Location(decimal latitude, decimal longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}