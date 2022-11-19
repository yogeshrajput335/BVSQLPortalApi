using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.DTO
{
    public class CandidateDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName{ get; set; }
        public string? PhoneNo{ get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        public string? ReferByName { get; set; }
        public int? ReferBy { get; set; }
        public string? JobName { get; set; }
        public int? JobId { get; set; }
    }
}