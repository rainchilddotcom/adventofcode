namespace _2
{
    public class Tournament
    {
        public List<Round> Rounds { get; } = new List<Round>();

        public decimal CalculateScore()
        {
            return new Score()
                .ScoreForTournament(this);
        }
    }
}
