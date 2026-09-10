using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private readonly MoveValidator _validator = new();

    public void Move(Animal animal, Biome targetBiome)
    {
        List<Animal> group = animal.GetGroup();
        int groupSize = group.Count;

        if (groupSize <= 0)
            return;

        if (_validator.CanMoveTo(animal, targetBiome, groupSize))
        {
            Biome currentBiome = animal.CurrentBiome;

            foreach (Animal member in group)
            {
                currentBiome.RemoveAnimal(member);
                targetBiome.AddAnimal(member);
                member.SetCurrentBiome(targetBiome);
            }

            currentBiome.RefreshSlots();
            targetBiome.RefreshSlots();
        }
    }
}