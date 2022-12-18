using _0;
using _1;
using _2;
using _3;
using _4;
using _5;
using _6;
using _7;
using _8;
using _9;
using _10;
using _11;
using _12;
using _13;
using _14;
using _15;
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
        RegisterDay(9, new Day9());
        RegisterDay(10, new Day10());
        RegisterDay(11, new Day11());
        RegisterDay(12, new Day12());
        RegisterDay(13, new Day13());
        RegisterDay(14, new Day14());
        RegisterDay(15, new Day15());
        // new day goes here
    }

    private void RegisterDay(int number, Puzzle puzzle)
    {
        Flex.Children.Add(new DayTemplate(number, puzzle));
    }
}
