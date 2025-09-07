using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string gameState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //ゲームの初期状態をplaying
        gameState = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameState);
    }
}
