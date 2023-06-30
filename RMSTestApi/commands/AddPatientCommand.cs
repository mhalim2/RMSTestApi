using RMSTestApi.Models;
using MediatR;


namespace RMSTestApi.Commands
{
    public record AddPatientCommand(Patient Patient) : IRequest;

}

