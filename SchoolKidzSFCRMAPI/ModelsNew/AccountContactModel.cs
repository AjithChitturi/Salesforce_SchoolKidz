namespace SchoolKidzSFCRMAPI.ModelsNew
{
    public class AccountContactModel
    {
        public int totalSize;
        public bool done;
        public contactDetails[] records;
    }
    public class contactDetails
    {
        
        public object? attributes { get; set; }
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string ContactId { get; set; }
        public object? Roles { get; set; }
        public bool? IsDirect { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedById { get; set; }
        public DateTime? SystemModstamp { get; set; }
    }
}
