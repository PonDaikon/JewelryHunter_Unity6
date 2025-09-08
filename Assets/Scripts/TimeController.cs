using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    //�J�E���g�_�E���ɂ��邩�ǂ����̃t���O
    //false�Ȃ�J�E���g�A�b�v
    public bool isCountDown = true;

    //�Q�[���̊�ƂȂ鎞��
    public float gameTime = 0;

    //�J�E���g���~�߂邩�ǂ����̃t���O
    //false�Ȃ�J�E���g��������Atrue�Ȃ�J�E���g�I��
    public bool isTimeOver = false;

    //���[�U�[�Ɍ����鎞��
    public float displayTime = 0;

    //�Q�[���̌o�ߎ���
    float times = 0;

    void Start()
    {
        if (isCountDown)
        {
            displayTime = gameTime;
        
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (!isTimeOver)
        {
            //��~�t���O�������Ă��Ȃ��̂ŏ������������A�Q�[���X�e�[�^�X��playing�łȂ��Ȃ����Ƃ��͎~�߂���
            if (GameManager.gameState != "playing")
            {
                isTimeOver = true; //��~�t���O��on
            
            }

            //�J�E���g�̏�������
            //�o�ߎ��Ԃ̒~��
            times += Time. deltaTime; //�f���^�^�C���̒~��

            if (isCountDown)
            {
                //���[�U�[�Ɍ����������ԁi�c���ԁj�c���ԂɁi�����-�o�ߎ��ԁj����
                displayTime = gameTime - times;

                if (displayTime <= 0)
                {
                    displayTime = 0; //0�\�L�ɓ���
                    isTimeOver = true; //��~�^�C�}�[��on
                    GameManager.gameState = "gameover";
                }
            }
            else //�J�E���g�A�b�v�`�����������
            {
                displayTime = times; //�o�ߎ��Ԃ����[�U�[�Ɍ����������Ԃɑ��
                if (displayTime >= gameTime)
                {
                    //���[�U�[�Ɍ����������Ԃ�����Ԃɂ���
                    displayTime = gameTime;
                    isTimeOver = true; //��~�t���O��on
                    GameManager.gameState = "gameover";
                
                }

            
            }

        
        }
        
    }
}
