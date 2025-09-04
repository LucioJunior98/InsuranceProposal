namespace Insurance.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; } = null;

        public long CreationUserId { get; set; }

        public long? UpdateUserId { get; set; } = null;

        public DateTime? DeletionDate { get; set; } = null;

        public long? DeletionUserId { get; set; } = null;
    }
}
