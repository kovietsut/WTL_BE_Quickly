using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Action
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FeaturedCollectionPermission> FeaturedCollectionPermissions { get; set; } = new List<FeaturedCollectionPermission>();
}
