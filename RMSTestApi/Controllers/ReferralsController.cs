using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMSTestApi.Data;
using RMSTestApi.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMSTestApi.Models;

namespace RMSTestApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ReferralsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReferralsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("api/referrals/getreferrals")]
        [HttpGet]
        public async Task<ActionResult> Getreferrals()
        {
            var referrals = new List<Referral>();
            using (var db = new RmsDbContext())
            {
                referrals = await db.Referrals.ToListAsync();
            }
            return Ok(referrals);
        }

        [Route("api/referrals/getreferralbyid/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetreferralById(int id)
        {   
            var referral = new Referral();
            using (var db = new RmsDbContext())
            {
                referral = await db.Referrals.FindAsync(id);
            }

            return Ok(referral);
        }
        [Route("api/referrals/addreferral")]
        [HttpPost]
        public async Task<ActionResult> Addreferral([FromBody] Referral referral)
        {
            Referral? objReferral = new Referral();
            using (var db = new RmsDbContext())
            {

                //TODO: Algorith for referral assigneent


                await db.Referrals.AddAsync(referral);
                await db.SaveChangesAsync();
                int id = referral.ReferralID;
                objReferral = await db.Referrals.FindAsync(id);
            }
            return Ok(objReferral);

        }
        [Route("api/referrals/updatereferral")]
        [HttpPut]
        public async Task<ActionResult> Updatereferral([FromBody] Referral referral)
        {
            Referral? objReferral = new Referral();
            using (var db = new RmsDbContext())
            {

                objReferral = await db.Referrals.FindAsync(referral.ReferralID);
                if (objReferral == null)
                {
                    objReferral = new Referral();
                }
                db.Entry(objReferral).CurrentValues.SetValues(referral);
                await db.SaveChangesAsync();

            }
            return Ok(objReferral);

        }
        [Route("api/referrals/deletereferral/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Deletereferral(int id)
        {
            Referral? objReferral = new Referral();
            using (var db = new RmsDbContext())
            {

                objReferral = await db.Referrals.FindAsync(id);
                if (objReferral == null)
                {
                    objReferral = new Referral();
                }
                db.Remove(objReferral);
                await db.SaveChangesAsync();

            }
            return Ok(objReferral);

        }
    }
}
