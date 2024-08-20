using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GenerateButton : MonoBehaviour
{
    [SerializeField] private Generator generator = null;
    public void TryGenerateChimera()
    {
        if(generator.CheckGeneratable())
        {
            Debug.Log("Generation Successed");
            generator.GenerateChimera();
        }
        else
        {
            Debug.Log("Generation Failed");
        }
    }
}
