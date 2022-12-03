namespace _3.Tests
{
    public class Day3Tests
    {
        const string testInput =
@"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
        
        [Test]
        public void RucksackCompartments()
        {
            var rucksacks = new RucksackLoader()
                .LoadRucksacks(testInput.Split(Environment.NewLine));

            rucksacks[0].Compartment1
                .Should().Be("vJrwpWtwJgWr");

            rucksacks[0].Compartment2
                .Should().Be("hcsFMMfFFhFp");

            rucksacks[0].MispackedItem
                .Should().Be('p');

            rucksacks[1].Compartment1
                .Should().Be("jqHRNqRjqzjGDLGL");

            rucksacks[1].Compartment2
                .Should().Be("rsFMfFZSrLrFZsSL");

            rucksacks[1].MispackedItem
                .Should().Be('L');

            rucksacks[2].Compartment1
                .Should().Be("PmmdzqPrV");

            rucksacks[2].Compartment2
                .Should().Be("vPwwTWBwg");

            rucksacks[2].MispackedItem
                .Should().Be('P');

            rucksacks[3].MispackedItem
                .Should().Be('v');

            rucksacks[4].MispackedItem
                .Should().Be('t');

            rucksacks[5].MispackedItem
                .Should().Be('s');

            rucksacks.Sum(x => x.MisplacedPriority)
                .Should().Be(157);
        }

        [Test]
        public void BadgeAllocation()
        {
            var rucksacks = new RucksackLoader()
                .LoadRucksacks(testInput.Split(Environment.NewLine));

            var groups = Group.AssignGroups(rucksacks);

            groups[0].Badge
                .Should().Be('r');
            groups[0].BadgePriority
                .Should().Be(18);

            groups[1].Badge
                .Should().Be('Z');
            groups[1].BadgePriority
                .Should().Be(52);

            groups.Sum(x => x.BadgePriority)
                .Should().Be(70);
        }
    }
}