using System;
namespace Order.Domain.Abstraction
{
    public abstract class EntityBase
    { 
        public int Id { private set; get; }
        public DateTime CreatedOn { private set;  get; }
        public string CreatedBy { private set;  get; }
        public DateTime LastModifiedOn { private set;  get; }
        public string LastModifiedBy { private set;  get; }
        public void AddCreationValue(DateTime createdOn , string createdBy)
        {
            this.CreatedOn = createdOn;
            this.CreatedBy = createdBy;

        }
        public void AddModificationValue(DateTime lastModifiedOn, string lastModifiedBy)
        {
            this.LastModifiedOn = lastModifiedOn;
            this.LastModifiedBy = lastModifiedBy;

        }
    }
}
