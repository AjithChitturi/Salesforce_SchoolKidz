namespace SchoolKidzSFCRMAPI.ModelsNew
{

    public class QuoteListModel
    {
        public List<Record>? records { get; set; }
    }
    public class Record
    {
        
        public string Id { get; set; }

        public string Name { get; set; }

        public string tt_Account__c { get; set; }

        public DateTime tt_AssignedDate__c { get; set; }

        public DateTime tt_CompletionDate__c { get; set; }

        public DateTime tt_Needbydate__c { get; set; }

        public string tt_Opportunity__c { get; set; }

        public string tt_Quote__c { get; set; }

        public string tt_quoterequestJM__c { get; set; }

        public string tt_quoterequestJOEMID__c { get; set; }

        public string tt_QuotingUser__c { get; set; }

        public DateTime tt_RequesrDate__c { get; set; }

        public string tt_RequestType__c { get; set; }

        public string tt_ResponceNotes__c { get; set; }

        public string tt_SpecialNotes__c { get; set; }

        public string tt_Status__c { get; set; }

        
    }
}
