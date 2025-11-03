namespace Domain.Entities.Interfaces
{
    public interface IHasTimestamps
    {
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
    }

    public interface IHasUserAudit
    {
        string? CreatedBy { get; set; }
        string? ModifiedBy { get; set; }
    }
}


