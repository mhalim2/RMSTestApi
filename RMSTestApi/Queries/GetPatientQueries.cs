
using MediatR;
using RMSTestApi.Models;

namespace RMSTestApi.Queries
{
    public record GetPatientsQuery() : IRequest<IEnumerable<Patient>>;
}
