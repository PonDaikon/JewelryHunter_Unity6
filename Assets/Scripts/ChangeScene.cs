using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void Load()
    {
        //引数に指定した名前のシーンに切り替えしてくれるメソッド呼び出し
        SceneManager.LoadScene(sceneName);

    }

}