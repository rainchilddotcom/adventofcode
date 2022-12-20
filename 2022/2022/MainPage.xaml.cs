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
        if (number == 15)
            CustomVisualization(number, puzzle);
    }

    private void CustomVisualization(int number, Puzzle puzzle)
    {
        var button = new Button
        {
            Text = "15 Visualisation"
        };

        button.Clicked += Day15Custom_Clicked;

        Flex.Children.Add(button);

    }

    private void Day15Custom_Clicked(object sender, EventArgs e)
    {
        new _15.Visualizer.SensorGridRenderer(new SensorGridLoader().LoadSensorGrid(new Day15().LoadInput()), 2000000);
        new _15.Visualizer.SensorGridRenderer(new SensorGridLoader().LoadSensorGrid(@"Sensor at x=2, y=18: closest beacon is at x=-2, y=15
Sensor at x=9, y=16: closest beacon is at x=10, y=16
Sensor at x=13, y=2: closest beacon is at x=15, y=3
Sensor at x=12, y=14: closest beacon is at x=10, y=16
Sensor at x=10, y=20: closest beacon is at x=10, y=16
Sensor at x=14, y=17: closest beacon is at x=10, y=16
Sensor at x=8, y=7: closest beacon is at x=2, y=10
Sensor at x=2, y=0: closest beacon is at x=2, y=10
Sensor at x=0, y=11: closest beacon is at x=2, y=10
Sensor at x=20, y=14: closest beacon is at x=25, y=17
Sensor at x=17, y=20: closest beacon is at x=21, y=22
Sensor at x=16, y=7: closest beacon is at x=15, y=3
Sensor at x=14, y=3: closest beacon is at x=15, y=3
Sensor at x=20, y=1: closest beacon is at x=15, y=3".Split(Environment.NewLine)), 10);

    }
}
