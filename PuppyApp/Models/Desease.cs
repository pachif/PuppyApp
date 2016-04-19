﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PuppyApp.Models {
    
    public class Desease : BaseEntityObject {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}