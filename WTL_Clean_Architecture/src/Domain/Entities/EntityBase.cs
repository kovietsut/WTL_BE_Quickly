using Domain.Entities.Interfaces;

namespace Domain.Entities
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public required TKey Id { get; set; }
        public bool IsEnabled { get; set; }
    }
}
