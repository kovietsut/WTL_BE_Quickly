namespace Domain.Entities;

public partial class Role : EntityBase<long>
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
