using System.ComponentModel.DataAnnotations.Schema;

namespace PuppyApp.Models {
    [ComplexType]
    public class Location {

        public Location() {
            // In order to let code first entity framework
        }

        public Location(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}