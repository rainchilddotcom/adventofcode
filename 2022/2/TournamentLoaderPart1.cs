using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    public class TournamentLoaderPart1
        : ITournamentLoader
    {
        public Tournament LoadTournament(string[] rounds)
        {
            var tournament = new Tournament();

            foreach (var round in rounds)
            {
                var actions = round.Split(' ');
                tournament.Rounds.Add(new Round()
                {
                    OpponentAction = ParseAction(actions[0]),
                    PlayerAction = ParseAction(actions[1])
                });
            }

            return tournament;
        }

        private Actions ParseAction(string v)
        {
            if (v == "A" || v == "X")
                return Actions.Rock;
            if (v == "B" || v == "Y")
                return Actions.Paper;
            if (v == "C" || v == "Z")
                return Actions.Scissors;

            throw new InvalidDataException($"Unknown Scorecard Record: {v}");
        }
    }
}
