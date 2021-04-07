using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Student
    {
        [Display(Name = "id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }

        [Required(ErrorMessage = "DOB is required.")]
        public DateTime dob { get; set; }

        [Required(ErrorMessage = "Registered date is required.")]
        public DateTime reg_date { get; set; }

        [Required(ErrorMessage = "AL stream is required.")]
        public string AL_stream { get; set; }
    }
}