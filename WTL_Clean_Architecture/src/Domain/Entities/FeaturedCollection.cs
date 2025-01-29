using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class FeaturedCollection
{
    public Guid Id { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public string Name { get; set; } = null!;

    public string? CoverImage { get; set; }

    public bool? IsPublish { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<FeaturedCollectionManga> FeaturedCollectionMangas { get; set; } = new List<FeaturedCollectionManga>();

    public virtual ICollection<FeaturedCollectionPermission> FeaturedCollectionPermissions { get; set; } = new List<FeaturedCollectionPermission>();

    public virtual User? ModifiedByNavigation { get; set; }
}
