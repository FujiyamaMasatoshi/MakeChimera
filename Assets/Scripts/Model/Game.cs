using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField, Header("全てのAnimalの数")] private List<Animal> animals;
    
    [SerializeField, Header("キメラを生成する数")] private int numChimera = 5;

    [SerializeField] private int collect1 = 1;
    [SerializeField] private int collect2 = 2;
    [SerializeField] private int collect3 = 3;
    [SerializeField] private int collect4 = 4;
    [SerializeField] private int collectAll = 5;
    //public int oneSetScore = 0; // 1フェーズごとのスコア -> GameManagerでトータルスコアを管理
    private int numCollect = 0; // 正解数


    public List<Animal> gameUsedAnimals = new List<Animal>(); // ゲームで使用されるAnimalsを保持するリスト
    
    public Dictionary<string, bool> answerChimeraNames = new Dictionary<string, bool>();

    // 選択されたAnimals
    public Animal firstAnimal; // あとでprivateにする
    public Animal lastAnimal; // あとでprivateにする

    // 生成されたキメラの名前
    public string generatedChimeraName = "";



    // ゲーム開始時に呼ぶ初期化加するメソッド
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

    public void ClearGeneratedChimeraName()
    {
        generatedChimeraName = "";
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

    // 左側を選択する　Animal を渡す
    public Animal GetFirstAnimal()
    {
        return firstAnimal;
    }

    // 右側を選択する　Animal を渡す
    public Animal GetLastAnimal()
    {
        return lastAnimal;
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
            foreach (string chimeraName in answerChimeraNames.Keys)
            {
                if (chimeraName.Equals(generatedChimeraName))
                {
                    Debug.Log("生成されたキメラは解です。");

                    // Dict{answerChimeraNames}を更新
                    UpdateAnswerChimeraDict();


                    // 正解数++
                    numCollect++;
                    ComputeScore();
                    return;
                }
            }
            Debug.Log("それは解ではありません。");
        }
    }

    private void UpdateAnswerChimeraDict()
    {
        // この時は、generatedChimeraNameをまだ保持しているので、
        // dictを参照して、false->trueに変更する
        foreach(string chimeraName in answerChimeraNames.Keys)
        {
            if (chimeraName.Equals(generatedChimeraName))
            {
                answerChimeraNames[generatedChimeraName] = true;
                break;
            }

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
                animal.DestroySelf();
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

            Animal animal = Instantiate(animals[random], new Vector3(i, -1f, 0f), Quaternion.identity);
            gameUsedAnimals.Add(animal);

            // IDの削除
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
            answerChimeraNames.Add(firstChar + lastChar, false);
            

        }
    }


    private void ComputeScore()
    {
        if (numCollect == 1) GManager.instance.score += collect1;
        else if (numCollect == 2) GManager.instance.score += collect2;
        else if (numCollect == 3) GManager.instance.score += collect3;
        else if (numCollect == 4) GManager.instance.score += collect4;
        else if (numCollect == 5)
        {
            GManager.instance.score += collectAll;

        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //CheckAnswer(); // -> 動く
            //GenerateChimeraName(); // -> 動く
        }
    }

}
