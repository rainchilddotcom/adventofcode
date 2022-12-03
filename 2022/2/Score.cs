using System;

namespace _2
{
    public class Score
    {
        public decimal ScoreForAction(Actions action)
        {
            switch (action)
            {
                case Actions.Rock:
                    return 1;
                case Actions.Paper:
                    return 2;
                case Actions.Scissors:
                    return 3;
                default:
                    throw new InvalidDataException($"Unknown Action {action}");
            }
        }

        public decimal ScoreForWin() { return 6; }
        public decimal ScoreForDraw() { return 3; }
        public decimal ScoreForLoss() { return 0; }

        public decimal ScoreForRound(Actions opponentAction, Actions playerAction)
        {
            if (opponentAction == playerAction)
            {
                // draw
                return ScoreForDraw() + ScoreForAction(playerAction);
            }

            if (IsWin(opponentAction, playerAction))
            {
                return ScoreForWin() + ScoreForAction(playerAction);
            }

            return ScoreForLoss() + ScoreForAction(playerAction);
        }

        public bool IsWin(Actions opponentAction, Actions playerAction)
        {
            return ActionMatrix.ValidActions
                .Single(x => x.Action == playerAction)
                .Beats.Contains(opponentAction);
        }

        public decimal ScoreForTournament(Tournament tournament)
        {
            decimal score = 0;
            foreach (var round in tournament.Rounds)
            {
                score += ScoreForRound(round.OpponentAction, round.PlayerAction);
            }
            return score;
        }
    }
}
