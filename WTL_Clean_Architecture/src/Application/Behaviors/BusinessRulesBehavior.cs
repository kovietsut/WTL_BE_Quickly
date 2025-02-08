using Application.Interfaces;
using MediatR;

namespace Application.Behaviors
{
    public class BusinessRulesBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IBusinessRules<TRequest>> _businessRules;

        public BusinessRulesBehavior(IEnumerable<IBusinessRules<TRequest>> businessRules)
        {
            _businessRules = businessRules;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            foreach (var rule in _businessRules)
            {
                await rule.ValidateAsync(request, cancellationToken);
            }

            return await next();
        }
    }
}
