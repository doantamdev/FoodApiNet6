namespace Core.Helpers
{
    public class BaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? TimeDeleted { get; set; }
    }
}
