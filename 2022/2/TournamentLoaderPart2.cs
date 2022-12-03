using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    public class TournamentLoaderPart2
        : ITournamentLoader
    {
        public Tournament LoadTournament(string[] rounds)
        {
            var tournament = new Tournament();

            foreach (var round in rounds)
            {
                var actions = round.Split(' ');
                var opponentAction = ParseAction(actions[0]);
                var expectedOutcome = CalculateExpectedOutcome(opponentAction, actions[1]);

                tournament.Rounds.Add(new Round()
                {
                    OpponentAction = opponentAction,
                    PlayerAction = expectedOutcome
                });
            }

            return tournament;
        }

        private Actions ParseAction(string v)
        {
            if (v == "A")
                return Actions.Rock;
            if (v == "B")
                return Actions.Paper;
            if (v == "C")
                return Actions.Scissors;

            throw new InvalidDataException($"Unknown Scorecard Record: {v}");
        }

        private Actions CalculateExpectedOutcome(Actions opponentAction, string v)
        {
            if (v == "X")
            {
                // we should lose
                return ActionMatrix.ValidActions
                    .Single(x => x.Action == opponentAction)
                    .Beats.First();
            }
            if (v == "Y")
            {
                // we should draw
                return opponentAction;
            }
            if (v == "Z")
            {
                // we should win
                return ActionMatrix.ValidActions
                    .Single(x => x.Action == opponentAction)
                    .Loses.First();
            }

            throw new InvalidDataException($"Unknown Scorecard Outcome: {v}");
        }
    }
}
