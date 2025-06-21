namespace Domain.Entities;

public partial class Role : EntityBase<string>
{
    public string Name { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
