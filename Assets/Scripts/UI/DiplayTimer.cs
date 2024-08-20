using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiplayTimer : MonoBehaviour
{
    [SerializeField] private StageManager stageManager = null;

    private TextMeshProUGUI timerText;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        timerText.text = "残り時間: " + (GManager.instance.limitTime - (float)GManager.instance.gameTime);
    }
}
