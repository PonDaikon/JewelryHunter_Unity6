using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void Load()
    {
        //�����Ɏw�肵�����O�̃V�[���ɐ؂�ւ����Ă���郁�\�b�h�Ăяo��
        SceneManager.LoadScene(sceneName);

    }

}