using System.Collections.Generic;
using UnityEngine;

public class MoveHistory : MonoBehaviour
{
    [SerializeField] Biome[] _biomes;

    private readonly Dictionary<Biome, List<Animal>> _snapshot = new();

    public void SaveState()
    {
        _snapshot.Clear();
        
        foreach (Biome biome in _biomes) 
            _snapshot.Add(biome, new List<Animal>(biome.Animals));
    }

    public void RestoreState()
    {
        if (_snapshot.Count == 0)
            return;

        foreach (Biome biome in _biomes)
        {
            if (_snapshot.TryGetValue(biome, out List<Animal> animals))
                biome.RestoreAnimals(animals);
        }

        _snapshot.Clear();
    }
}