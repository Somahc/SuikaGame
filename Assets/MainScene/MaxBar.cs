using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaxBar : MonoBehaviour
{
    private float touchDuration = 0f;
    private bool isTouching = false;
    private bool isGameOver = false;
    public Canvas canvasGameover = null;


    // Start is called before the first frame update
    void Start()
    {
        if (canvasGameover != null)
        {
            canvasGameover.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            touchDuration += Time.deltaTime;
            if (touchDuration >= 1.5f && !isGameOver) // 1.5秒以上接触していたら
            {
                // ゲームオーバーモーダルを表示する処理を呼び出す
                ShowGameOverModal();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTouching = true;
        Debug.Log("Enter");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isTouching = false;
        touchDuration = 0f; // タッチ時間をリセット
        
    }

    private void ShowGameOverModal()
    {
        isGameOver = true;
        Debug.Log("Game Over");
        if (canvasGameover != null)
        {
            canvasGameover.enabled = true;
        }
    }

    public void onButtonRetry()
    {
        // Canvas を無効にする。(ダイアログを閉じる)
        canvasGameover.enabled = false;
        SceneManager.LoadScene("MainScene");
        
    }

    public void onButtonBack()
    {
        // Canvas を無効にする。(ダイアログを閉じる)
        canvasGameover.enabled = false;
        SceneManager.LoadScene("MainScene");
    }

}
