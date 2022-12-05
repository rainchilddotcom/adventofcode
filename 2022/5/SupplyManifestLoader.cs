namespace _5
{
    public class SupplyManifestLoader
    {
        public SupplyManifest LoadSupplies(Crane crane, string[] input)
        {
            var supplyManifest = new SupplyManifest(crane);

            var backwards = input.Reverse();

            foreach (var line in backwards)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("move"))
                {
                    supplyManifest.Moves.Push(line);
                    continue;
                }

                // must be a stack line

                if (supplyManifest.Stacks.Count == 0)
                {
                    // if we haven't got any stacks yet, this line will be the definition of how many stacks, so lets set 'em up
                    foreach (var key in line.Split(' '))
                    {
                        if (string.IsNullOrWhiteSpace(key))
                            continue;

                        supplyManifest.Stacks[Convert.ToInt32(key)] = new Stack<string>();
                    }
                }
                else
                {
                    // load crates into stacks
                    for (int stack = 1, i = 1; stack <= supplyManifest.Stacks.Count && i < line.Length; stack++, i += 4)
                    {
                        var box = line[i].ToString();
                        if (string.IsNullOrWhiteSpace(box))
                            continue;

                        supplyManifest.Stacks[stack].Push(box);
                    }
                }
            }

            return supplyManifest;
        }
    }
}