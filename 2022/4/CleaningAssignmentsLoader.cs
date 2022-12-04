using _0;

namespace _4
{
    public class CleaningAssignmentsLoader
    {
        public List<CleaningAssignment> CleaningAssignments { get; init; } = new List<CleaningAssignment>();

        public CleaningAssignmentsLoader(string[] input)
        {
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var assignments = line.Split(',');
                var assignment1 = Utilities.ParseRange(assignments[0]);
                var assignment2 = Utilities.ParseRange(assignments[1]);

                CleaningAssignments.Add(new CleaningAssignment(assignment1, assignment2));
            }
        }

        public List<CleaningAssignment> DuplicatedSections()
        {
            return CleaningAssignments
                .Where(x => x.AssignmentsOverlapFully)
                .ToList();
        }

        public List<CleaningAssignment> OverlappingSections()
        {
            return CleaningAssignments
                .Where(x => x.AssignmentsOverlap)
                .ToList();
        }
    }
}
