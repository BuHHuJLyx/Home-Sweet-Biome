using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private readonly MoveValidator _validator = new();

    private bool _isMovingGroup;

    private WaitForSeconds _delay;

    private void Awake()
    {
        _delay = new WaitForSeconds(0.5f);
    }

    public void Move(Animal animal, Biome targetBiome)
    {
        if (_isMovingGroup)
            return;

        Biome currentBiome = animal.CurrentBiome;

        if (currentBiome == null || currentBiome == targetBiome)
            return;

        List<Animal> group = animal.GetGroup();
        int groupSize = group.Count;

        if (groupSize <= 0)
            return;

        if (_validator.CanMoveTo(animal, targetBiome, groupSize))
            StartCoroutine(MoveGroup(group, currentBiome, targetBiome));
    }

    private IEnumerator MoveGroup(List<Animal> group, Biome currentBiome, Biome targetBiome)
    {
        _isMovingGroup = true;

        foreach (Animal animal in group)
            currentBiome.RemoveAnimal(animal);

        currentBiome.RefreshSlots();

        foreach (Animal animal in group)
        {
            Vector3 startPosition = animal.transform.position;
            Vector3 targetPosition = targetBiome.Slots[targetBiome.Animals.Count].position;

            animal.StartMoving(startPosition, currentBiome.ExitPoint.position, targetBiome.EntrancePoint.position, targetPosition);

            targetBiome.AddAnimal(animal);

            yield return _delay;
        }
        
        bool isGroupMoving = true;

        while (isGroupMoving)
        {
            isGroupMoving = false;

            foreach (Animal animal in group)
            {
                if (animal.IsMoving)
                {
                    isGroupMoving = true;
                    break;
                }
            }

            yield return null;
        }

        targetBiome.RefreshSlots();
        _isMovingGroup = false;
    }
}