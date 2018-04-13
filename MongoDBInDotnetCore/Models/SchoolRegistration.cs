using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBInDotnetCore.Models
{
    public class SchoolRegistration
    {
        public Guid Id { get; set; }

        [Required]
        public string SchoolCode { get; set; }
        public string NumberOfStudents { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PIN { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string NameOfSPOC { get; set; }
        public string SPOCEmailId { get; set; }
        public string SPOCContactNumber { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }

    }
}
