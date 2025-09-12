using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject mainImage; //アナウンスをする画像
    public GameObject buttonPanel; //ボタンをグループ化しているパネル

    public GameObject retryButton; //リトライボタン
    public GameObject nextButton; //ネクストボタン

    public Sprite gameClearSprite; //ゲームクリアの絵
    public Sprite gameOverSprite; //ゲームクリアの絵
    TimeController timeCnt; // TimeController.csの参照
    public GameObject TimeText; //ゲームオブジェクトであるTimeText
    public GameObject ScoreText; //スコアテキスト
    AudioSource audio;
    SoundController soundController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeCnt = GetComponent<TimeController>(); //

        buttonPanel.SetActive(false); //存在を非表示

        //時間差でメソッドを発動
        Invoke("InactiveImage", 1.0f);

        UpdateScore(); //トータルスコアが出るように更新

        audio = GetComponent<AudioSource>();
        soundController = GetComponent<SoundController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == "gameclear")
        {
            buttonPanel.SetActive(true); //ボタンパネルの復活
            mainImage.SetActive(true); //メイン画像の復活
            //メイン画像オブジェクトのImageコンポーネントが所持している変数sprite に ”ステージクリア”の絵を代入
            mainImage.GetComponent<Image>().sprite = gameClearSprite;
            //リトライボタンオブジェクトのButtonコンポーネントが所持している変数interactableを無効（ボタン機能を無効）
            retryButton.GetComponent<Button>().interactable = false;


            //ステージクリアによってステージスコアが確定したので
            GameManager.totalScore += GameManager.stageScore;
            GameManager.stageScore = 0;
            timeCnt.isTimeOver = true;
            float times = timeCnt.displayTime;

            if (timeCnt.isCountDown)
            {
                GameManager.totalScore += (int)times * 10;

            }



            else
            {
                float gameTime = timeCnt.gameTime; //基準時間の取得
                GameManager.totalScore += (int)(gameTime - times);
            }

            UpdateScore(); //UIに最終的な数字を反映

            audio.Stop();
            audio.PlayOneShot(soundController.bgm_GameClear);

            GameManager.gameState = "gameend";

        }



        else if (GameManager.gameState == "gameover")
        {
            buttonPanel.SetActive(true); //ボタンパネルの復活
            mainImage.SetActive(true); //メイン画像の復活
            //メイン画像オブジェクトのImageコンポーネントが所持している変数sprite に "ゲームオーバー”の絵を代入
            mainImage.GetComponent<Image>().sprite = gameOverSprite;
            //ネクストボタンオブジェクトのButtonコンポーネントが所持している変数interactableを無効（ボタン機能を無効）
            nextButton.GetComponent<Button>().interactable = false;

            timeCnt.isTimeOver = true;

            audio.Stop();
            audio.PlayOneShot(soundController.bgm_GameOver);

            GameManager.gameState = "gameend";

        }
        else if (GameManager.gameState == "playing")
        {
            float times = timeCnt.displayTime; //一旦ディスプレイタイムの数字を変数timesに渡しておく
            TimeText.GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(times).ToString();

            if (timeCnt.isCountDown)
            {
                if (timeCnt.displayTime <= 0)
                {
                    //プレイヤーを見つけてきて、そのPlayerControllerコンポーネントのGameOverメソッドをやらせている
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GameOver();
                    GameManager.gameState = "gameover";
                }
            }
            else
            {
                if (timeCnt.displayTime >= timeCnt.gameTime)
                {
                    //プレイヤーを見つけてきて、そのPlayerControllerコンポーネントのGameOverメソッドをやらせている
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GameOver();
                    GameManager.gameState = "gameover";

                }
            }
            //スコアもリアルタイムで更新
            UpdateScore();

        }


    }

    //メイン画像を非表示するためだけのメソッド
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    void UpdateScore()
    {
        int score = GameManager.stageScore + GameManager.totalScore;
        ScoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();

    }


}
