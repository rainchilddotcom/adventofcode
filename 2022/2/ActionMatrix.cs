namespace _2
{
    public class ActionMatrix
    {
        public Actions Action;
        public List<Actions> Beats { get; init; } = new List<Actions>();
        public List<Actions> Loses { get; init; } = new List<Actions>();

        public static readonly List<ActionMatrix> ValidActions = new List<ActionMatrix>
        {
            new ActionMatrix
            {
                Action = Actions.Rock,
                Beats = { Actions.Scissors },
                Loses = { Actions.Paper }
            },
            new ActionMatrix
            {
                Action = Actions.Paper,
                Beats = { Actions.Rock },
                Loses = { Actions.Scissors }
            },
            new ActionMatrix
            {
                Action = Actions.Scissors,
                Beats = { Actions.Paper },
                Loses = { Actions.Rock }
            }
        };
    }
}
