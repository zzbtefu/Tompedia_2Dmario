using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // どこからでも GameManager.instance でアクセスできるようにする魔法(Singleton)
    public static GameManager instance;

    public int score = 0;
    public bool isGameOver = false;

    void Awake()
    {
        // 自分自身をinstanceに代入（重複防止の簡易版）
        if (instance == null)
        {
            instance = this;
            // シーン遷移しても壊れないようにする（必要であれば）
            // DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // スコア加算メソッド（敵が倒れたらこれを呼ぶ）
    public void AddScore(int amount)
    {
        if (isGameOver) return; // ゲームオーバーなら加算しない

        score += amount;
        Debug.Log("Score: " + score);
    }

    // ゲームオーバー処理
    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        // ここでUIManagerに「ゲームオーバー画面だして」と命令する
    }
}
