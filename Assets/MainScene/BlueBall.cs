using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : MonoBehaviour
{
    [SerializeField] GameObject _biggerBallPrefab;
    public bool collisionDestory = true; // これ入れることで、一回の衝突で複数のオブジェクトが消えないようにする
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
        if(!GManager.instance.isHaveBall) {
            player.GetComponent<Player>().LoadNextBall();
        }

        if(other.gameObject.tag == "Blue" && collisionDestory){
            other.gameObject.GetComponent<BlueBall>().collisionDestory = false;
            Debug.Log("Blue");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject go = Instantiate(_biggerBallPrefab, this.transform.position, Quaternion.identity);
        }

    }
}
