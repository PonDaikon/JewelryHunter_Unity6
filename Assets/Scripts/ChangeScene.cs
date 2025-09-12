using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public bool toTitle; //�^�C�g���ւ̐؂�ւ����ǂ����̃t���O

    public void Load()
    {
        GameManager.stageScore = 0;

        //toTitle�t���O��true�ɂȂ��Ă���ꍇ�̓^�C�g���ɖ߂邱�Ƃ��\�z�����̂Ńg�[�^���X�R�A�����Z�b�g
        if (toTitle) GameManager.totalScore = 0;


        //�����Ɏw�肵�����O�̃V�[���ɐ؂�ւ����Ă���郁�\�b�h�Ăяo��
        SceneManager.LoadScene(sceneName);

    }

}