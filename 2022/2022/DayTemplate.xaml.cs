namespace _2022;
using _0;
using _3;
using System.Diagnostics;

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
        Stopwatch stopwatch = Stopwatch.StartNew();
        var answer = _puzzle.Part1Answer();
        stopwatch.Stop();

        AnswerCaption.Text = _puzzle.Part1Caption();
        AnswerValue.Text = answer;
        AnswerTime.Text = $"{stopwatch.ElapsedMilliseconds}ms";
    }

    private void Part2_Clicked(object sender, EventArgs e)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        var answer = _puzzle.Part2Answer();
        stopwatch.Stop();

        AnswerCaption.Text = _puzzle.Part2Caption();
        AnswerValue.Text = answer;
        AnswerTime.Text = $"{stopwatch.ElapsedMilliseconds}ms";
    }
}