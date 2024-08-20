using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateButton : MonoBehaviour
{
    [SerializeField] private Game game = null;
    [SerializeField] private GenerateList generateList = null;
    [SerializeField] private Chimera chimera;

    public void StartGenerateChimera()
    {
        // game.generatedChimeraNameを""にする
        game.ClearGeneratedChimeraName();

        // キメラ生成
        game.GenerateChimeraName();
        Instantiate(chimera).Initialize(game.)
        

        // 答えの確認
        game.CheckAnswer();


        // アンサーリストUIの更新
        generateList.SetAnswerList();

        // もし、生成したAnimalを全て合成して、0になったら
        // ゲームをリセットして再度スタート
        if (game.gameUsedAnimals.Count == 0)
        {
            // ゲームの初期化
            game.InitGame();
            generateList.SetAnswerList();
        }
    }
}
