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
    public class ClientController : ControllerBase
    {
        private readonly BVContext DBContext;

        public ClientController(BVContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetClient")]
        public async Task<ActionResult<List<ClientDTO>>> Get()
        {
            var List = await DBContext.Client.Select(
                s => new ClientDTO
                {
                    Id = s.Id,
                    ClientName = s.ClientName,
                    ContactPerson = s.ContactPerson,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    Address =s.Address,
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
        [HttpPost("InsertClient")]
        public async Task < HttpStatusCode > InsertClient(ClientDTO s) {
            var entity = new Client() {
                    ClientName = s.ClientName,
                    ContactPerson = s.ContactPerson,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    Address =s.Address,
                    Status = s.Status
            };
            DBContext.Client.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateClient")]
        public async Task<HttpStatusCode> UpdateClient(ClientDTO Client) {
            var entity = await DBContext.Client.FirstOrDefaultAsync(s => s.Id == Client.Id);
            entity.ClientName = Client.ClientName;
            entity.ContactPerson = Client.ContactPerson;
            entity.Email = Client.Email;
            entity.PhoneNumber = Client.PhoneNumber;
            entity.Address = Client.Address;
            entity.Status = Client.Status;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteClient/{Id}")]
        public async Task < HttpStatusCode > DeleteClient(int Id) {
            var entity = new Client() {
                Id = Id
            };
            DBContext.Client.Attach(entity);
            DBContext.Client.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}