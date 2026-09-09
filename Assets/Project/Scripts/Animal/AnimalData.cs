using UnityEngine;

[CreateAssetMenu(fileName = "NewAnimalData", menuName = "Project/Animal Data", order = 51)]
public class AnimalData : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private BiomeData _targetBiome;
    [SerializeField] private BiomeData[] _allowedBiomes;

    public GameObject Prefab => _prefab;
    public BiomeData TargetBiome => _targetBiome;
    public BiomeData[] AllowedBiomes => _allowedBiomes;
}