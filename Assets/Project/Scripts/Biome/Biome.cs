using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour
{
    [SerializeField] private BiomeData _data;
    
    [SerializeField] private Transform[] _slots;
    [SerializeField] private Transform _entrancePoint;
    [SerializeField] private Transform _exitPoint;
    
    private readonly List<Animal> _animals = new();

    public BiomeData Data => _data;
    public IReadOnlyList<Animal> Animals => _animals;
    
    public Transform[] Slots => _slots;
    public Transform EntrancePoint => _entrancePoint;
    public Transform ExitPoint => _exitPoint;
    
    public int Capacity => _data.Capacity;
    public int FreeSlots => _data.Capacity - _animals.Count;

    public void AddAnimal(Animal animal)
    {
        if (_animals.Count >= _data.Capacity)
            return;
        
        if (_animals.Contains(animal))
            return;
        
        _animals.Add(animal);
        animal.SetCurrentBiome(this);
    }

    public void RemoveAnimal(Animal animal)
    {
        _animals.Remove(animal);
    }

    public void RefreshSlots(bool instant = false)
    {
        for (int i = 0; i < _animals.Count; i++)
        {
            Animal animal = _animals[i];
            Vector3 targetPosition = _slots[i].position;
            
            if (instant)
                animal.transform.position = targetPosition;
            else if (animal.IsMovingAlongPath == false)
                animal.StartSlotMoving(targetPosition);
        }
    }

    public List<Animal> GetAnimalGroup(Animal animal)
    {
        int index = _animals.IndexOf(animal);

        if (index == -1)
            return new List<Animal>();

        AnimalData type = animal.Data;

        List<Animal> group = new();

        int start = index;

        while (start > 0 && _animals[start - 1].Data == type)
            start--;

        for (int i = start; i < _animals.Count; i++)
        {
            if (_animals[i].Data != type)
                break;

            group.Add(_animals[i]);
        }

        return group;
    }
    
    public bool CanSelectAnimal(Animal animal)
    {
        int index = _animals.IndexOf(animal);

        if (index == -1)
            return false;

        while (index > 0 && _animals[index - 1].Data == animal.Data)
            index--;

        return index == 0;
    }
    
    
    public void RestoreAnimals(List<Animal> animals)
    {
        _animals.Clear();

        foreach (Animal animal in animals)
        {
            _animals.Add(animal);
            animal.SetCurrentBiome(this);
        }

        RefreshSlots(true);
    }
}