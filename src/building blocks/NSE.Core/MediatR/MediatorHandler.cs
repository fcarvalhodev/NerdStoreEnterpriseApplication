using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using System.Threading.Tasks;

namespace NSE.Core.MediatR
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task DispatchEvent<T>(T Event) where T : Event
        {
            await _mediator.Publish(Event);
        }

    
    }
}
