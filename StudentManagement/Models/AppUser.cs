using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class AppUser
    {
        
        public string password { get; set; }
        public string name { get; set; }

    }
}