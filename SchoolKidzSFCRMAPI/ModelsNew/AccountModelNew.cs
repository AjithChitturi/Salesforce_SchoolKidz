using Microsoft.AspNetCore.Http;
using System.Numerics;

namespace SchoolKidzSFCRMAPI.ModelsNew
{
    public class AccountModelNew
    {
        public string? Id { get;set; }
        public string? IsDeleted { get;set; }
        public string? MasterRecordId { get;set; }
        public string? Type { get;set; }
        public string? ParentId { get;set; }
        public string? BillingStreet { get;set; }
        public string? BillingCity { get;set; }
        public string? BillingState { get;set; }
        public string? BillingCountry { get;set; }
        public string? BillingStateCode { get;set; }
        public string? BillingCountryCode { get;set; }
        public string? BillingLatitude { get;set; }
        public string? BillingLongitude { get;set; }
        public string? BillingGeocodeAccuracy { get;set; }
        public object? BillingAddress { get;set; }
        public string? ShippingStreet { get;set; }
        public string? ShippingCity { get;set; }
        public string? ShippingState { get;set; }
        public string? ShippingPostalCode { get;set; }
        public string? ShippingCountry { get;set; }
        public string? ShippingStateCode { get;set; }
        public string? ShippingCountryCode { get;set; }
        public string? ShippingLatitude { get;set; }
        public string? ShippingLongitude { get;set; }
        public string? ShippingGeocodeAccuracy { get;set; }
        public object? ShippingAddress { get;set; }
        public string? Phone { get;set; }
        public string? Fax { get;set; }
        public string? AccountNumber { get;set; }
        public string? Website { get;set; }
        public string? PhotoUrl { get;set; }
        public string? Sic { get;set; }
        public string? Industry { get;set; }
        public string? AnnualRevenue { get;set; }
        public string? NumberOfEmployees { get;set; }
        public string? Ownership { get;set; }
        public string? TickerSymbol { get;set; }
        public string? Description { get;set; }
        public string? Rating { get;set; }
        public string? Site { get;set; }
        public string? OwnerId { get;set; }
        public string? CreatedDate { get;set; }
        public string? CreatedById { get;set; }
        public string? LastModifiedDate { get;set; }
        public string? LastModifiedById { get;set; }
        public string? SystemModstamp { get;set; }
        public string? LastActivityDate { get;set; }
        public string? LastViewedDate { get;set; }
        public string? LastReferencedDate { get;set; }
        public string? Jigsaw { get;set; }
        public string? JigsawCompanyId { get;set; }
        public string? CleanStatus { get;set; }
        public string? AccountSource { get;set; }
        public string? DunsNumber { get;set; }
        public string? Tradestyle { get;set; }
        public string? NaicsCode { get;set; }
        public string? NaicsDesc { get;set; }
        public string? YearStarted { get;set; }
        public string? SicDesc { get;set; }
        public string? DandbCompanyId { get;set; }
        public string? OperatingHoursId { get;set; }
        public string? CustomerPriority__c { get;set; }
        public string? SLA__c { get;set; }
        public string? Active__c { get;set; }
        public string? NumberofLocations__c { get;set; }
        public string? UpsellOpportunity__c { get;set; }
        public string? SLASerialNumber__c { get;set; }
        public string? SLAExpirationDate__c { get;set; }
        public string? PrimaryContact__c { get;set; }
        public string? tt_salescoordinatorid__c { get;set; }
        public string? tt_salesrepid__c { get;set; }
        public string? columnnames__c { get;set; }
        public string? UserId__c { get; set; }

        public string? Name { get; set; }
        public int? tt_enrollment__c { get; set; }
        public string? tt_grades__c { get; set; }
        public int? tt_status_number__c { get; set; }
        public string? address1_line1__c { get; set; }
        public string? address1_line2__c { get; set; }
        public string? address1_line3__c { get; set; }
        public string? address1_city__c { get; set; }
        public string? BillingPostalCode { get; set; }
        public string? telephone1__c { get; set; }
        public string? tt_StatementName__c { get; set; }
        public bool tt_programschedulecomplete__c { get; set; }
        public string? Address1_Telephone1__c { get; set; }
        public bool tt_GPUpdateFlag__c { get; set; }
        public string? tt_taxexemptinfo__c { get; set; }
        public DateTime? tt_taxexcemptexpirationdate__c { get; set; }
    }
}
