namespace Application.Interfaces
{
    public interface IBusinessRules<TRequest>
    {
        Task ValidateAsync(TRequest request, CancellationToken cancellationToken);
    }
}
