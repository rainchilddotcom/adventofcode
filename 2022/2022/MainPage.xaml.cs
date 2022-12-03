using _0;
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

        RegisterDay(1, new Day1());
        RegisterDay(2, new Day2());
        RegisterDay(3, new Day3());
        //RegisterDay(4, new Day4());
	}

    private void RegisterDay(int number, Puzzle puzzle)
    {
        Flex.Children.Add(new DayTemplate(number, puzzle));
    }
}
