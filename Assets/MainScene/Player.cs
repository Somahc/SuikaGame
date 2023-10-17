using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _redBallPrefab;
    [SerializeField] GameObject _blueBallPrefab;
    [SerializeField] GameObject _greenBallPrefab;
    private float speed = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        // 左に移動
        if (Input.GetKey(KeyCode.LeftArrow)) {
            position.x -= speed;
        }
        // 右に移動
        if (Input.GetKey(KeyCode.RightArrow)) {
            position.x += speed;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            NextBall();
        }

        transform.position = position;
    }

    public void NextBall(){
        int rnd = Random.Range(0, 3);
        if(rnd == 0){
            GameObject go = Instantiate(_redBallPrefab, this.transform.position, Quaternion.identity);
        }else if(rnd == 1){
            GameObject go = Instantiate(_blueBallPrefab, this.transform.position, Quaternion.identity);
        }else if(rnd == 2){
            GameObject go = Instantiate(_greenBallPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
