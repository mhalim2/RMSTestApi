
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMSTestApi.Data;
using RMSTestApi.Models;

namespace RMSTestApi.Controllers

{
   // [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProvidersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("api/providers/getproviders")]
        [HttpGet]
        public async Task<ActionResult> GetProviders()
        {
            var providers = new List<Provider>();
            using (var db = new RmsDbContext())
            {
                providers = await db.Providers.ToListAsync();
            }
            return Ok(providers);
        }

        [Route("api/providers/getproviderbyid/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetProviderById(int id)
        {
            var provider = new Provider();
            using (var db = new RmsDbContext())
            {
                provider = await db.Providers.FindAsync(id);
            }

            return Ok(provider);
        }
        [Route("api/providers/addprovider")]
        [HttpPost]
        public async Task<ActionResult> AddProvider([FromBody] Provider Provider)
        {
            Provider? objProvider = new Provider();
            //await _mediator.Send(new AddProviderCommand(Provider));
            using (var db = new RmsDbContext())
            {
                await db.Providers.AddAsync(Provider);
                await db.SaveChangesAsync();
                int id = Provider.ProviderId;
                objProvider = await db.Providers.FindAsync(id);
            }
            return Ok(objProvider);

        }
        [Route("api/providers/updateprovider")]
        [HttpPut]
        public async Task<ActionResult> UpdateProvider([FromBody] Provider Provider)
        {
            Provider? objProvider = new Provider();
            //await _mediator.Send(new AddProviderCommand(Provider));
            using (var db = new RmsDbContext())
            {

                objProvider = await db.Providers.FindAsync(Provider.ProviderId);
                if (objProvider == null)
                {
                    objProvider = new Provider();
                }
                db.Entry(objProvider).CurrentValues.SetValues(Provider);
                await db.SaveChangesAsync();

            }
            return Ok(objProvider);

        }
        [Route("api/providers/deleteprovider/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteProvider(int id)
        {
            Provider? objProvider = new Provider();
            //await _mediator.Send(new AddProviderCommand(Provider));
            using (var db = new RmsDbContext())
            {

                objProvider = await db.Providers.FindAsync(id);
                if (objProvider == null)
                {
                    objProvider = new Provider();
                }
                db.Remove(objProvider);
                await db.SaveChangesAsync();

            }
            return Ok(objProvider);

        }
    }

}

