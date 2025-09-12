using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public bool toTitle; //タイトルへの切り替えかどうかのフラグ

    public void Load()
    {
        GameManager.stageScore = 0;

        //toTitleフラグがtrueになっている場合はタイトルに戻ることが予想されるのでトータルスコアをリセット
        if (toTitle) GameManager.totalScore = 0;


        //引数に指定した名前のシーンに切り替えしてくれるメソッド呼び出し
        SceneManager.LoadScene(sceneName);

    }

}