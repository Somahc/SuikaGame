using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{

    public int[] ballList = new int[2];
    public static GManager instance = null;
    public bool isHaveBall = true; // ボールをプレイヤーが持っているかどうか
    public Text scoreText;
    public Text scoreTextGameover;

    public int score = 0;

    private void Awake(){
    if(instance == null)
    {
         instance = this;
         DontDestroyOnLoad(this.gameObject); 
         scoreText = GameObject.Find("/InGameUI/Score").GetComponent<Text>();
         scoreTextGameover = GameObject.Find("/GameoverModal/ScoreText").GetComponent<Text>();
    }
    else
    {
         Destroy(this.gameObject);
    }
    ballList[0] = Random.Range(0, 3);
    ballList[1] = Random.Range(0, 3);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int plusScore){
        if(scoreText == null) {
            scoreText = GameObject.Find("/InGameUI/Score").GetComponent<Text>();
            scoreTextGameover = GameObject.Find("/GameoverModal/ScoreText").GetComponent<Text>();
            score = 0;
        }
        this.score += plusScore;
        scoreText.text = "Score: " + this.score;
        scoreTextGameover.text = "Score: " + this.score;
    }
}
