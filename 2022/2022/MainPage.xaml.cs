using _1;
using _2;
using _3;
using Microsoft.Maui.Controls.Shapes;
using System.Diagnostics;
using System.Reflection;

namespace _2022;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private string[] LoadFileFromEmbeddedResource(Type type, string fileName)
	{
		using Stream fileStream = type.Assembly.GetManifestResourceStream(fileName);
		using StreamReader reader = new StreamReader(fileStream);

        var lines = new List<string>();
		string line;
        while ((line = reader.ReadLine()) != null)
        {
			lines.Add(line);
        }

		return lines.ToArray();
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void Day1_1_Clicked(object sender, EventArgs e)
    {
        var expedition = new Expedition(new ElfLoader().LoadElves(LoadFileFromEmbeddedResource(typeof(Elf), "_1.input.txt")));
		var answer = expedition.ElfWithMostCalories.TotalCalories;

        MostCaloriesCarried.Text = "Calories Carried (top 1)";
		MostCaloriesCarriedAnswer.Text = answer.ToString();
    }

    private void Day1_2_Clicked(object sender, EventArgs e)
    {
        var expedition = new Expedition(new ElfLoader().LoadElves(LoadFileFromEmbeddedResource(typeof(Elf), "_1.input.txt")));
		var answer = expedition.ElvesWithMostCalories(3).Sum(x => x.TotalCalories);

        MostCaloriesCarried.Text = "Calories Carried (top 3)";
        MostCaloriesCarriedAnswer.Text = answer.ToString();
    }

    private void Day2_1_Clicked(object sender, EventArgs e)
    {
		var tournament = new TournamentLoaderPart1().LoadTournament(LoadFileFromEmbeddedResource(typeof(Tournament), "_2.input.txt"));

		Day2_Caption.Text = "Score";
		Day2_Answer.Text = tournament.CalculateScore().ToString();
    }

    private void Day2_2_Clicked(object sender, EventArgs e)
    {
        var tournament = new TournamentLoaderPart2().LoadTournament(LoadFileFromEmbeddedResource(typeof(Tournament), "_2.input.txt"));

        Day2_Caption.Text = "Score";
        Day2_Answer.Text = tournament.CalculateScore().ToString();
    }

    private void Day3_1_Clicked(object sender, EventArgs e)
    {
        var rucksacks = new RucksackLoader().LoadRucksacks(LoadFileFromEmbeddedResource(typeof(RucksackLoader), "_3.input.txt"));

        Day3_Caption.Text = "Misplaced Priority";
        Day3_Answer.Text = rucksacks.Sum(x => x.MisplacedPriority).ToString();
    }

    private void Day3_2_Clicked(object sender, EventArgs e)
    {
        var rucksacks = new RucksackLoader().LoadRucksacks(LoadFileFromEmbeddedResource(typeof(RucksackLoader), "_3.input.txt"));
        var groups = Group.AssignGroups(rucksacks);

        Day3_Caption.Text = "Misplaced Priority";
        Day3_Answer.Text = groups.Sum(x => x.BadgePriority).ToString();
    }
}
