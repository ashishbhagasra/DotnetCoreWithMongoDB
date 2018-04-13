using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBInDotnetCore.Models
{
    public class TeacherRegistration
    {
        public Guid Id { get; set; }

        [Required]       
        public string TeacherName { get; set; }
        public string IsClassTeacher { get; set; }
        public string IsHOD { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SchoolId { get; set; }

    }
}
