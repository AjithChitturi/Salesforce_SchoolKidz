using System.Numerics;

namespace SchoolKidzSFCRMAPI.ModelsNew
{
    public class ContactModelNew
    {
        public object attributes{ get; set; }
        public string Id{ get; set; }
        public bool IsDeleted{ get; set; }
        public string? MasterRecordId{ get; set; }
        public string? AccountId{ get; set; }
        public string? LastName{ get; set; }
        public string? FirstName{ get; set; }
        public string? Salutation{ get; set; }
        public string? Name{ get; set; }
        public string? OtherStreet{ get; set; }
        public string? OtherCity{ get; set; }
        public string? OtherState{ get; set; }
        public string? OtherPostalCode{ get; set; }
        public string? OtherCountry{ get; set; }
        public string? OtherStateCode{ get; set; }
        public string? OtherCountryCode{ get; set; }
        public string? OtherLatitude{ get; set; }
        public string? OtherLongitude{ get; set; }
        public string? OtherGeocodeAccuracy{ get; set; }
        public string? OtherAddress{ get; set; }
        public string? MailingStreet{ get; set; }
        public string? MailingCity{ get; set; }
        public string? MailingState{ get; set; }
        public string? MailingPostalCode{ get; set; }
        public string? MailingCountry{ get; set; }
        public string? MailingStateCode{ get; set; }
        public string? MailingCountryCode{ get; set; }
        public string? MailingLatitude{ get; set; }
        public string? MailingLongitude{ get; set; }
        public string? MailingGeocodeAccuracy{ get; set; }
        public string? MailingAddress{ get; set; }
        public string? Phone{ get; set; }
        public string? Fax{ get; set; }
        public string? MobilePhone{ get; set; }
        public string? HomePhone{ get; set; }
        public string? OtherPhone{ get; set; }
        public string? AssistantPhone{ get; set; }
        public string? ReportsToId{ get; set; }
        public string? Email{ get; set; }
        public string? Title{ get; set; }
        public string? Department{ get; set; }
        public string? AssistantName{ get; set; }
        public string? LeadSource{ get; set; }
        public string? Birthdate{ get; set; }
        public string? Description{ get; set; }
        public string? OwnerId{ get; set; }
        public string? CreatedDate{ get; set; }
        public string? CreatedById{ get; set; }
        public string? LastModifiedDate{ get; set; }
        public string? LastModifiedById{ get; set; }
        public string? SystemModstamp{ get; set; }
        public string? LastActivityDate{ get; set; }
        public string? LastCURequestDate{ get; set; }
        public string? LastCUUpdateDate{ get; set; }
        public string? LastViewedDate{ get; set; }
        public string? LastReferencedDate{ get; set; }
        public string? EmailBouncedReason{ get; set; }
        public string? EmailBouncedDate{ get; set; }
        public string? IsEmailBounced{ get; set; }
        public string? PhotoUrl{ get; set; }
        public string? Jigsaw{ get; set; }
        public string? JigsawContactId{ get; set; }
        public string? CleanStatus{ get; set; }
        public string? IndividualId{ get; set; }
        public string? Level__c{ get; set; }
        public string? Languages__c{ get; set; }
    }    
}
