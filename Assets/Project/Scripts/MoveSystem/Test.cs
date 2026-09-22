using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Animal[] _animals;
    [SerializeField] private Biome _currentBiome;
    [SerializeField] private Biome _targetBiome;
    [SerializeField] private MovementPath _path;
    [SerializeField] private Mover _mover;

    private void Start()
    {
        foreach (Animal animal in _animals)
        {
            animal.Initialize(_path);

            _currentBiome.AddAnimal(animal);
        }

        _currentBiome.RefreshSlots();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_animals.Length == 0)
                return;

            _mover.Move(_animals[0], _targetBiome);
        }
    }
}