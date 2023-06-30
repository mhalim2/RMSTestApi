
using MediatR;
using RMSTestApi.Models;

namespace RMSTestApi.Queries
{
    public record GetPatientByIdQuery(int id) : IRequest<Patient>;

}

