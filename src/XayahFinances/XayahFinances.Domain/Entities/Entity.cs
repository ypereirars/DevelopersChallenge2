namespace XayahFinances.Domain.Entities
{
    public class Entity
    {
        public long Id { get; set; }

        public Entity() : this(0) { }

        public Entity(int id) { Id = id; }
    }
}