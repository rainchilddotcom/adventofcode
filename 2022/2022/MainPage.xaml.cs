using _0;
using _1;
using _2;
using _3;
using _4;
using _5;
using _6;
using _7;
using _8;
// new using goes here
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

        RegisterDay(1, new Day1());
        RegisterDay(2, new Day2());
        RegisterDay(3, new Day3());
        RegisterDay(4, new Day4());
        RegisterDay(5, new Day5());
        RegisterDay(6, new Day6());
        RegisterDay(7, new Day7());
        RegisterDay(8, new Day8());
        // new day goes here
    }

    private void RegisterDay(int number, Puzzle puzzle)
    {
        Flex.Children.Add(new DayTemplate(number, puzzle));
    }
}
