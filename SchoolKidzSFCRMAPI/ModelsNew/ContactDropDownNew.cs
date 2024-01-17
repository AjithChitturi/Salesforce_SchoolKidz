namespace SchoolKidzSFCRMAPI.ModelsNew
{
    public class ContactDropDownNew
    {
        public int totalSize { get; set; }
        public bool done { get; set; }
        public ContactDropdownListNew[] records { get; set; }
    }
    public class ContactDropdownListNew
    {
        public object attributes { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

/*
 * {"totalSize":2,"done":true,"records":[{"attributes":{"type":"Contact","url":"/services/data/v58.0/sobjects/Contact/0032t00000RiJYyAAN"},"Id":"0032t00000RiJYyAAN","Name":"Link Test"},{"attributes":{"type":"Contact","url":"/services/data/v58.0/sobjects/Contact/0032t00000RiJygAAF"},"Id":"0032t00000RiJygAAF","Name":"Navya P"}]}
 */