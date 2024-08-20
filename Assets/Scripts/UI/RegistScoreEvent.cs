using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegistScoreEvent : MonoBehaviour
{
    [SerializeField] GameObject registScorePanel = null;
    [SerializeField] TMP_InputField inputField = null;
    
    // Start is called before the first frame update
    void Start()
    {
        // 初めはcreditPanelはactive falseにして隠す
        if (registScorePanel != null) registScorePanel.SetActive(false);
    }

    public void ClosePanel()
    {
        registScorePanel.SetActive(false);
    }

    public void OpenPanel()
    {
        registScorePanel.SetActive(true);
    }


    public void RegistScore()
    {
        string registName = inputField.text;
        PlayerData playerData = new PlayerData(registName, GManager.instance.score);

        // Save実行
        Save(playerData);

        // registPanelをcloseする
        ClosePanel();
    }

    // #################
    // データのSave機能
    // #################
    public void Save(PlayerData playerData)
    {
        // これまでのデータをロードする
        List<PlayerData> allPlayerData = Load();
        allPlayerData.Add(playerData);

        // シリアライズ化してPlayerPrefsで書き込む
        string json = JsonUtility.ToJson(new PlayerDataList(allPlayerData), true);
        PlayerPrefs.SetString("playersData", json);

    }

    public List<PlayerData> Load()
    {
        // PlayerPrefsでデータを保持する
        string json = PlayerPrefs.GetString("playersData", "");
        PlayerDataList playerDataList = JsonUtility.FromJson<PlayerDataList>(json);

        // json == "" => return empty list
        if (playerDataList == null) return new List<PlayerData>();
        else return playerDataList.playersData;
    }
}



// ####################
// PlayerDataの保存
// ####################

// 保管するデータ構造
[System.Serializable]
public class PlayerData
{
    public string name;
    public int score;

    public PlayerData(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

// PlayerDataを保持するリスト
[System.Serializable]
public class PlayerDataList
{
    public List<PlayerData> playersData;

    public PlayerDataList()
    {
        playersData = new List<PlayerData>();
    }

    public PlayerDataList(List<PlayerData> playersData)
    {
        this.playersData = playersData;
    }
}
