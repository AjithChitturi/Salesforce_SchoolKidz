namespace SchoolKidzSFCRMAPI.ModelsNew
{
    public class ExceptionApprovalModel
    {
        public string? Id { get; set;}
        public string? OwnerId { get; set;}
        public bool? IsDeleted { get; set;}
        public string? Name {get; set;}
        public string? CreatedDate {get; set;}
        public string? CreatedById {get; set;}
        public string? LastModifiedDate {get; set;}
        public string? LastModifiedById {get; set;}
        public string? SystemModstamp {get; set;}
        public string? LastViewedDate {get; set;}
        public string? LastReferencedDate {get; set;}
        public string? tt_RequestNotes__c {get; set;}
        public float? tt_DiscountPercentage__c {get; set;}
        public string? tt_ResponseNotes__c {get; set;}
        public DateTime tt_ApprovalRequestDate__c {get; set;}
        public bool? tt_RequestHomeDeliveryApproval__c {get; set;}
        public bool? tt_RequestDiscountApproval__c {get; set;}
        public bool? tt_RequestInsideDeliveryApproval__c {get; set;}
        public string? tt_Status__c {get; set;}
        public DateTime tt_ManagerApproveDenyDate__c {get; set;}
        public string? tt_Account__c {get; set;}
        public float? tt_code__c {get; set;}
        public string? tt_OtherRequests__c { get; set; }
        public string? tt_AssignedManager__c { get; set; }
    }
}
