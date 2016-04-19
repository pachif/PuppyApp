using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace PuppyApp.Models {
    public class BaseEntityObject {
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }

        public Image GetBitmap(byte[] photo) {
            using (var stream = new MemoryStream(photo)) {
                return Image.FromStream(stream);
            }
        }
    }
}