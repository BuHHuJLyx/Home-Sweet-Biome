using System.Linq;

public class MoveValidator
{
    public bool CanMoveTo(Animal animal, Biome targetBiome, int groupSize)
        => animal.Data.AllowedBiomes.Contains(targetBiome.Data)
           && targetBiome.FreeSlots >= groupSize;
}