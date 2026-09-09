using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Dictionary<BiomeData, Biome> _biomes = new();

    public IReadOnlyDictionary<BiomeData, Biome> Biomes => _biomes;

    public void Initialize(IReadOnlyList<LevelData.BiomeSetup> biomeSetups)
    {
        _biomes.Clear();

        Biome[] levelBiomes = GetComponents<Biome>();

        foreach (Biome biome in levelBiomes)
        {
            if (biome.Data != null && _biomes.ContainsKey(biome.Data) == false)
                _biomes.Add(biome.Data, biome);
        }

        foreach (LevelData.BiomeSetup biomeSetup in biomeSetups)
        {
            if (_biomes.TryGetValue(biomeSetup.Biome, out Biome biome))
                foreach (AnimalData animal in biomeSetup.Animals)
                    CreateAnimal(animal, biome);                
        }
    }

    private void CreateAnimal(AnimalData animal, Biome value)
    {
        throw new System.NotImplementedException();
    }
}