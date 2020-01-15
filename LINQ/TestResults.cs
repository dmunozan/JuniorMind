namespace LINQ
{
    public class TestResults
    {
        public TestResults(string id, string familyId, int score)
        {
            Id = id;
            FamilyId = familyId;
            Score = score;
        }

        public string Id { get; set; }

        public string FamilyId { get; set; }

        public int Score { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TestResults result
                && Id == result.Id
                && FamilyId == result.FamilyId
                && Score == result.Score;
        }
    }
}
