using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    public string japaneseName = "";
    public Image firstImage;
    public Image lastImage;
    public float defaultScale;
    public float defaultRotation;

    // 先頭文字を取得
    public char GetFirstCharacter()
    {
        char firstCharacter = japaneseName[0];
        return firstCharacter;
    }

    // 末尾文字を取得
    public char GetLastCharacter()
    {
        char lastCharacter = japaneseName[japaneseName.Length - 1];
        return lastCharacter;
    }

    // 縮尺と回転を初期状態に設定
    private void SetScaleRotation()
    {
        transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale);

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z = defaultRotation;
        transform.eulerAngles = currentRotation;
    }

    // テスト
    private void Test()
    {
        Debug.Log($"{japaneseName}");
        Debug.Log($"First Character: {GetFirstCharacter()}");
        Debug.Log($"Last Character: {GetLastCharacter()}");
    }

    // テスト実行
    private void Start()
    {
        //Test();
        SetScaleRotation();
    }
}




