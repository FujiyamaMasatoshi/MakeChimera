using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingEvent : MonoBehaviour
{

    [SerializeField] private GameObject rankingPanel = null;
    [SerializeField] private List<TextMeshProUGUI> rankingList = new List<TextMeshProUGUI>();
    [SerializeField, Header("RegistScoreEventがDataManager")] private RegistScoreEvent dataManager = null;

    // Start is called before the first frame update
    void Start()
    {
        // 初めはcreditPanelはactive falseにして隠す
        if (rankingPanel != null) rankingPanel.SetActive(false);
    }

    public void ClosePanel()
    {
        rankingPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        rankingPanel.SetActive(true);
        DisplayRankingList();
    }


    public void DisplayRankingList()
    {
        List<PlayerData> playersData = dataManager.Load();
        for (int i=0; i<rankingList.Count; i++)
        {
            // playersDataをまだ全て参照していない場合
            if (i < playersData.Count) rankingList[i].text = $"{playersData[i].name}     " + $"{playersData[i].score}";
            else rankingList[i].gameObject.SetActive(false);
        }
    }
}
