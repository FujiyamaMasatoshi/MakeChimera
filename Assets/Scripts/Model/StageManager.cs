using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Game game = null;
    [SerializeField] private GenerateList generateList = null;

    // Start is called before the first frame update
    void Start()
    {
        game.InitGame();
        generateList.SetAnswerList();
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}
