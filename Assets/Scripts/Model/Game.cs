using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField, Header("全てのAnimalの数")] private List<Animal> animals;
    
    [SerializeField, Header("キメラを生成する数")] private int numChimera = 5;

    
    public List<Animal> gameUsedAnimals = new List<Animal>(); // ゲームで使用されるAnimalsを保持するリスト
    public List<string> answerChimeraNames = new List<string>(); // ゲームの答えとして用意されたChimeraの名前

    private void Start()
    {
        InitGame();
    }

    // ゲーム開始時に呼ぶ初期化メソッド
    public void InitGame()
    {
        // ゲーム情報の初期化
        gameUsedAnimals.Clear();
        answerChimeraNames.Clear();

        // ゲーム情報の生成
        SelectRandomAnimals();
        // 答えの生成
        MakeAnswer();

    }


    // numChimera*2の数だけゲームで使用するAnimalのリストに追加する
    private void SelectRandomAnimals()
    {
        // アニマルIDから、ランダムにAnimalを選択するtempListを生成
        List<int> animalID = new List<int>();
        for (int i = 0; i<animals.Count; i++) animalID.Add(i);

        // numChimeraの数だけ、ランダムにAnimalをgameUsedAnimalsにセットしていく
        for (int i = 0; i<numChimera*2; i++)
        {
            int random = animalID[Random.Range(0, animalID.Count)];
            gameUsedAnimals.Add(animals[random]);
            animalID.Remove(random);
        }
    }

    // 答えとなる組み合わせを生成する
    private void MakeAnswer()
    {
        // gameUsedAnimalsから、2種類を選択して、generatedChimeraNameに追加する


        // とりあえずは、ランダムに生成する
        for (int i=0; i<numChimera; i++)
        {
            // FirstCharacterを取得するAnimal
            int randomFirst = Random.Range(0, gameUsedAnimals.Count);
            Animal firstAnimal = gameUsedAnimals[randomFirst];
            gameUsedAnimals.Remove(firstAnimal); // 選択したら削除

            // LastCharacterを取得するAnimal
            int randomLast = Random.Range(0, gameUsedAnimals.Count);
            Animal lastAnimal = gameUsedAnimals[randomLast];
            gameUsedAnimals.Remove(lastAnimal); // 選択したら削除



            // {first, last} Animalから文字を取得してanswerChimeraNamesに追加する
            string firstChar = firstAnimal.GetFirstCharacter().ToString();
            string lastChar = lastAnimal.GetLastCharacter().ToString();

            // answerChimeraNamesに解を追加
            answerChimeraNames.Add(firstChar + lastChar);

            
        }
    }



}
