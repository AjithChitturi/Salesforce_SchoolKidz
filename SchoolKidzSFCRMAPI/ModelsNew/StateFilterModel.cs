namespace SchoolKidzSFCRMAPI.ModelsNew
{
    public class StateFilterModel
    {
        public fieldsModel[] fields { get; set; }

    }
    public class fieldsModel
    {
        public string name { get; set; }
        public StateModel[] picklistValues { get; set; }
    }
    public class StateModel
    {
        public bool active { get; set; }
        public bool defaultValue { get; set; }
        public string label { get; set; }
        public string validFor { get; set; }
        public string value { get; set; }
    }
}
