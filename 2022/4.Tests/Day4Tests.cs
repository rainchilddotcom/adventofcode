namespace _4.Tests
{
    public class Day4Tests
    {
        const string testInput =
@"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8
";
        
        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void DuplicatedCleaningAssignments()
        {
            new CleaningAssignmentsLoader(input)
                .DuplicatedSections()
                .Count()
                .Should().Be(2);
        }

        [Test]
        public void OverlappingCleaningAssignments()
        {
            new CleaningAssignmentsLoader(input)
                .OverlappingSections()
                .Count()
                .Should().Be(4);
        }
    }
}