using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] private Game game = null;
    [SerializeField] private GenerateList generateList = null;
    [SerializeField] private Chimera chimera;
    [SerializeField] private GameObject generatePlace;

    // 生成装置の左右に空きがなければTrue
    public bool CheckGeneratable()
    {
        return game.GetFirstAnimal() != null && game.GetLastAnimal() != null;
    }

    public void GenerateChimera()
    {
        // キメラを生成する
        Chimera generatedChimera = Instantiate(chimera, generatePlace.transform.position, Quaternion.identity);
        generatedChimera.MakeChimera(game.GetFirstAnimal(), game.GetLastAnimal());

        // game.generatedChimeraNameを""にする
        //game.ClearGeneratedChimeraName();

        // キメラ生成
        //game.GenerateChimeraName();
        

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
