using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitonMerit_ASP_Core.Model
{
    public class Meritlist
    {
        public int Id { get; set; }
        public int Student_participateId { get; set; }
        public Student_participate Student_participate { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }
       
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Required]
        public int Marks { get; set; }



    }
}
