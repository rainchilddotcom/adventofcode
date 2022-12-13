using _0;

namespace _12
{
    public class TerrainLoader
    {
        public HeightMapAlpha LoadTerrain(string[] input)
        {
            var heightMap = new HeightMapAlpha(input);
            return heightMap;
        }
    }
}
