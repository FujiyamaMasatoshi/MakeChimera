using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GenerateButton : MonoBehaviour
{
    [SerializeField] private Game game = null;
    [SerializeField] private Generator generator = null;
    [SerializeField] private GenerateList generateList = null;

    // Chimeraを作れるなら作り、その後必要な処理を呼び出す。
    public void TryGenerateChimera()
    {
        if(generator.CheckGeneratable())
        {
            Debug.Log("Generation Successed");

            // キメラ生成
            generator.GenerateChimera();

            // アンサーリストUIの更新
            generateList.SetAnswerList();

            // 使ったアニマルとキメラの破壊
            generator.DestroyAnimalsAndChimera();

            // ステージ終了なら初期化
            if(game.CheckStageEnd())
            {
                game.InitGame();
                generateList.SetAnswerList();
            }
        }
        else
        {
            Debug.Log("Generation Failed");
        }
    }
}
