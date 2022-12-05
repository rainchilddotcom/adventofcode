namespace _5
{
    public class CrateMover9001
        : Crane
    {
        public override string Name => nameof(CrateMover9001);

        public override void ProcessMove(SupplyManifest supplyManifest, int quantity, int fromStack, int toStack)
        {
            var craneInventory = new Stack<string>();

            for (int i = 0; i < quantity; i++)
            {
                craneInventory.Push(supplyManifest.Stacks[fromStack].Pop());
            }

            while (craneInventory.Count > 0)
            {
                supplyManifest.Stacks[toStack].Push(craneInventory.Pop());
            }
        }
    }
}