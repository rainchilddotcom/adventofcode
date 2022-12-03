using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    public class Day2
        : Puzzle
    {
        public override string Part1Caption() => "Score";

        public override string Part1Answer()
        {
            var tournament = new TournamentLoaderPart1().LoadTournament(LoadInput());
            return tournament.CalculateScore().ToString();
        }

        public override string Part2Caption() => "Score";

        public override string Part2Answer()
        {
            var tournament = new TournamentLoaderPart2().LoadTournament(LoadInput());
            return tournament.CalculateScore().ToString();
        }
    }
}
