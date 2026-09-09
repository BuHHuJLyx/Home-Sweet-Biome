using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimalMover))]
public class Animal : MonoBehaviour
{
    [SerializeField] private AnimalData _data;

    private AnimalMover _mover;

    private Biome _currentBiome;

    public AnimalData Data => _data;
    public Biome CurrentBiome => _currentBiome;

    private void Awake()
    {
        _mover = GetComponent<AnimalMover>();
    }

    public void Initialize(Biome biome)
    {
        _currentBiome = biome;
    }

    public List<Animal> GetGroup()
    {
        return _currentBiome.GetAnimalGroup(this);
    }
}