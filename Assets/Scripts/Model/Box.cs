using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [Header("左のボックスかどうか")] public bool isFirstBox;
    [SerializeField] private Game game = null;
    private Animal animal = null;
    private Animal inBoxAnimal = null;
    private Select select = null;
    private bool isSet = false;  // セット可能か
    private string animalTag = "Animal";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 動物との接触時の処理
    void AnimalTrigger(Collider2D collision)
    {
        if (game == null)
        {
            return;
        }

        animal = collision.gameObject.GetComponent<Animal>();
        select = collision.gameObject.GetComponent<Select>();

        if (inBoxAnimal == null)
        {
            inBoxAnimal = animal;
            isSet = true;
            select.SetIsSet(true);
        }

        if (isSet && !select.GetIsDrag())
        {
            if (isFirstBox)
            {
                game.SetFirstAnimal(animal);
            }
            else
            {
                game.SetLastAnimal(animal);
            }

            isSet = false;
        }
    }

    // 動物の脱出時の処理
    void AnimalExit(Collider2D collision)
    {
        if (game == null)
        {
            return;
        }

        animal = collision.gameObject.GetComponent<Animal>();
        select = collision.gameObject.GetComponent<Select>();

        if (animal == inBoxAnimal)
        {
            if (isFirstBox)
            {
                game.SetFirstAnimal(null);
            }
            else
            {
                game.SetLastAnimal(null);
            }

            inBoxAnimal = null;
            select.SetIsSet(false);
        }
    }

    // 動物の衝突判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == animalTag)
        {
            AnimalTrigger(collision);
        }
    }

    // 動物の侵入判定
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == animalTag)
        {
            AnimalTrigger(collision);
        }
    }

    // 動物の脱出判定
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == animalTag)
        {
            AnimalExit(collision);
        }
    }
}
