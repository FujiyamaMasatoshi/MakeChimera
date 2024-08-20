using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateButton : MonoBehaviour
{
    [SerializeField] private Game game = null;
    [SerializeField] private GenerateList generateList = null;

    public void StartGenerateChimera()
    {
        // キメラ生成
        game.GenerateChimeraName();

        // 答えの確認
        game.CheckAnswer();


        // アンサーリストUIの更新
        generateList.SetAnswerList();
        
    }
}
