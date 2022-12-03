namespace _2022;
using _0;
using _3;

public partial class DayTemplate : ContentView
{
    private readonly int _number;
    private readonly Puzzle _puzzle;

    public DayTemplate(int number, Puzzle puzzle)
	{
		InitializeComponent();

        DayNumber.Text = $"Day {number}";
        _number = number;
        _puzzle = puzzle;
    }

    private void Part1_Clicked(object sender, EventArgs e)
    {
        AnswerCaption.Text = _puzzle.Part1Caption();
        AnswerValue.Text = _puzzle.Part1Answer();
    }

    private void Part2_Clicked(object sender, EventArgs e)
    {
        AnswerCaption.Text = _puzzle.Part2Caption();
        AnswerValue.Text = _puzzle.Part2Answer();
    }
}