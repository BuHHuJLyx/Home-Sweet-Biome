using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour
{
    [SerializeField] private BiomeData _data;
    [SerializeField] private Transform[] _slots;

    private readonly List<Animal> _animals = new();

    public BiomeData Data => _data;
    public IReadOnlyList<Animal> Animals => _animals;
    public int Capacity => _data.Capacity;
    public int FreeSlots => _data.Capacity - _animals.Count;

    public void AddAnimal(Animal animal)
    {
        if (_animals.Count >= _data.Capacity)
            return;
        
        _animals.Add(animal);
    }

    public void RemoveAnimal(Animal animal)
    {
        _animals.Remove(animal);
    }

    public void RefreshSlots()
    {
        for (int i = 0; i < _animals.Count; i++)
            _animals[i].transform.position = _slots[i].position;
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
}