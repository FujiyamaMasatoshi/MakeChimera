using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPlacer : MonoBehaviour
{
    [SerializeField] private Game game = null;


    private void Start()
    {
        game.InitGame();
        GenerateAnimalObj();
    }

    public void GenerateAnimalObj()
    {
        foreach(Animal animal in game.gameUsedAnimals)
        {
            Instantiate(animal, new Vector3(0f, 0f, 0f), Quaternion.identity);
            
        }
    }
}
