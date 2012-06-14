using System;

namespace NWVDNUG.Entities
{
    public class IntEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsArchived { get; set; }
    }
}