using _1;
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

    private void Day_1_2_Clicked(object sender, EventArgs e)
    {
        var expedition = new Expedition(new ElfLoader().LoadElves(LoadFileFromEmbeddedResource(typeof(Elf), "_1.input.txt")));
		var answer = expedition.ElvesWithMostCalories(3).Sum(x => x.TotalCalories);

        MostCaloriesCarried.Text = "Calories Carried (top 3)";
        MostCaloriesCarriedAnswer.Text = answer.ToString();
    }
}
