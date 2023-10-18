using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameManager : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("atatta");
        if(!GManager.instance.isHaveBall) {
            player.GetComponent<Player>().LoadNextBall();
        }

        // if(other.gameObject.tag == "Blue" && collisionDestory){
        //     other.gameObject.GetComponent<BlueBall>().collisionDestory = false;
        //     Debug.Log("Blue");
        //     Destroy(other.gameObject);
        //     Destroy(this.gameObject);
        //     GameObject go = Instantiate(_biggerBallPrefab, this.transform.position, Quaternion.identity);
        // }

    }
}
