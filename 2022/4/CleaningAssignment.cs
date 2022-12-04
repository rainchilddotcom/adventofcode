using _0;
using Range = _0.Range;

namespace _4
{
    public class CleaningAssignment
    {
        public CleaningAssignment(Range assignment1, Range assignment2)
        {
            Assignment1 = assignment1;
            Assignment2 = assignment2;
        }

        public Range Assignment1 { get; init; }
        public Range Assignment2 { get; init; }

        public bool AssignmentsOverlapFully
        {
            get
            {
                if (Assignment1.LowerBound <= Assignment2.LowerBound && Assignment1.UpperBound >= Assignment2.UpperBound)
                    return true;

                if (Assignment2.LowerBound <= Assignment1.LowerBound && Assignment2.UpperBound >= Assignment1.UpperBound)
                    return true;

                return false;
            }
        }

        public bool AssignmentsOverlap
        {
            get
            {
                if (Assignment1.LowerBound.Between(Assignment2.LowerBound, Assignment2.UpperBound)
                    || Assignment1.UpperBound.Between(Assignment2.LowerBound, Assignment2.UpperBound))
                    return true;

                if (Assignment2.LowerBound.Between(Assignment1.LowerBound, Assignment1.UpperBound)
                    || Assignment2.UpperBound.Between(Assignment1.LowerBound, Assignment1.UpperBound))
                    return true;

                return false;
            }
        }
    }
}
