using Microsoft.AspNetCore.Mvc;
using RMSTestApi.Models;
using RMSTestApi.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using RMSTestApi.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RMSTestApi.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [Route("api/patients/getpatients")]
        [HttpGet]
        public async Task<ActionResult> GetPatients()
        {
            var patients = await _mediator.Send(new GetPatientsQuery());
            using (var db = new RmsDbContext())
            {
                patients = await db.Patients.ToListAsync();
            }
            return Ok(patients);
        }


        [Route("api/patient/getpatientbyid/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetPatientById(int id)
        {

            var patient = new Patient();

            using (var db = new RmsDbContext())
            {
                patient = await db.Patients.FindAsync(id);

            };

            return Ok(patient);
        }

        // POST api/<ValuesController>
        [Route("api/patients/addnewpatient")]
        [HttpPost]
        public async Task <ActionResult> AddNewPatient([FromBody] Patient patient)
        {

            Patient? objPatient = new Patient();

            using (var db= new RmsDbContext())
            {
                await db.Patients.AddAsync(patient);
                await db.SaveChangesAsync();
                int id = patient.patientId;
                objPatient= await db.Patients.FindAsync(id); 
            }
            return Ok(patient);
        }

        [Route("api/patients/updatepatient")]
        [HttpPut]
        public async Task<ActionResult> UpdatePatient([FromBody] Patient patient)
        {
            Patient? objPatient = new Patient();
            //await _mediator.Send(new AddPatientCommand(patient));
            using (var db = new RmsDbContext())
            {

                objPatient = await db.Patients.FindAsync(patient.patientId);
                if (objPatient == null)
                {
                    objPatient = new Patient();
                }
                db.Entry(objPatient).CurrentValues.SetValues(patient);
                await db.SaveChangesAsync();

            }
            return Ok(objPatient);

        }

        [Route("api/patients/deletepatient/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePatient(int id)
        {
            Patient? objPatient = new Patient();
            //await _mediator.Send(new AddPatientCommand(patient));
            using (var db = new RmsDbContext())
            {

                objPatient = await db.Patients.FindAsync(id);
                if (objPatient == null)
                {
                    objPatient = new Patient();
                }
                db.Remove(objPatient);
                await db.SaveChangesAsync();

            }
            return Ok(objPatient);

        }
    }
}
