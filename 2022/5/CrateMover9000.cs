namespace _5
{
    public class CrateMover9000
        : Crane
    {
        public override string Name => nameof(CrateMover9000);

        public override void ProcessMove(SupplyManifest supplyManifest, int quantity, int fromStack, int toStack)
        {
            for (int i = 0; i < quantity; i++)
            {
                supplyManifest.Stacks[toStack].Push(supplyManifest.Stacks[fromStack].Pop());
            }
        }
    }
}