using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateList : MonoBehaviour
{
    [SerializeField] private Game game = null;
    [SerializeField, Header("gameの解リスト")] private List<TextMeshProUGUI> generateList = new List<TextMeshProUGUI>();
    [SerializeField, Header("解が生成されたかどうか")] private List<TextMeshProUGUI> isGeneratedList = new List<TextMeshProUGUI>();


    public void SetAnswerList()
    {
        // キメラnameをセット
        int i = 0;
        foreach(string key in game.answerChimeraNames.Keys)
        {
            generateList[i].text = key;
            i++;
        }

        // 指示されたキメラが生成されたかどうか
        i = 0;
        foreach(bool b in game.answerChimeraNames.Values)
        {
            isGeneratedList[i].text = b.ToString();
            i++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetAnswerList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
