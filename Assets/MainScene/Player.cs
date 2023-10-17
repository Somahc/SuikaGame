using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _redBallPrefab;
    [SerializeField] GameObject _blueBallPrefab;
    [SerializeField] GameObject _greenBallPrefab;
    private float speed = 0.009f;
    GameObject currentBall;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, -1.25f, 0);
        int rnd = GManager.instance.ballList[0];
        if(rnd == 0){
            currentBall = Instantiate(_redBallPrefab, spawnPosition, Quaternion.identity);
        }else if(rnd == 1){
            currentBall = Instantiate(_blueBallPrefab, spawnPosition, Quaternion.identity);
        }else if(rnd == 2){
            currentBall = Instantiate(_greenBallPrefab, spawnPosition, Quaternion.identity);
        }
        rb2d = currentBall.GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true;
    }   

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        // 左に移動
        if (Input.GetKey(KeyCode.LeftArrow)) {
            position.x -= speed;
            transform.position = position;
            if(GManager.instance.isHaveBall) currentBall.transform.position = transform.position + new Vector3(0, -1.25f, 0);
        }
        // 右に移動
        if (Input.GetKey(KeyCode.RightArrow)) {
            position.x += speed;
            transform.position = position;
            if(GManager.instance.isHaveBall) currentBall.transform.position = transform.position + new Vector3(0, -1.25f, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space) && GManager.instance.isHaveBall){
            DropBall();
        }

        // transform.position = position;

    }

    public void DropBall(){
        GManager.instance.isHaveBall = false;
        rb2d.isKinematic = false; // 重力を有効に
        rb2d.velocity = new Vector2(0, -1); // 下向きの速度を設定
    }

    public void LoadNextBall(){
        GManager.instance.ballList[0] = GManager.instance.ballList[1];
        GManager.instance.ballList[1] = Random.Range(0, 3);
        GManager.instance.isHaveBall = true;
        Vector3 spawnPosition = transform.position + new Vector3(0, -1.25f, 0);
        int rnd = GManager.instance.ballList[0];
        if(rnd == 0){
            currentBall = Instantiate(_redBallPrefab, spawnPosition, Quaternion.identity);
        }else if(rnd == 1){
            currentBall = Instantiate(_blueBallPrefab, spawnPosition, Quaternion.identity);
        }else if(rnd == 2){
            currentBall = Instantiate(_greenBallPrefab, spawnPosition, Quaternion.identity);
        }
        rb2d = currentBall.GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true;
    }
}