using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [Header("左のボックスか")] public bool isFirstBox;
    [SerializeField] private Game game = null;
    private Animal animal = null;
    private string animalTag = "Animal";

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントのインスタンスを捕まえる
        //game = transform.parent.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 動物との衝突判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("衝突");
        if (collision.tag == animalTag)
        {
            animal = collision.gameObject.GetComponent<Animal>();
            if (isFirstBox)
            {
                game.SetFirstAnimal(animal);
            }
            else
            {
                game.SetLastAnimal(animal);
            }
        }
    }
}
