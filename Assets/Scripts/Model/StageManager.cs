using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Game game = null;
    [SerializeField] private GenerateList generateList = null;

    // Start is called before the first frame update
    void Start()
    {
        // トータルスコアの初期化
        GManager.instance.score = 0;

        game.InitGame();
        generateList.SetAnswerList();
    }



    // Update is called once per frame
    void Update()
    {
        // ゲームタイムを進める
        GManager.instance.gameTime += Time.deltaTime;

        // 時間オーバーしたら、
        if (GManager.instance.gameTime > GManager.instance.limitTime)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
