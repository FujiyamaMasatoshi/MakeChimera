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
        //foreach(Animal animal in game.gameUsedAnimals)
        for (int i=0; i<game.gameUsedAnimals.Count; i++)
        {
            Animal animal = game.gameUsedAnimals[i];
            Instantiate(animal, new Vector3(i, -1f, 0f), Quaternion.identity);
            
        }
    }
}
