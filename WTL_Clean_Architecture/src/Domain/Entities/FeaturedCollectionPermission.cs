using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class FeaturedCollectionPermission
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? MangaId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? FeaturedCollectionId { get; set; }

    public Guid? ActionId { get; set; }

    public int PermissionType { get; set; }

    public virtual Action? Action { get; set; }

    public virtual FeaturedCollection? FeaturedCollection { get; set; }

    public virtual Manga? Manga { get; set; }

    public virtual User? User { get; set; }
}
