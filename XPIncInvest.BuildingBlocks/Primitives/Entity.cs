namespace XPIncInvest.Domain.Primitives
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        protected Entity() { }

        public Guid Id { get; protected set; }  
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    }
}
