using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public class Day4
        : Puzzle
    {
        public override string Part1Caption() => "Duplicate Assignments";

        public override string Part1Answer()
        {
            var input = LoadInput();
            return new CleaningAssignmentsLoader(input)
                .DuplicatedSections()
                .Count()
                .ToString();
        }

        public override string Part2Caption() => "Overalpping Assignments";

        public override string Part2Answer()
        {
            var input = LoadInput();
            return new CleaningAssignmentsLoader(input)
                .OverlappingSections()
                .Count()
                .ToString();
        }
    }
}
