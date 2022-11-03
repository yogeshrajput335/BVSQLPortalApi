using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName{ get; set; }
        public string? PhoneNo{ get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        [ForeignKey("Employee")]
        public int? ReferBy { get; set; }
        public virtual Employee Employee { get; set; }
    }
}