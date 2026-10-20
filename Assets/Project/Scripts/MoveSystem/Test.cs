using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Animal[] _animals;
    [SerializeField] private Biome _firstBiome;
    [SerializeField] private Biome _secondBiome;
    [SerializeField] private MovementPath _path;

    private void Start()
    {
        for (int i = 0; i < _animals.Length; i++)
        {
            Animal animal = _animals[i];
            
            animal.Initialize(_path);
            
            if (i < 5)
                _firstBiome.AddAnimal(animal);
            else
                _secondBiome.AddAnimal(animal);
        }

        _firstBiome.RefreshSlots(true);
        _secondBiome.RefreshSlots(true);
    }
}