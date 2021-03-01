using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitonMerit_ASP_Core.Model
{
    public class Student_participate
    {

        public int Id { get; set; }
        
        [Required]
        public string Student_Name { get; set; }
        [Required]

        public int Student_age { get; set; }

        [Required]
        public string Mobile_Number { get; set; }
        
        [Required]
        public string Student_Address { get; set; }

        [Required]
        public string Father_Name { get; set; }
        

    }
}
