using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Project/Level Data", order = 51)]
public class LevelData : ScriptableObject
{
    [SerializeField] private int _number;
    [SerializeField] private List<BiomeSetup> _biomes;

    public int Number => _number;
    public IReadOnlyList<BiomeSetup> Biomes => _biomes;

    [System.Serializable]
    public class BiomeSetup
    {
        [SerializeField] private BiomeData _biome;
        [SerializeField] private List<AnimalData> _animals;

        public BiomeData Biome => _biome;
        public IReadOnlyList<AnimalData> Animals => _animals;
    }
}