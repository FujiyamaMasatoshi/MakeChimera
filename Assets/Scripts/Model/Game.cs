using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField, Header("全てのAnimalの数")] private List<Animal> animals;
    
    [SerializeField, Header("キメラを生成する数")] private int numChimera = 5;

    
    public List<Animal> gameUsedAnimals = new List<Animal>(); // ゲームで使用されるAnimalsを保持するリスト
    public List<string> answerChimeraNames = new List<string>(); // ゲームの答えとして用意されたChimeraの名前

    // 選択されたAnimals
    public Animal firstAnimal; // あとでprivateにする
    public Animal lastAnimal; // あとでprivateにする

    // 生成されたキメラの名前
    public string generatedChimeraName = "";


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
        SelectGameUsedAnimals();
        // 答えの生成
        MakeAnswer();

    }


    // 左側を選択するAnimalをセット
    public void SetFirstAnimal(Animal animal)
    {
        
        firstAnimal = animal;
    }

    // 右側を選択するAnimalをセット
    public void SetLastAnimal(Animal animal)
    {
        lastAnimal = animal;
        
    }

    // rightAnimalとleftAnimalがnullでないならば、キメラの名前を生成
    // 選択されたAnimalをgameUsedAnimalから削除
    public void GenerateChimeraName()
    {
        if (firstAnimal != null && lastAnimal != null)
        {
            string firstChara = firstAnimal.GetFirstCharacter().ToString();
            string lastChara = lastAnimal.GetLastCharacter().ToString();
            generatedChimeraName = firstChara + lastChara;


            // 選択されたAnimalをgameUsedAnimalsから削除する
            RemoveAnimalFromList(firstAnimal);
            RemoveAnimalFromList(lastAnimal);

            // 選択したAnimalをnullにする
            firstAnimal = null;
            lastAnimal = null;
        }
    }

    // 選択された2つのAnimalからChimeraを生成する
    public void CheckAnswer()
    {
        // answerChimeraNamesからgeneratedChimeraNameを探索して、同じものがあるかをチェックする
        if (generatedChimeraName != "")
        {
            foreach (string chimeraName in answerChimeraNames)
            {
                if (chimeraName.Equals(generatedChimeraName))
                {
                    Debug.Log("生成されたキメラは解です。");
                    return;
                }
            }
            Debug.Log("それは解ではありません。");
        }
    }


    // 引数にとったAnimalをgameUsedAnimalsから削除する
    private void RemoveAnimalFromList(Animal selectedAnimal)
    {
        foreach(Animal animal in gameUsedAnimals)
        {
            if (animal.japaneseName.Equals(selectedAnimal.japaneseName))
            {
                gameUsedAnimals.Remove(animal);
                return;
            }
        }
    }

    // numChimera*2の数だけゲームで使用するAnimalのリストに追加する
    private void SelectGameUsedAnimals()
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
        // gameUsedAnimalsのコピーをtempListとして用意する
        List<Animal> tempList = new List<Animal>(gameUsedAnimals);
        // gameUsedAnimalsから、2種類を選択して、generatedChimeraNameに追加する


        // とりあえずは、ランダムに生成する
        for (int i=0; i<numChimera; i++)
        {
            // FirstCharacterを取得するAnimal
            int randomFirst = Random.Range(0, tempList.Count);
            Animal firstAnimal = tempList[randomFirst];
            tempList.Remove(firstAnimal); // 選択したら削除

            // LastCharacterを取得するAnimal
            int randomLast = Random.Range(0, tempList.Count);
            Animal lastAnimal = tempList[randomLast];
            tempList.Remove(lastAnimal); // 選択したら削除



            // {first, last} Animalから文字を取得してanswerChimeraNamesに追加する
            string firstChar = firstAnimal.GetFirstCharacter().ToString();
            string lastChar = lastAnimal.GetLastCharacter().ToString();

            // answerChimeraNamesに解を追加
            answerChimeraNames.Add(firstChar + lastChar);

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //CheckAnswer(); // -> 動く
            GenerateChimeraName(); // -> 動く
        }
    }

}
