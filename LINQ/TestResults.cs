namespace LINQ
{
    public class TestResults
    {
        public TestResults(string id, string familyId)
        {
            Id = id;
            FamilyId = familyId;
        }

        public string Id { get; set; }

        public string FamilyId { get; set; }
    }
}
