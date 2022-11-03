using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BVPortalApi.CommonFeatures;
using BVPortalApi.CommonFeatures.Contracts;
using BVPortalApi.DTO;
using BVPortalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BVPortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolidayMasterController : ControllerBase
    {
        private readonly BVContext DBContext;

        public HolidayMasterController(BVContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetHolidayMaster")]
        public async Task<ActionResult<List<HolidayMasterDTO>>> Get()
        {
            var List = await DBContext.HolidayMaster.Select(
                s => new HolidayMasterDTO
                {
                    Id = s.Id,
                    HolidayName = s.HolidayName,
                    Description = s.Description,
                    Date = s.Date,
                    Status = s.Status
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
        [HttpPost("InsertHolidayMaster")]
        public async Task<HttpStatusCode> InsertHolidayMaster(HolidayMasterDTO s)
        {
            var entity = new HolidayMaster()
            {
                    Id = s.Id,
                    HolidayName = s.HolidayName,
                    Description = s.Description,
                    Date = s.Date,
                    Status = s.Status
            };
            DBContext.HolidayMaster.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateHolidayMaster")]
        public async Task<HttpStatusCode> UpdateHolidayMaster(HolidayMasterDTO HolidayMaster)
        {
            var entity = await DBContext.HolidayMaster.FirstOrDefaultAsync(s => s.Id == HolidayMaster.Id);
            entity.HolidayName = HolidayMaster.HolidayName;
            entity.Description = HolidayMaster.Description;
            entity.Date = HolidayMaster.Date;
            entity.Status = HolidayMaster.Status;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteHolidayMaster/{Id}")]
        public async Task<HttpStatusCode> DeleteHolidayMaster(int Id)
        {
            var entity = new HolidayMaster()
            {
                Id = Id
            };
            DBContext.HolidayMaster.Attach(entity);
            DBContext.HolidayMaster.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}