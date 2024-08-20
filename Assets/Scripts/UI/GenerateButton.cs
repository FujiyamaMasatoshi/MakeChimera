using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateButton : MonoBehaviour
{
    [SerializeField] private Game game = null;

    public void StartGenerateChimera()
    {
        game.GenerateChimeraName();
    }
}
