using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.DTO
{
    public class ProjectEmpTreeDTO
    {
        public string? Name { get; set; }
        public List<ProjectEmpTreeDTO> Children { get; set; }
    }
    public class ProjectEmpTreeSummaryDTO{
        public int ActiveClientCount { get; set; }
        public int InactiveClientCount { get; set; }
        public int TotalClientCount { get; set; }
        public List<ProjectEmpCount> ProjectEmpCount {get; set;}
    }
    public class ProjectEmpCount{
        public string ? ProjectName { get; set; }
        public int EmployeeCount { get; set; }
    }
    public class ProjectCountDTO{
        public int NewProjectsCount { get; set; }
        public int ApprovedProjectsCount { get; set; }
        public int RejectedProjectsCount { get; set; }
       
    }
    public class EmployeeCountDTO{
        public int ActiveEmployeeCount { get; set; }
        public int InactiveEmployeeCount { get; set; }
    }
   
}