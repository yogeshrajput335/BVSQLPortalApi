using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.Models
{
    public class TimesheetApproval
    {
        public int Id { get; set; }
        public int? TimesheetId { get; set; }
        [ForeignKey("Employee")]
        public int? ApproverId { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public virtual Timesheet Timesheet { get; set; }
        public virtual Employee Employee { get; set; }
    }
}