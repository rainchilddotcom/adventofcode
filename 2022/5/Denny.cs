namespace _5
{
    public class Denny
        : Crane
    {
        public override string Name => "Denny Crane";

        public override void ProcessMove(SupplyManifest supplyManifest, int quantity, int fromStack, int toStack)
        {
            // Denny does what he wants.

            quantity = Random.Shared.Next(1, 100);

            for (int i = 0; i < quantity; i++)
            {
                fromStack = Random.Shared.Next(1, supplyManifest.Stacks.Count);
                toStack = Random.Shared.Next(1, supplyManifest.Stacks.Count);

                if (supplyManifest.Stacks[fromStack].Count > 0)
                    supplyManifest.Stacks[toStack].Push(supplyManifest.Stacks[fromStack].Pop());
            }

            throw new Exception("DENNY CRANE!!");
        }
    }
}