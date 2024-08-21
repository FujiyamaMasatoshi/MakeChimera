using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBGM : MonoBehaviour
{
    [SerializeField] private int bgmNumber;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("called");
        SManager.instance.SetBGM(bgmNumber);
    }
}
