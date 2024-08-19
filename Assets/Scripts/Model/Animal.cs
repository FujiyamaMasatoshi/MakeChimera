using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string japaneseName = "";

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
    }
}




