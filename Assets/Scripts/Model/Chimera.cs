using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chimera : MonoBehaviour
{
    public string japaneseName = "";
    public Image firstImage = null;
    public Image lastImage = null;

    // Animal 2つからキメラを初期化
    public void Initialize(Animal firstAnimal, Animal lastAnimal)
    {
        string firstChara = firstAnimal.GetFirstCharacter().ToString();
        string lastChara = lastAnimal.GetLastCharacter().ToString();
        this.japaneseName = firstChara + lastChara;

        this.firstImage = firstAnimal.GetFirstImage();
        this.lastImage = lastAnimal.GetLastImage();
    }

}
