namespace _2.Tests
{
    public class DayTwoTests
    {
        const string testInput =
@"A Y
B X
C Z";
        
        [Test]
        public void ScoreForRockVsPaper()
        {
            new Score()
                .ScoreForRound(Actions.Rock, Actions.Paper)
                .Should()
                .Be(8);
        }

        [Test]
        public void ScoreForPaperVsRock()
        {
            new Score()
                .ScoreForRound(Actions.Paper, Actions.Rock)
                .Should()
                .Be(1);
        }

        [Test]
        public void ScoreForScissorsVsScissors()
        {
            new Score()
                .ScoreForRound(Actions.Scissors, Actions.Scissors)
                .Should()
                .Be(6);
        }

        [Test]
        public void ScoreForTournamentPart1()
        {
            var tournament = new TournamentLoaderPart1()
                .LoadTournament(testInput.Split(Environment.NewLine));

            tournament
                .CalculateScore()
                .Should()
                .Be(15);
        }

        [Test]
        public void ScoreForTournamentPart2()
        {
            var tournament = new TournamentLoaderPart2()
                .LoadTournament(testInput.Split(Environment.NewLine));

            tournament
                .CalculateScore()
                .Should()
                .Be(12);
        }
    }
}