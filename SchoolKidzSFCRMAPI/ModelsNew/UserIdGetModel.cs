namespace SchoolKidzSFCRMAPI.ModelsNew
{
    public class UserIdGetModel
    {
        public int totalSize;
        public bool done;
        public Dictionary<string, dynamic>[] records;
    }
}


/*
 {"totalSize":2,"done":true,
"records":[
    {"attributes":{"type":"Account","url":"/services/data/v58.0/sobjects/Account/0012t00000SraQbAAJ"},"Id":"0012t00000SraQbAAJ","Name":"RequestLayerTest","UserId__c":"0052t000001EuFKAA0"},
    {"attributes":{"type":"Account","url":"/services/data/v58.0/sobjects/Account/0012t00000Sr9P9AAJ"},"Id":"0012t00000Sr9P9AAJ","Name":"string","UserId__c":"0052t000001EuFKAA0"}
]}
 */