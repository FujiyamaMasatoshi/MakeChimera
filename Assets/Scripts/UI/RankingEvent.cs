using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingEvent : MonoBehaviour
{

    [SerializeField] GameObject rankingPanel = null;
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
    }
}
