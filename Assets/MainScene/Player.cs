using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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

        transform.position = position;
    }
}
