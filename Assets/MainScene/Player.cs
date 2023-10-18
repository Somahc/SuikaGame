using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _redBallPrefab;
    [SerializeField] GameObject _blueBallPrefab;
    [SerializeField] GameObject _greenBallPrefab;
    private float speed = 0.009f;
    private bool isWaitEnough = false;
    GameObject currentBall;
    GameObject nextManager;
    Rigidbody2D rb2d;
    public Text nextText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateNextText();
        nextManager = GameObject.Find("NextManager");
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
            if(GManager.instance.isHaveBall && currentBall != null) currentBall.transform.position = transform.position + new Vector3(0, -1.25f, 0);
        }
        // 右に移動
        if (Input.GetKey(KeyCode.RightArrow)) {
            position.x += speed;
            transform.position = position;
            if(GManager.instance.isHaveBall && currentBall != null) currentBall.transform.position = transform.position + new Vector3(0, -1.25f, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space) && GManager.instance.isHaveBall){
            DropBall();
        }

        // transform.position = position;

    }

    public void DropBall(){
        GManager.instance.isHaveBall = false;
        StartCoroutine(WaitLoadBall());
        rb2d.isKinematic = false; // 重力を有効に
        rb2d.velocity = new Vector2(0, -6); // 下向きの速度を設定
    }

    public void LoadNextBall(){
        if(isWaitEnough){
            Debug.Log("LoadNextBall");
            isWaitEnough = false;
            GManager.instance.ballList[0] = GManager.instance.ballList[1];
            GManager.instance.ballList[1] = Random.Range(0, 3);
            UpdateNextText();
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
        // Debug.Log("LoadNextBall");
        // GManager.instance.ballList[0] = GManager.instance.ballList[1];
        // GManager.instance.ballList[1] = Random.Range(0, 3);
        // UpdateNextText();
        // GManager.instance.isHaveBall = true;
        // Vector3 spawnPosition = transform.position + new Vector3(0, -1.25f, 0);
        // int rnd = GManager.instance.ballList[0];
        // if(rnd == 0){
        //     currentBall = Instantiate(_redBallPrefab, spawnPosition, Quaternion.identity);
        // }else if(rnd == 1){
        //     currentBall = Instantiate(_blueBallPrefab, spawnPosition, Quaternion.identity);
        // }else if(rnd == 2){
        //     currentBall = Instantiate(_greenBallPrefab, spawnPosition, Quaternion.identity);
        // }
        // rb2d = currentBall.GetComponent<Rigidbody2D>();
        // rb2d.isKinematic = true;
    }

    private void UpdateNextText(){
        if(GManager.instance.ballList[1] == 0) nextText.text = "Next: Red";
        else if(GManager.instance.ballList[1] == 1) nextText.text = "Next: Blue";
        else if(GManager.instance.ballList[1] == 2) nextText.text = "Next: Green";
    }

    private IEnumerator WaitLoadBall(){ // 次のボールの装填まで最低0.4秒待つようにし、発射直後に図形が消えないようにする
        yield return new WaitForSeconds(0.4f);
        isWaitEnough = true;
    }
}