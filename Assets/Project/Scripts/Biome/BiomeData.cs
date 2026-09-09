using UnityEngine;

[CreateAssetMenu(fileName = "NewBiomeData", menuName = "Project/Biome Data", order = 51)]
public class BiomeData : ScriptableObject
{
    [SerializeField] private int _capacity;

    public int Capacity => _capacity;
}