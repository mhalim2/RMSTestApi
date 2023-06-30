using MediatR;
using Microsoft.AspNetCore.Mvc;
using RMSTestApi.Models;
using RMSTestApi.Data;
using Microsoft.EntityFrameworkCore;

namespace RMSTestApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpecialtiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("api/specialties/getspecialties")]
        [HttpGet]
        public async Task<ActionResult> GetSpecialties()
        {
            var specialty = new List<Specialty>();
            using (var db = new RmsDbContext())
            {
                specialty = await db.Specialties.ToListAsync();
            }
            return Ok(specialty);
        }

        [Route("api/specialties/getspecialtybyid/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetSpecialtyById(int id)
        {

            var specialty = new Specialty();
            using (var db = new RmsDbContext())
            {
                specialty = await db.Specialties.FindAsync(id);
            }

            return Ok(specialty);
        }
        [Route("api/specialties/addspecialty")]
        [HttpPost]
        public async Task<ActionResult> AddSpecialty([FromBody] Specialty Specialtie)
        {
            Specialty? objSpecialty = new Specialty();

            using (var db = new RmsDbContext())
            {
                await db.Specialties.AddAsync(Specialtie);
                await db.SaveChangesAsync();
                int id = Specialtie.specialtyID;
                objSpecialty = await db.Specialties.FindAsync(id);
            }
            return Ok(objSpecialty);

        }
        [Route("api/specialties/updatespecialty")]
        [HttpPut]
        public async Task<ActionResult> UpdateSpecialty([FromBody] Specialty Specialtie)
        {
            Specialty? objSpecialty = new Specialty();
            //await _mediator.Send(new AddSpecialtieCommand(Specialtie));
            using (var db = new RmsDbContext())
            {

                objSpecialty = await db.Specialties.FindAsync(Specialtie.specialtyID);
                if (objSpecialty == null)
                {
                    objSpecialty = new Specialty();
                }
                db.Entry(objSpecialty).CurrentValues.SetValues(Specialtie);
                await db.SaveChangesAsync();

            }
            return Ok(objSpecialty);

        }
        [Route("api/specialties/deletespecialty/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSpecialty(int id)
        {
            Specialty? objSpecialty = new Specialty();
            using (var db = new RmsDbContext())
            {

                objSpecialty = await db.Specialties.FindAsync(id);
                if (objSpecialty == null)
                {
                    objSpecialty = new Specialty();
                }
                db.Remove(objSpecialty);
                await db.SaveChangesAsync();

            }
            return Ok(objSpecialty);

        }
    }
}
