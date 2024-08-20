using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPlacer : MonoBehaviour
{
    [SerializeField] private Game game = null;

    public void GenerateAnimalObj()
    {
        foreach(Animal animal in game.gameUsedAnimals)
        {
            Instantiate<Animal>(animal, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
    }
}
