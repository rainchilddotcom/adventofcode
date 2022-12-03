using _1;
using _2;
using _3;
using Microsoft.Maui.Controls.Shapes;
using System.Diagnostics;
using System.Reflection;

namespace _2022;

public partial class MainPage
    : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void Day1_1_Clicked(object sender, EventArgs e)
    {
        Day1_Caption.Text = "Calories Carried (top 1)";
        Day1_Answer.Text = new Day1().Part1Answer();
    }

    private void Day1_2_Clicked(object sender, EventArgs e)
    {
        Day1_Caption.Text = "Calories Carried (top 3)";
        Day1_Answer.Text = new Day1().Part2Answer();
    }

    private void Day2_1_Clicked(object sender, EventArgs e)
    {
		Day2_Caption.Text = "Score";
		Day2_Answer.Text = new Day2().Part1Answer();
    }

    private void Day2_2_Clicked(object sender, EventArgs e)
    {
        Day2_Caption.Text = "Score";
        Day2_Answer.Text = new Day2().Part2Answer();
    }

    private void Day3_1_Clicked(object sender, EventArgs e)
    {
        Day3_Caption.Text = "Misplaced Priority";
        Day3_Answer.Text = new Day3().Part1Answer();
    }

    private void Day3_2_Clicked(object sender, EventArgs e)
    {
        Day3_Caption.Text = "Misplaced Priority";
        Day3_Answer.Text = new Day3().Part2Answer();
    }
}
