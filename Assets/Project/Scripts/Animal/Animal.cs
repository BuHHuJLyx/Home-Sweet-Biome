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
    public bool IsMoving => _mover.IsMoving;

    private void Awake()
    {
        _mover = GetComponent<AnimalMover>();
    }

    public void Initialize(MovementPath path)
    {
        _mover.Initialize(path);
    }

    public void StartMoving(Vector3 startPosition, Vector3 exitPosition, Vector3 entrancePosition, Vector3 targetPosition)
    {
        _mover.StartMoving(startPosition, exitPosition, entrancePosition, targetPosition);
    }

    public void SetCurrentBiome(Biome biome)
    {
        _currentBiome = biome;
    }

    public List<Animal> GetGroup() 
        => _currentBiome.GetAnimalGroup(this);
}