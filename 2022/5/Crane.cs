namespace _5
{
    public abstract class Crane
    {
        public abstract string Name { get; }
        public abstract void ProcessMove(SupplyManifest supplyManifest, int quantity, int fromStack, int toStack);
    }
}